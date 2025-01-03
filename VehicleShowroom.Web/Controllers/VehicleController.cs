using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data.Interfaces;


namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationMessages;
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleServices vehicleServices;
        public VehicleController(IVehicleServices _vehicleServices)
        {
            
            vehicleServices = _vehicleServices;
        }
        public async Task<IActionResult> Index(int? pageNumber, string searchString)
        {
            int pageSize = 9;

            var AllVehicle = await vehicleServices
                .IndexGetAllAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                AllVehicle = AllVehicle
                    .Where(a => a.Make.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return View(PaginatedList<Vehicle>.Create(AllVehicle, pageNumber ?? 1, pageSize) );
           
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
            if (!ModelState.IsValid)
            {
              return View(models);
            }

           bool result =  await vehicleServices.AddVehicleAsync(models);

            if (result == false)
            {
                ModelState.AddModelError(nameof(models.Year), YearMassager);
                return View(models);
            }

            return RedirectToAction(nameof(Index));
        } 
    }
}
