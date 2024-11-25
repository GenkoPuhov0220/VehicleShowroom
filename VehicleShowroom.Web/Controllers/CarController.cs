using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Services.Data.Interfaces;
using VehicleShowroom.Web;


namespace VehicleShowroom.Web.Controllers
{
    using static VehicleShowroom.Common.EntityValidationConstants;
    public class CarController : Controller
    {
        private readonly VehicleDbContext context;
        private readonly ICarServices carServices;
        public CarController(VehicleDbContext _context, ICarServices _carServices)
        {
            context = _context;
            carServices = _carServices;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await carServices
                .GetAllVehiclesAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var car = await carServices.GetCarDetailsAsync(id);
            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await carServices.GetCarForEditAsync(id);
            if (vehicle == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarEditViewModel models)
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

            var car = await carServices.EditCarAsync(models);
            if (car == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await carServices.GetCarForDeleteAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmedDelete( int id)
        {
            var vehicle = await carServices.ConfirmDeleteAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
