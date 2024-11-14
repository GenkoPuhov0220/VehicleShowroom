using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
    public class MotorcycleController : Controller
    {
        private readonly VehicleDbContext context;
        public MotorcycleController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Motorcycles)
                .Where(v => v.VehicleType == "Motorcycle".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
    }
}
