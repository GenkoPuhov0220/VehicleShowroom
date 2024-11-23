using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    public class MotorcycleController : Controller
    {
        private readonly VehicleDbContext context;
        public MotorcycleController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Motorcycles)
                .Where(v => v.IsDelete == false)
                .Where(v => v.VehicleType == "Motorcycle".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var motorcycle = await context.Motorcycles
                .Include(c => c.Vehicle)
                .Where(c => c.IsDelete == false)
                .Where(c => c.VehicleId == id)
                .Select(c => new MotorcycleDeteilsViewModel
                {

                    VehicleId = c.Vehicle.VehicleId,
                    VehicleType = c.Vehicle.VehicleType,
                    Make = c.Vehicle.Make,
                    Model = c.Vehicle.Model,
                    Year = c.Vehicle.Year.ToString(),
                    Price = c.Vehicle.Price,
                    Color = c.Vehicle.Color,
                    FuelType = c.Vehicle.FuelType,
                    ImageUrl = c.Vehicle.ImageUrl,
                    Kw = c.Kw

                })
                .FirstOrDefaultAsync();
            if (motorcycle == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(motorcycle);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await context
               .Motorcycles
               .Include(c => c.Vehicle)
               .Where(c => c.IsDelete == false)
               .Where(c => c.VehicleId == id)
               .Select(c => new MotorcycleEditViewModel
               {

                   VehicleType = c.Vehicle.VehicleType,
                   Make = c.Vehicle.Make,
                   Model = c.Vehicle.Model,
                   Year = c.Vehicle.Year.ToString(YearFormating),
                   Price = c.Vehicle.Price,
                   Color = c.Vehicle.Color,
                   FuelType = c.Vehicle.FuelType,
                   ImageUrl = c.Vehicle.ImageUrl,

                   MotorcycleId = c.MotorcycleId,
                   Kw = c.Kw,

               })
                .FirstOrDefaultAsync();

            if (vehicle == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MotorcycleEditViewModel models)
        {
            bool IsYearValid = DateTime
               .TryParseExact(models.Year, YearFormating, CultureInfo.InvariantCulture, DateTimeStyles.None,
               out DateTime yearValid);

            if (!IsYearValid)
            {
                ModelState.AddModelError(nameof(models.Year), "The Year must be in the following format: dd/MM/yyyy");

            }
            if (!ModelState.IsValid)
            {
                return View(models);
            }

            var motorcycle = await context
                .Motorcycles
                .Include(c => c.Vehicle)
                .Where(c => c.IsDelete == false)
                .FirstOrDefaultAsync(c => c.MotorcycleId == models.MotorcycleId);
            if (motorcycle == null)
            {
                return NotFound();
            }

            motorcycle.Vehicle.VehicleType = models.VehicleType;
            motorcycle.Vehicle.Make = models.Make;
            motorcycle.Vehicle.Model = models.Model;
            motorcycle.Vehicle.Year = yearValid;
            motorcycle.Vehicle.Price = models.Price;
            motorcycle.Vehicle.Color = models.Color;
            motorcycle.Vehicle.FuelType = models.FuelType;
            motorcycle.Vehicle.ImageUrl = models.ImageUrl;

            motorcycle.Kw = models.Kw;
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
