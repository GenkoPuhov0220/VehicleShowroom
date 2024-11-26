using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Services.Data;
using VehicleShowroom.Services.Data.Interfaces;


namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    [Authorize]
    public class BusController : Controller
    {
        private readonly IBusServices busServices;
        public BusController(IBusServices _busServices)
        {
            busServices = _busServices;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await busServices
                .GetAllBusesAsync();
               
            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var bus = await busServices.GetBusDetailsAsync(id); 

            if (bus == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(bus);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await busServices.GetBusForEditAsync(id);

            if (vehicle == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(BusEditViewModel models)
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
            var bus = await busServices.EditBusAsync(models);
            if (bus == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await busServices.DeleteBusAsync(id);
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
            var vehicle = await busServices.BusConfirmDeleteAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
