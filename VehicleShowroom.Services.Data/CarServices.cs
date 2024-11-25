using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
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
    public class CarServices : ICarServices
    {
        private readonly VehicleDbContext context;
        public CarServices(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
              return await context.Vehicles
                .Include(v => v.Cars)
                .Where(v => v.IsDelete == false)
                .Where(v => v.VehicleType == "Car".ToLower())
                .ToListAsync();
        }
        public async Task<CarDetailsViewModel> GetCarDetailsAsync(int id)
        {
            var car =  await context.Cars
                .Include(c => c.Vehicle)
                .Where(c => c.IsDelete == false)
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

            return car;
        }

        public async Task<CarEditViewModel> GetCarForEditAsync(int id)
        {
            var vehicle = await context
               .Cars
               .Include(c => c.Vehicle)
               .Where(c => c.IsDelete == false)
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

            return vehicle;
        }
        public async Task<bool> EditCarAsync(CarEditViewModel models)
        {
            bool IsYearValid = DateTime
              .TryParseExact(models.Year, YearFormating, CultureInfo.InvariantCulture, DateTimeStyles.None,
              out DateTime yearValid);

            if (!IsYearValid)
            {
                throw new ArgumentException("The Year must be in the following format: dd/MM/yyyy", nameof(models.Year));
            }
            var car = await context
                .Cars
                .Include(c => c.Vehicle)
                .Where(c => c.IsDelete == false)
                .FirstOrDefaultAsync(c => c.CarId == models.CarId);

            if (car == null)
            {
                return false;
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

            return true;
        }

        public async Task<CarDeleteVehicleViewModel> GetCarForDeleteAsync(int id)
        {
            var vehicle = await context.Cars
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(v => v.VehicleId == id);

           
            var viewModel = new CarDeleteVehicleViewModel
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

                CarId = vehicle.CarId,
                Kilometers = vehicle.Kilometers,
                NumberOfDoors = vehicle.NumberOfDoors,
                Description = vehicle.Description,
                Transmission = vehicle.Transmission,
                HorsePower = vehicle.HorsePower
            };

            return viewModel;
        }
        public async Task<bool> ConfirmDeleteAsync(int id)
        {
            var vehicle = await context.Vehicles
                .Include(v => v.Cars)
                .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return false;
            }

            vehicle.IsDelete = true;

            foreach (var car in vehicle.Cars)
            {
                car.IsDelete = true;
            }
            await context.SaveChangesAsync();

            return true;
        }

    }
}
