using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
    public class TruckController : Controller
    {
        private readonly VehicleDbContext context;
        public TruckController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Trucks)
                .Where(v => v.VehicleType == "Truck".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var motorcycle = await context.Trucks
                .Include(c => c.Vehicle)
                .Where(c => c.VehicleId == id)
                .Select(c => new TruckDetailsViewModel
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
                    CargoCapacity = c.CargoCapacity,
                    Transmission = c.Transmission,
                    Description = c.Description,
                    HorsePower = c.HorsePower,
                    EuroNumber = c.EuroNumber

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
