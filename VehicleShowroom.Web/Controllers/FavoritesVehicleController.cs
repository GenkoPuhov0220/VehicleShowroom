using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Web;

namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;

    [Authorize]
    public class FavoritesVehicleController : Controller
    {
        private readonly VehicleDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public FavoritesVehicleController(VehicleDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = userManager.GetUserId(User)!;
            

            var favorite = await context
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

            return View(favorite);
        }
        [HttpPost]
        public async Task<IActionResult> AddToFavorite(int vehicleId)
        {
            var vehicle = await context
                .Vehicles
                .Where(v => v.IsDelete == false)
                .FirstOrDefaultAsync(v => v.VehicleId == vehicleId);

            if (vehicle == null)
            {
                return RedirectToAction("Index", "Vehicle");
            }

            var userId = userManager.GetUserId(User)!;

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
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite(int vehicleId)
        {
            var vehicle = await context
               .Vehicles
               .Where(v => v.IsDelete == false)
               .FirstOrDefaultAsync(v => v.VehicleId == vehicleId);

            if (vehicle == null)
            {
                return RedirectToAction("Index", "Vehicle");
            }

            var userId = userManager.GetUserId(User)!;

            ApplicationUserVehicle? applicationUserVehicle = await context
                .UsersVehicles
                .FirstOrDefaultAsync(uv => uv.ApplicationUserId == userId && uv.VehicleId == vehicleId);

            if (applicationUserVehicle != null)
            {
                context.UsersVehicles.Remove(applicationUserVehicle);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
