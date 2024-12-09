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
    public class SuperCarServices : ISuperCarServices
    {
        private readonly VehicleDbContext context;
        public SuperCarServices(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Vehicle>> GetAllSuperCarAsync()
        {
            var AllVehicle = await context.Vehicles
              .Include(v => v.SuperCars)
              .Where(c => c.IsDelete == false)
              .Where(v => v.VehicleType == "Supercar".ToLower())
              .ToListAsync();

            if (AllVehicle == null)
            {
                throw new ArgumentException("There are currently no such vehicle");
            }

            return AllVehicle;
        }
        public async Task<SuperCarDetailsViewModel> GetSuperCarDetailsAsync(int id)
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

            return superCar;
        }
        public async Task<SuperCarEditVieModel> GetSuperForEditAsync(int id)
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
                   HorsePower = c.HorsePower,
                   NumberOfDoors = c.NumberOfDoors
               })
                .FirstOrDefaultAsync();

            return vehicle;
        }
        public async Task<bool> EditCarAsync(SuperCarEditVieModel models)
        {
            bool IsYearValid = DateTime
                .TryParseExact(models.Year, YearFormating, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime yearValid);

            if (!IsYearValid)
            {
                return false;
            }

            var superCar = await context
                .SuperCars
                .Include(c => c.Vehicle)
                .Where(c => c.IsDelete == false)
                .FirstOrDefaultAsync(c => c.SuperCarId == models.SuperCarId);
            if (superCar == null)
            {
                return false;
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

            return true;
        }
        public async Task<SuperCarDeleteViewModel> GetSuperCarForDeleteAsync(int id)
        {
            var vehicle = await context.SuperCars
                 .Include(v => v.Vehicle)
                 .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                throw new ArgumentException("Not vehicle fot delete");
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

            return viewModel;
        }
        public async Task<bool> ConfirmDeleteAsync(int id)
        {
            var vehicle = await context.Vehicles
                .Include(v => v.SuperCars)
                .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return false;
            }

            vehicle.IsDelete = true;

            foreach (var superCar in vehicle.SuperCars)
            {
                superCar.IsDelete = true;
            }
            await context.SaveChangesAsync(); 

            return true;
        }
    }
}
