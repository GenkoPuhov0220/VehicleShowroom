using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data.Interfaces;
using VehicleShowroom.Web;


namespace VehicleShowroom.Services.Data
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    public class VehicleServices : IVehicleServices
    {
        private readonly VehicleDbContext context;
         public VehicleServices(VehicleDbContext _context)
         {
                context = _context;
         }
        public async Task<IEnumerable<Vehicle>> IndexGetAllAsync()
        {
            return await context.Vehicles
               .Where(v => v.IsDelete == false)
               .ToListAsync();
        }
        public async Task<bool> AddVehicleAsync(AddVehicleViewModel models)
        {
            bool IsYearValid = DateTime
               .TryParseExact(models.Year, YearFormating, CultureInfo.InvariantCulture, DateTimeStyles.None,
               out DateTime yearValid);

            if (!IsYearValid)
            {
                return false;
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
                    Car car = new Car
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
                    Bus bus = new Bus
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
                    Motorcycle motorcycle = new Motorcycle
                    {
                        VehicleId = vehicle.VehicleId,
                        Kw = models.Kw ?? 0
                    };
                    context.Motorcycles.Add(motorcycle);
                    break;

                case "SuperCar":
                    SuperCar superCar = new SuperCar
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
                    Truck truck = new Truck
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
            }

            await context.SaveChangesAsync();
            return true;
        }

        
    }
}
