using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
    public class SuperCarController : Controller
    {
        private readonly VehicleDbContext context;
        public SuperCarController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.SuperCars)
                .Where(v => v.VehicleType == "Supercar".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var superCar = await context.SuperCars
                .Include(c => c.Vehicle)
                .Where(c => c.VehicleId == id)
                .Select(c => new SuperCarDetailsViewModel
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
                    Kilometers = c.Kilometers,
                    NumberOfDoors = c.NumberOfDoors,
                    Description = c.Description,
                    Transmission = c.Transmission,
                    MaxSpeed = c.MaxSpeed,
                    Weight = c.Weight,
                    HorsePower = c.HorsePower
                   
                })
                .FirstOrDefaultAsync();
            if (superCar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(superCar);
        }
    }
}
