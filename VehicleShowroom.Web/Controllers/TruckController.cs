using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Services.Data.Interfaces;

namespace VehicleShowroom.Web.Controllers
{
    
    using static VehicleShowroom.Common.EntityValidationMessages;
    [Authorize]
    public class TruckController : Controller
    {
        
        private readonly ITruckServices truckServices;
        public TruckController( ITruckServices _truckServices)
        {
            truckServices = _truckServices;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await truckServices
                .GetAllTrucksAsync();
                
            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var truck = await truckServices
                .GetTruckDetailsAsync(id);
            if (truck == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await truckServices
                .GetTruckForEditAsync(id);

            if (vehicle == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(TruckEditViewModel models)
        {
            
            if (!ModelState.IsValid)
            {
                return View(models);
            }

            var result = await truckServices
                .EditTruckAsync(models);

            if (result == false)
            {
                ModelState.AddModelError(nameof(models.Year), YearMassager);
                return View(models); ;
            }
            

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await truckServices
                .GetTruckForDeleteAsync(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ConfirmedDelete(int id)
        {
            bool vehicle = await truckServices
                .ConfirmDeleteAsync(id);

            if (vehicle == false)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
