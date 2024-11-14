using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
    public class BusController : Controller
    {
        private readonly VehicleDbContext context;
        public BusController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Buses)
                .Where(v => v.VehicleType == "Bus".ToLower())
                .ToListAsync();

            return View(AllVehicle);
            
        }
    }
}
