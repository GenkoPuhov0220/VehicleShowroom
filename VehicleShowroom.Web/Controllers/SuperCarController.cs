using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Dml;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Services.Data.Interfaces;
using VehicleShowroom.Web;

namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    using static VehicleShowroom.Common.EntityValidationMessages;
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
        [HttpPost]
        public async Task<IActionResult> Edit(SuperCarEditVieModel models)
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
            var superCar = await superCarServices.EditCarAsync(models);
            if (superCar == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
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
        [HttpPost]
        public async Task<IActionResult> ConfirmedDelete( int id)
        {
            var superCar = await superCarServices
                .ConfirmDeleteAsync(id);

            if (superCar == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
