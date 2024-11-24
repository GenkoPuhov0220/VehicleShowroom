using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Web;

namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;

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
                .Where(c => c.IsDelete == false)
                .Where(v => v.VehicleType == "Supercar".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var superCar = await context.SuperCars
                .Include(c => c.Vehicle)
                .Where(c => c.IsDelete == false)
                .Where(c => c.VehicleId == id)
                .Select(c => new SuperCarDetailsViewModel
                {

                    VehicleId = c.Vehicle.VehicleId,
                    VehicleType = c.Vehicle.VehicleType,
                    Make = c.Vehicle.Make,
                    Model = c.Vehicle.Model,
                    Year = c.Vehicle.Year.ToString(YearFormating),
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await context
               .SuperCars
               .Include(c => c.Vehicle)
               .Where(c => c.IsDelete == false)
               .Where(c => c.VehicleId == id)
               .Select(c => new SuperCarEditVieModel
               {

                   VehicleType = c.Vehicle.VehicleType,
                   Make = c.Vehicle.Make,
                   Model = c.Vehicle.Model,
                   Year = c.Vehicle.Year.ToString(YearFormating),
                   Price = c.Vehicle.Price,
                   Color = c.Vehicle.Color,
                   FuelType = c.Vehicle.FuelType,
                   ImageUrl = c.Vehicle.ImageUrl,

                   SuperCarId = c.SuperCarId,
                   MaxSpeed = c.MaxSpeed,
                   Weight = c.Weight,
                   Kilometers = c.Kilometers,
                   Doors = c.NumberOfDoors,
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
        public async Task<IActionResult> Edit(SuperCarEditVieModel models)
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

            var superCar = await context
                .SuperCars
                .Include(c => c.Vehicle)
                .Where(c => c.IsDelete == false)
                .FirstOrDefaultAsync(c => c.SuperCarId == models.SuperCarId);
            if (superCar == null)
            {
                return NotFound();
            }

            superCar.Vehicle.VehicleType = models.VehicleType;
            superCar.Vehicle.Make = models.Make;
            superCar.Vehicle.Model = models.Model;
            superCar.Vehicle.Year = yearValid;
            superCar.Vehicle.Price = models.Price;
            superCar.Vehicle.Color = models.Color;
            superCar.Vehicle.FuelType = models.FuelType;
            superCar.Vehicle.ImageUrl = models.ImageUrl;

            superCar.Kilometers = models.Kilometers;
            superCar.NumberOfDoors = models.Doors;
            superCar.Description = models.Description ?? string.Empty;
            superCar.Transmission = models.Transmission ?? string.Empty;
            superCar.HorsePower = models.HorsePower;
            superCar.MaxSpeed = models.MaxSpeed ?? string.Empty;
            superCar.Weight = models.Weight ?? string.Empty;

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await context.SuperCars
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var viewModel = new SuperCarDeleteViewModel
            {
                VehicleId = vehicle.VehicleId,
                VehicleType = vehicle.Vehicle.VehicleType,
                Make = vehicle.Vehicle.Model,
                Model = vehicle.Vehicle.Model,
                Year = vehicle.Vehicle.Year.ToString(YearFormating),
                Price = vehicle.Vehicle.Price,
                Color = vehicle.Vehicle.Color,
                FuelType = vehicle.Vehicle.FuelType,
                ImageUrl = vehicle.Vehicle.ImageUrl,

                SuperCarId = vehicle.SuperCarId,
                Kilometers = vehicle.Kilometers,
                NumberOfDoors = vehicle.NumberOfDoors,
                Description = vehicle.Description,
                Transmission = vehicle.Transmission,
                HorsePower = vehicle.HorsePower,
                Weight = vehicle.Weight,
                MaxSpeed = vehicle.MaxSpeed


            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmedDelete(SuperCarDeleteViewModel viewModel, int id)
        {
            var vehicle = await context.Vehicles
                .Include(v => v.SuperCars)
                .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return BadRequest();
            }

            vehicle.IsDelete = true;

            foreach (var superCar in vehicle.SuperCars)
            {
                superCar.IsDelete = true;
            }
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
