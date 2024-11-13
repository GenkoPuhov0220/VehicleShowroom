using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Web;


namespace VehicleShowroom.Web.Controllers
{
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
            if (!ModelState.IsValid)
            {
                return View(models);
            }
            var vehicle = new Vehicle
            {
                VehicleType = models.VehicleType,
                Make = models.Make,
                Model = models.Model,
                Year = models.Year,
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
                        Kilometers = models.Kilometers,
                        NumberOfDoors = models.NumberOfDoors,
                        Description = models.CarDescription,
                        Transmission = models.CarTransmission,
                        HorsePower = models.CarHorsePower
                    };
                    context.Cars.Add(car);
                    break;

                case "Bus":
                    var bus = new Bus
                    {
                        VehicleId = vehicle.VehicleId,
                        Capacity = models.Capacity,
                        Description = models.BusDescription,
                        Transmission = models.BusTransmission,
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
                        NumberOfDoors = models.SuperCarDoors,
                        Description = models.SuperCarDescription,
                        Transmission = models.SuperCarTransmission,
                        HorsePower = models.SuperCarHorsePower,
                        MaxSpeed = models.MaxSpeed,
                        Weight = models.Weight
                    };
                    context.SuperCars.Add(superCar);
                    break;

                case "Truck":
                    var truck = new Truck
                    {
                        VehicleId = vehicle.VehicleId,
                        CargoCapacity = models.CargoCapacity ?? 0,
                        EuroNumber = models.EuroNumber,
                        Description = models.TruckDescription,
                        Transmission = models.TruckTransmission,
                        HorsePower = models.TruckHorsePower ?? 0
                    };
                    context.Trucks.Add(truck);
                    break;

                default:
                    ModelState.AddModelError("VehicleType", "Invalid vehicle type.");
                    return View(models);
            }

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
