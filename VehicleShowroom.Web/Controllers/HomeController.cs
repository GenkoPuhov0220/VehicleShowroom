using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VehicleShowroom.Web.ViewModels;

namespace VehicleShowroom.Web.Controllers
{
    public class HomeController : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Messege"] = "Welcome to the VehicleShowroom";
            return View();
        }

       
    }
}
