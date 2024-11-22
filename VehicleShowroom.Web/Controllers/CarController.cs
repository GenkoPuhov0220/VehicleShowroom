using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Web;

namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
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
                     Year = c.Vehicle.Year.ToString(),
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var vehicle = await context
               .Cars
               .Include(c => c.Vehicle)
               .Where(c => c.VehicleId == id)
               .Select(c => new CarEditViewModel
                 {

                     VehicleType = c.Vehicle.VehicleType,
                     Make = c.Vehicle.Make,
                     Model = c.Vehicle.Model,
                     Year = c.Vehicle.Year.ToString(YearFormating),
                     Price = c.Vehicle.Price,
                     Color = c.Vehicle.Color,
                     FuelType = c.Vehicle.FuelType,
                     ImageUrl = c.Vehicle.ImageUrl,

                     CarId = c.CarId,
                     Kilometers = c.Kilometers,
                     NumberOfDoors = c.NumberOfDoors,
                     Description = c.Description,
                     Transmission = c.Transmission,
                     HorsePower = c.HorsePower
                 })
                .FirstOrDefaultAsync();

            if (vehicle == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarEditViewModel models)
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

            var car = await context
                .Cars
                .Include(c => c.Vehicle)
                .FirstOrDefaultAsync(c => c.CarId == models.CarId);
            if (car == null)
            {
                return NotFound();
            }

            car.Vehicle.VehicleType = models.VehicleType;
            car.Vehicle.Make = models.Make;
            car.Vehicle.Model = models.Model;
            car.Vehicle.Year = yearValid;
            car.Vehicle.Price = models.Price;
            car.Vehicle.Color = models.Color;
            car.Vehicle.FuelType = models.FuelType;
            car.Vehicle.ImageUrl = models.ImageUrl;

            car.Kilometers = models.Kilometers;
            car.NumberOfDoors = models.NumberOfDoors;
            car.Description = models.Description ?? string.Empty;
            car.Transmission = models.Transmission ?? string.Empty;
            car.HorsePower = models.HorsePower;

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
