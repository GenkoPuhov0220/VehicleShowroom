using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleDbContext context;
        public VehicleController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Cars)
                .Include(v => v.Trucks)
                .Include(v => v.Buses)
                .Include(v => v.Motorcycles)
                .ToListAsync();
               
            return View(AllVehicle);
        }
    }
}
