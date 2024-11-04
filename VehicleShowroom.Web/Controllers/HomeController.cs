using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VehicleShowroom.Web.ViewModels;

namespace VehicleShowroom.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Messege"] = "Welcome to the VehicleShowroom";
            return View();
        }

       
    }
}
