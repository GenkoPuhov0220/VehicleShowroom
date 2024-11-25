using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data;
using VehicleShowroom.Services.Data.Interfaces;
using VehicleShowroom.Web;

namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;

    [Authorize]
    public class FavoritesVehicleController : Controller
    {
        private readonly VehicleDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IFavoritesVehicleServices favoritesVehicleServices;
        public FavoritesVehicleController(VehicleDbContext _context,
            UserManager<ApplicationUser> _userManager,
             IFavoritesVehicleServices _favoritesVehicleServices)
        {
            context = _context;
            userManager = _userManager;
            favoritesVehicleServices = _favoritesVehicleServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = userManager.GetUserId(User)!;
            var favorite = await favoritesVehicleServices
                .GetIndexFavoritesAsync(userId);

            return View(favorite);
        }
        [HttpPost]
        public async Task<IActionResult> AddToFavorite(int vehicleId)
        {
            var userId = userManager.GetUserId(User)!;
            var result = await favoritesVehicleServices
                .AddToFavoritesAsync(userId, vehicleId);

            if (!result)
            {
                return RedirectToAction("Index", "Vehicle");
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite(int vehicleId)
        {

            var userId = userManager.GetUserId(User)!;

            var result = await favoritesVehicleServices.RemoveFromFavoritesAsync(userId, vehicleId);
            if (!result) 
            {
                return RedirectToAction("Index", "Vehicle");
            }
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
