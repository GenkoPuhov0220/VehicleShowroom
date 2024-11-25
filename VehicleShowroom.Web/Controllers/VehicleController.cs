using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data.Interfaces;


namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    public class VehicleController : Controller
    {
        private readonly VehicleDbContext context;
        private readonly IVehicleServices vehicleServices;
        public VehicleController(VehicleDbContext _context, IVehicleServices _vehicleServices)
        {
            context = _context;
            vehicleServices = _vehicleServices;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await vehicleServices
                .IndexGetAllAsync();
               
            return  View(AllVehicle);
           
        }
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVehicle(AddVehicleViewModel models)
        { 
            bool IsYearValid = DateTime
                .TryParseExact(models.Year, YearFormating, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime yearValid);
            
            if (!IsYearValid)
            {
                ModelState.AddModelError(nameof(models.Year), "The Year must be in the following format: dd/MM/yyyy");

            }
            if (!ModelState.IsValid)
            {
              return View(models);
            }
            await vehicleServices.AddVehicleAsync(models);
           
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 
    }
}
