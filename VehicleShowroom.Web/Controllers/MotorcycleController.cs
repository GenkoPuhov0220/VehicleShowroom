using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.CompilerServices;
using VehicleShowroom.Data;
using VehicleShowroom.Services.Data.Interfaces;

namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    [Authorize]
    public class MotorcycleController : Controller
    {
        private readonly IMotorcycleServices motorcycleServices;
        public MotorcycleController(VehicleDbContext _context,
            IMotorcycleServices _motorcycleServices)
        {
            motorcycleServices = _motorcycleServices;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await motorcycleServices
                .GetAllMotorcycleAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var motorcycle = await motorcycleServices
                .GetMotrocycleDetailsAsync(id);

            if (motorcycle == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(motorcycle);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
           var vehicle = await motorcycleServices
                .GetMotorcycleForEditAsync(id);

            if (vehicle == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(MotorcycleEditViewModel models)
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

            var motorcycle = await motorcycleServices
                .EditMotorcycleAsync(models);

            if (motorcycle == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           var viewModel = await motorcycleServices
                .DeleteMotorcycleAsync(id);

            if (viewModel == null)
            {
                return BadRequest();
            }
           
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ConfirmedDelete( int id)
        {
            var vehicle = await motorcycleServices
                .MotorcycleConfirmDeleteAsync(id);

            if (vehicle == null)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
