using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;


namespace VehicleShowroom.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public  IActionResult Index()
        {
            return View();
        }

       public IActionResult Error(int? statusCode = null)
        {
            if (!statusCode.HasValue)
            {
                return View();
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }
           
            return View("Error500");
        }
    }
}
