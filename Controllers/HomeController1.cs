using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
