using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;


namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    public class BusController : Controller
    {
        private readonly VehicleDbContext context;
        public BusController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Buses)
                .Where(v => v.VehicleType == "Bus".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var bus = await context.Buses
                .Include(c => c.Vehicle)
                .Where(c => c.VehicleId == id)
                .Select(c => new BusDetailsViewModel
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
                    Capacity = c.Capacity,
                    Description = c.Description,
                    HorsePower = c.HorsePower,
                    Transmission = c.Transmission
                })
                .FirstOrDefaultAsync();
            if (bus == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(bus);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await context
               .Buses
               .Include(b => b.Vehicle)
               .Where(b => b.VehicleId == id)
               .Select(b => new BusEditViewModel
               {
                   VehicleType = b.Vehicle.VehicleType,
                   Make = b.Vehicle.Make,
                   Model = b.Vehicle.Model,
                   Year = b.Vehicle.Year.ToString(YearFormating),
                   Price = b.Vehicle.Price,
                   Color = b.Vehicle.Color,
                   FuelType = b.Vehicle.FuelType,
                   ImageUrl = b.Vehicle.ImageUrl,

                   BusId = b.BusId,
                   Capacity = b.Capacity,
                   Description = b.Description,
                   HorsePower = b.HorsePower,
                   Transmission = b.Transmission
               })
                .FirstOrDefaultAsync();
          
            if (vehicle == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BusEditViewModel models)
        {
            bool IsYearValid = DateTime
               .TryParseExact(models.Year, YearFormating, CultureInfo.InvariantCulture, DateTimeStyles.None,
               out DateTime yearValid);

            if (!IsYearValid)
            {
                ModelState.AddModelError(nameof(models.Year), "The Year must be in the following format: dd.MM.yyyy");

            }
            if (!ModelState.IsValid)
            {
                return View(models);
            }

            var bus = await context
                .Buses
                .Include(b => b.Vehicle)
                .FirstOrDefaultAsync(b => b.BusId == models.BusId);
            if (bus == null)
            {
                return NotFound();
            }

            bus.Vehicle.VehicleType = models.VehicleType;
            bus.Vehicle.Make = models.Make;
            bus.Vehicle.Model = models.Model;
            bus.Vehicle.Year = yearValid;
            bus.Vehicle.Price = models.Price;
            bus.Vehicle.Color = models.Color;
            bus.Vehicle.FuelType = models.FuelType;
            bus.Vehicle.ImageUrl = models.ImageUrl;

            bus.Capacity = models.Capacity;
            bus.Description = models.Description ?? string.Empty;
            bus.HorsePower = models.HorsePower;
            bus.Transmission = models.Transmission ?? string.Empty;

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
