using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Dml;
using System;
using System.Collections.Generic;
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
    public class FavoritesServices : IFavoritesVehicleServices
    {
        private readonly VehicleDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public FavoritesServices(VehicleDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }
        public async Task<IEnumerable<ApplicationUserFavoriteList>> GetIndexFavoritesAsync(string userId)
        {
            return await context
               .UsersVehicles
               .Include(uv => uv.Vehicle)
               .Where(uv => uv.ApplicationUserId.ToLower() == userId.ToLower())
               .Select(uv => new ApplicationUserFavoriteList()
               {
                   VehicleId = uv.VehicleId,
                   VehicleType = uv.Vehicle.VehicleType,
                   Model = uv.Vehicle.Model,
                   Make = uv.Vehicle.Make,
                   Year = uv.Vehicle.Year.ToString(YearFormating),
                   Price = uv.Vehicle.Price,
                   Color = uv.Vehicle.Color,
                   FuelType = uv.Vehicle.FuelType,
                   ImageUrl = uv.Vehicle.ImageUrl
               })
               .ToListAsync();
        }
        public async Task<bool> AddToFavoritesAsync(string userId, int vehicleId)
        {
            var vehicle = await context
               .Vehicles
               .Where(v => v.IsDelete == false)
               .FirstOrDefaultAsync(v => v.VehicleId == vehicleId);

            if (vehicle == null)
            {
                return false;
            }

            bool IsVehicleAlredyAddToFavorite = await context
                .UsersVehicles
                .AnyAsync(uv => uv.ApplicationUserId == userId && uv.VehicleId == vehicleId);

            if (!IsVehicleAlredyAddToFavorite)
            {
                ApplicationUserVehicle applicationUserVehicle = new ApplicationUserVehicle
                {
                    ApplicationUserId = userId,
                    VehicleId = vehicleId
                };

                await context.UsersVehicles.AddAsync(applicationUserVehicle);
                await context.SaveChangesAsync();

                return true;
            }
            return false;
        }


        public async Task<bool> RemoveFromFavoritesAsync(string userId, int vehicleId)
        {
            var vehicle = await context
                .Vehicles
                .Where(v => v.IsDelete == false)
                .FirstOrDefaultAsync(v => v.VehicleId == vehicleId);

            if (vehicle == null)
            {
                return false;
            }

            return true;
        }
    }
}
