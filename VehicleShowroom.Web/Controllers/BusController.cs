﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;


namespace VehicleShowroom.Web.Controllers
{
    public class BusController : Controller
    {
        private readonly VehicleDbContext context;
        public BusController(VehicleDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var AllVehicle = await context.Vehicles
                .Include(v => v.Buses)
                .Where(v => v.VehicleType == "Bus".ToLower())
                .ToListAsync();

            return View(AllVehicle);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var bus = await context.Buses
                .Include(c => c.Vehicle)
                .Where(c => c.VehicleId == id)
                .Select(c => new BusDetailsViewModel
                {
                    VehicleId = c.Vehicle.VehicleId,
                    VehicleType = c.Vehicle.VehicleType,
                    Make = c.Vehicle.Make,
                    Model = c.Vehicle.Model,
                    Year = c.Vehicle.Year.ToString(),
                    Price = c.Vehicle.Price,
                    Color = c.Vehicle.Color,
                    FuelType = c.Vehicle.FuelType,
                    ImageUrl = c.Vehicle.ImageUrl,
                    Capacity = c.Capacity,
                    Description = c.Description,
                    HorsePower = c.HorsePower,
                    Transmission = c.Transmission
                })
                .FirstOrDefaultAsync();
            if (bus == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(bus);
        }
    }
}
