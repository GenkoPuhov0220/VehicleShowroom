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
    public class MotorcycleServices : IMotorcycleServices
    {
        private readonly VehicleDbContext context;
        public MotorcycleServices(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Vehicle>> GetAllMotorcycleAsync()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Motorcycles)
                .Where(v => v.IsDelete == false)
                .Where(v => v.VehicleType == "Motorcycle".ToLower())
                .ToListAsync();

            return AllVehicle;
        }
        public async Task<MotorcycleDeteilsViewModel> GetMotrocycleDetailsAsync(int id)
        {
            var motorcycle = await context.Motorcycles
              .Include(c => c.Vehicle)
              .Where(c => c.IsDelete == false)
              .Where(c => c.VehicleId == id)
              .Select(c => new MotorcycleDeteilsViewModel
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
                  Kw = c.Kw

              })
              .FirstOrDefaultAsync();

            return motorcycle;
        }
        public async Task<MotorcycleEditViewModel> GetMotorcycleForEditAsync(int id)
        {
            var vehicle = await context
               .Motorcycles
               .Include(c => c.Vehicle)
               .Where(c => c.IsDelete == false)
               .Where(c => c.VehicleId == id)
               .Select(c => new MotorcycleEditViewModel
               {

                   VehicleType = c.Vehicle.VehicleType,
                   Make = c.Vehicle.Make,
                   Model = c.Vehicle.Model,
                   Year = c.Vehicle.Year.ToString(YearFormating),
                   Price = c.Vehicle.Price,
                   Color = c.Vehicle.Color,
                   FuelType = c.Vehicle.FuelType,
                   ImageUrl = c.Vehicle.ImageUrl,

                   MotorcycleId = c.MotorcycleId,
                   Kw = c.Kw,

               })
                .FirstOrDefaultAsync();
           
            return vehicle;
        }
        public async Task<bool> EditMotorcycleAsync(MotorcycleEditViewModel models)
        {
            bool IsYearValid = DateTime
               .TryParseExact(models.Year, YearFormating, CultureInfo.InvariantCulture, DateTimeStyles.None,
               out DateTime yearValid);

            if (!IsYearValid)
            {
                return false;
            }

            var motorcycle = await context
               .Motorcycles
               .Include(c => c.Vehicle)
               .Where(c => c.IsDelete == false)
               .FirstOrDefaultAsync(c => c.MotorcycleId == models.MotorcycleId);

            if (motorcycle == null)
            {
                return false;
            }

            motorcycle.Vehicle.VehicleType = models.VehicleType;
            motorcycle.Vehicle.Make = models.Make;
            motorcycle.Vehicle.Model = models.Model;
            motorcycle.Vehicle.Year = yearValid;
            motorcycle.Vehicle.Price = models.Price;
            motorcycle.Vehicle.Color = models.Color;
            motorcycle.Vehicle.FuelType = models.FuelType;
            motorcycle.Vehicle.ImageUrl = models.ImageUrl;

            motorcycle.Kw = models.Kw;
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<MotorcycleDeleteViewModel> DeleteMotorcycleAsync(int id)
        {
            var vehicle = await context.Motorcycles
                 .Include(v => v.Vehicle)
                 .FirstOrDefaultAsync(v => v.VehicleId == id);
            if (vehicle == null)
            {
                throw new ArgumentException("No motorcycle");
            }
            var viewModel = new MotorcycleDeleteViewModel
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
                Kw = vehicle.Kw
            };

            return viewModel;
        }

        public async Task<bool> MotorcycleConfirmDeleteAsync(int id)
        {
            var vehicle = await context.Vehicles
               .Include(v => v.Motorcycles)
               .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return false;
            }

            vehicle.IsDelete = true;

            foreach (var motorcycle in vehicle.Motorcycles)
            {
                motorcycle.IsDelete = true;
            }
            await context.SaveChangesAsync();

            return true;
        }
    }
}
