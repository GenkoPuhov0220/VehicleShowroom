using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Services.Data;
using VehicleShowroom.Services.Data.Interfaces;


namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationMessages;
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
            
            if (!ModelState.IsValid)
            {
                return View(models);
            }
            bool bus = await busServices.EditBusAsync(models);
            if (bus == false)
            {

                ModelState.AddModelError(nameof(models.Year), YearMassager);
                return View(models);
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
            bool vehicle = await busServices.BusConfirmDeleteAsync(id);
            if (vehicle == false)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
