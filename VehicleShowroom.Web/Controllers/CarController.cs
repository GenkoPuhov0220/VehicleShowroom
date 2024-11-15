using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly VehicleDbContext context;
        public CarController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Cars)
                .Where(v => v.VehicleType == "Car".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var car = await context.Cars
                .Include(c => c.Vehicle)
                .Where(c => c.VehicleId == id)
                .Select(c => new CarDetailsViewModel
                {
           
                     VehicleId = c.Vehicle.VehicleId,
                     VehicleType = c.Vehicle.VehicleType,
                     Make = c.Vehicle.Make,
                     Model = c.Vehicle.Model,
                     Year = c.Vehicle.Year,
                     Price = c.Vehicle.Price,
                     Color = c.Vehicle.Color,
                     FuelType = c.Vehicle.FuelType,
                     ImageUrl = c.Vehicle.ImageUrl,

                    Kilometers = c.Kilometers,
                    NumberOfDoors = c.NumberOfDoors,
                    CarDescription = c.Description,
                    CarTransmission = c.Transmission,
                    CarHorsePower = c.HorsePower
                 })
                .FirstOrDefaultAsync();
            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }
    }
}
