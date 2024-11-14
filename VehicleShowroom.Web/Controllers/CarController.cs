using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;

namespace VehicleShowroom.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly VehicleDbContext context;
        public CarController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Cars)
                .Where(v => v.VehicleType == "Car".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
    }
}
