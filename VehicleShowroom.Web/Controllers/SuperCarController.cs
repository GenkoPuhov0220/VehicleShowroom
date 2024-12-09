using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Dml;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Services.Data.Interfaces;
using VehicleShowroom.Web;

namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationMessages;
    [Authorize]
    public class SuperCarController : Controller
    {
        private readonly ISuperCarServices superCarServices;
        public SuperCarController(ISuperCarServices _superCarServices)
        {
            superCarServices = _superCarServices;
        }
        public async Task<IActionResult> Index()
        {
          var AllVehicle = await superCarServices
                .GetAllSuperCarAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var superCar = await superCarServices
                .GetSuperCarDetailsAsync(id);

            if (superCar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(superCar);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await superCarServices
                .GetSuperForEditAsync(id);

            if (vehicle == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(SuperCarEditVieModel models)
        {
            
            if (!ModelState.IsValid)
            {
                return View(models);
            }
            bool superCar = await superCarServices.EditCarAsync(models);
            if (superCar == false)
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
            var viewModel = await superCarServices
                .GetSuperCarForDeleteAsync(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ConfirmedDelete( int id)
        {
            bool superCar = await superCarServices
                .ConfirmDeleteAsync(id);

            if (superCar == false)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
