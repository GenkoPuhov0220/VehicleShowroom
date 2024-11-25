using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Services.Data.Interfaces;

namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
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
        [HttpPost]
        public async Task<IActionResult> Edit(TruckEditViewModel models)
        {
            bool IsYearValid = DateTime
               .TryParseExact(models.Year, YearFormating, CultureInfo.InvariantCulture, DateTimeStyles.None,
               out DateTime yearValid);

            if (!IsYearValid)
            {
                ModelState.AddModelError(nameof(models.Year), "The Year must be in the following format: dd.MM.yyyy");

            }
            if (!ModelState.IsValid)
            {
                return View(models);
            }

            var truck = await truckServices
                .EditTruckAsync(models);

            if (truck == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
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
        [HttpPost]
        public async Task<IActionResult> ConfirmedDelete(int id)
        {
            var vehicle = await truckServices
                .ConfirmDeleteAsync(id);

            if (vehicle == null)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
