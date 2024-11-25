using Microsoft.EntityFrameworkCore;
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
    public class BusServices : IBusServices
    {
        private readonly VehicleDbContext context;
        public BusServices(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Vehicle>> GetAllBusesAsync()
        {
            var AllVehicle = await context.Vehicles
               .Include(v => v.Buses)
               .Where(v => v.IsDelete == false)
               .Where(v => v.VehicleType == "Bus".ToLower())
               .ToListAsync();

            return AllVehicle;
        }

        public async Task<BusDetailsViewModel> GetBusDetailsAsync(int id)
        {
            var bus = await context.Buses
                 .Include(c => c.Vehicle)
                 .Where(c => c.IsDelete == false)
                 .Where(c => c.VehicleId == id)
                 .Select(c => new BusDetailsViewModel
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
                     Capacity = c.Capacity,
                     Description = c.Description,
                     HorsePower = c.HorsePower,
                     Transmission = c.Transmission
                 })
                 .FirstOrDefaultAsync();

            return bus;
        }
        public async Task<BusEditViewModel> GetBusForEditAsync(int id)
        {
            var vehicle = await context
                .Buses
                .Include(b => b.Vehicle)
                .Where(c => c.IsDelete == false)
                .Where(b => b.VehicleId == id)
                .Select(b => new BusEditViewModel
                {
                    VehicleType = b.Vehicle.VehicleType,
                    Make = b.Vehicle.Make,
                    Model = b.Vehicle.Model,
                    Year = b.Vehicle.Year.ToString(YearFormating),
                    Price = b.Vehicle.Price,
                    Color = b.Vehicle.Color,
                    FuelType = b.Vehicle.FuelType,
                    ImageUrl = b.Vehicle.ImageUrl,

                    BusId = b.BusId,
                    Capacity = b.Capacity,
                    Description = b.Description,
                    HorsePower = b.HorsePower,
                    Transmission = b.Transmission
                })
                 .FirstOrDefaultAsync();

            return vehicle;
        }
        public async Task<bool> EditBusAsync(BusEditViewModel models)
        {
            bool IsYearValid = DateTime
             .TryParseExact(models.Year, YearFormating, CultureInfo.InvariantCulture, DateTimeStyles.None,
             out DateTime yearValid);

            if (!IsYearValid)
            {
                throw new ArgumentException("The Year must be in the following format: dd/MM/yyyy", nameof(models.Year));
            }
            var bus = await context
               .Buses
               .Include(b => b.Vehicle)
               .Where(c => c.IsDelete == false)
               .FirstOrDefaultAsync(b => b.BusId == models.BusId);
            if (bus == null)
            {
                return false;
            }

            bus.Vehicle.VehicleType = models.VehicleType;
            bus.Vehicle.Make = models.Make;
            bus.Vehicle.Model = models.Model;
            bus.Vehicle.Year = yearValid;
            bus.Vehicle.Price = models.Price;
            bus.Vehicle.Color = models.Color;
            bus.Vehicle.FuelType = models.FuelType;
            bus.Vehicle.ImageUrl = models.ImageUrl;

            bus.Capacity = models.Capacity;
            bus.Description = models.Description ?? string.Empty;
            bus.HorsePower = models.HorsePower;
            bus.Transmission = models.Transmission ?? string.Empty;

            await context.SaveChangesAsync();

            return true;
        }
        public async Task<BusDeleteViewModel> DeleteBusAsync(int id)
        {
            var vehicle = await context.Buses
                 .Include(v => v.Vehicle)
                 .FirstOrDefaultAsync(v => v.VehicleId == id);

            var viewModel = new BusDeleteViewModel
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

                BusId = vehicle.BusId,
                Capacity = vehicle.Capacity,
                Description = vehicle.Description,
                HorsePower = vehicle.HorsePower,
                Transmission = vehicle.Transmission
            };

            return viewModel;
        }

        public async Task<bool> BusConfirmDeleteAsync(int id)
        {
            var vehicle = await context.Vehicles
               .Include(v => v.Buses)
               .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return false;
            }

            vehicle.IsDelete = true;

            foreach (var bus in vehicle.Buses)
            {
                bus.IsDelete = true;
            }
            await context.SaveChangesAsync();

            return true;
        }


    }
}
