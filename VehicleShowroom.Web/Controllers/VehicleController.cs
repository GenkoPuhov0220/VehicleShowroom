using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data.Interfaces;


namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleServices vehicleServices;
        public VehicleController(IVehicleServices _vehicleServices)
        {
            
            vehicleServices = _vehicleServices;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await vehicleServices
                .IndexGetAllAsync();
               
            return  View(AllVehicle);
           
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
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

            return RedirectToAction(nameof(Index));
        } 
    }
}
