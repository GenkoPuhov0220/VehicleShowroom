using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Dml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data.Interfaces;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Data
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    public class TruckServices : ITruckServices
    {
        private readonly VehicleDbContext context;
        public TruckServices(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Vehicle>> GetAllTrucksAsync()
        {
            var AllVehicle = await context.Vehicles
              .Include(v => v.Trucks)
              .Where(c => c.IsDelete == false)
              .Where(v => v.VehicleType == "Truck".ToLower())
              .ToListAsync();

            return AllVehicle;
        }
        public async Task<TruckDetailsViewModel> GetTruckDetailsAsync(int id)
        {
            var truck = await context.Trucks
                  .Include(c => c.Vehicle)
                  .Where(c => c.IsDelete == false)
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

            return truck;
        }

        public async Task<TruckEditViewModel> GetTruckForEditAsync(int id)
        {
            var vehicle = await context
             .Trucks
             .Include(b => b.Vehicle)
             .Where(c => c.IsDelete == false)
             .Where(b => b.VehicleId == id)
             .Select(b => new TruckEditViewModel
             {
                 VehicleType = b.Vehicle.VehicleType,
                 Make = b.Vehicle.Make,
                 Model = b.Vehicle.Model,
                 Year = b.Vehicle.Year.ToString(YearFormating),
                 Price = b.Vehicle.Price,
                 Color = b.Vehicle.Color,
                 FuelType = b.Vehicle.FuelType,
                 ImageUrl = b.Vehicle.ImageUrl,

                 TruckId = b.TruckId,
                 CargoCapacity = b.CargoCapacity,
                 Transmission = b.Transmission,
                 Description = b.Description,
                 HorsePower = b.HorsePower,
                 EuroNumber = b.EuroNumber
             })
              .FirstOrDefaultAsync();

            return vehicle;
        }
        public async Task<bool> EditTruckAsync(TruckEditViewModel models)
        {
            bool IsYearValid = DateTime
              .TryParseExact(models.Year, YearFormating, CultureInfo.InvariantCulture, DateTimeStyles.None,
              out DateTime yearValid);

            if (!IsYearValid)
            {
                return false;
            }

            var truck = await context
                .Trucks
                .Include(b => b.Vehicle)
                .Where(c => c.IsDelete == false)
                .FirstOrDefaultAsync(b => b.TruckId == models.TruckId);

            if (truck == null)
            {
                return false;
            }

            truck.Vehicle.VehicleType = models.VehicleType;
            truck.Vehicle.Make = models.Make;
            truck.Vehicle.Model = models.Model;
            truck.Vehicle.Year = yearValid;
            truck.Vehicle.Price = models.Price;
            truck.Vehicle.Color = models.Color;
            truck.Vehicle.FuelType = models.FuelType;
            truck.Vehicle.ImageUrl = models.ImageUrl;
            truck.CargoCapacity = models.CargoCapacity;
            truck.Transmission = models.Transmission;
            truck.Description = models.Description;
            truck.HorsePower = models.HorsePower;
            truck.EuroNumber = models.EuroNumber;

            await context.SaveChangesAsync();

            return true;
        }
        public async Task<TruckDeleteViewModel> GetTruckForDeleteAsync(int id)
        {
            var vehicle = await context.Trucks
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(v => v.VehicleId == id);
            if (vehicle == null)
            {
                throw new ArgumentException("Not truck");
            }
            var viewModel = new TruckDeleteViewModel
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

                TruckId = vehicle.TruckId,
                EuroNumber = vehicle.EuroNumber,
                CargoCapacity = vehicle.CargoCapacity,
                Description = vehicle.Description,
                Transmission = vehicle.Transmission,
                HorsePower = vehicle.HorsePower,

            };
            return viewModel;
        }
        public async Task<bool> ConfirmDeleteAsync(int id)
        {
            var vehicle = await context.Vehicles
               .Include(v => v.Trucks)
               .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return false;
            }

            vehicle.IsDelete = true;

            foreach (var truck in vehicle.Trucks)
            {
                truck.IsDelete = true;
            }
            await context.SaveChangesAsync();

            return true;
        }
    }
}
