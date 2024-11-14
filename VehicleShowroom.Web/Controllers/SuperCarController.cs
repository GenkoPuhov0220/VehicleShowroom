using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
    public class SuperCarController : Controller
    {
        private readonly VehicleDbContext context;
        public SuperCarController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.SuperCars)
                .Where(v => v.VehicleType == "Supercar".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
    }
}
