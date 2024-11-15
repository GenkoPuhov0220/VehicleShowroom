using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
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
                .Where(v => v.VehicleType == "Motorcycle".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var motorcycle = await context.Motorcycles
                .Include(c => c.Vehicle)
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
    }
}
