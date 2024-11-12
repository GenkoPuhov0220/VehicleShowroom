using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VehicleShowroom.Web.ViewModels;

namespace VehicleShowroom.Web.Controllers
{
    public class HomeController : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            return View();
        }

       
    }
}
