using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
    public class TruckController : Controller
    {
        private readonly VehicleDbContext context;
        public TruckController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Trucks)
                .Where(v => v.VehicleType == "Truck".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
    }
}
