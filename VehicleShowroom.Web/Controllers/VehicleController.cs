using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;

namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    public class VehicleController : Controller
    {
        private readonly VehicleDbContext context;
        public VehicleController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Where(v => v.IsDelete == false)
                .ToListAsync();
               
            return  View(AllVehicle);
        }
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVehicle(AddVehicleViewModel models)
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
            var vehicle = new Vehicle
            {
                VehicleType = models.VehicleType,
                Make = models.Make,
                Model = models.Model,
                Year = yearValid,
                Price = models.Price,
                Color = models.Color,
                FuelType = models.FuelType,
                ImageUrl = models.ImageUrl
            };

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync(); 

            switch (models.VehicleType)
            {
                case "Car":
                    var car = new Car
                    {
                        VehicleId = vehicle.VehicleId,
                        Kilometers = models.Kilometers ?? 0,
                        NumberOfDoors = models.NumberOfDoors ?? 0,
                        Description = models.CarDescription ?? string.Empty,
                        Transmission = models.CarTransmission ?? string.Empty,
                        HorsePower = models.CarHorsePower ?? 0
                    };
                    context.Cars.Add(car);
                    break;

                case "Bus":
                    var bus = new Bus
                    {
                        VehicleId = vehicle.VehicleId,
                        Capacity = models.Capacity ?? 0,
                        Description = models.BusDescription ?? string.Empty,
                        Transmission = models.BusTransmission ?? string.Empty,
                        HorsePower = models.BusHorsePower ?? 0
                    };
                    context.Buses.Add(bus);
                    break;

                case "Motorcycle":
                    var motorcycle = new Motorcycle
                    {
                        VehicleId = vehicle.VehicleId,
                        Kw = models.Kw ?? 0
                    };
                    context.Motorcycles.Add(motorcycle);
                    break;

                case "SuperCar":
                    var superCar = new SuperCar
                    {
                        VehicleId = vehicle.VehicleId,
                        Kilometers = models.SuperCarKilometers ?? 0,
                        NumberOfDoors = models.SuperCarDoors ?? 0,
                        Description = models.SuperCarDescription ?? string.Empty,
                        Transmission = models.SuperCarTransmission ?? string.Empty,
                        HorsePower = models.SuperCarHorsePower ?? 0,
                        MaxSpeed = models.MaxSpeed ?? string.Empty,
                        Weight = models.Weight ?? string.Empty
                    };
                    context.SuperCars.Add(superCar);
                    break;

                case "Truck":
                    var truck = new Truck
                    {
                        VehicleId = vehicle.VehicleId,
                        CargoCapacity = models.CargoCapacity ?? 0,
                        EuroNumber = models.EuroNumber ?? string.Empty,
                        Description = models.TruckDescription ?? string.Empty,
                        Transmission = models.TruckTransmission ?? string.Empty,
                        HorsePower = models.TruckHorsePower ?? 0
                    };
                    context.Trucks.Add(truck);
                    break;

                default:
                    ModelState.AddModelError("VehicleType", "Invalid vehicle type.");
                    return View(models);
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        } 
    }
}
