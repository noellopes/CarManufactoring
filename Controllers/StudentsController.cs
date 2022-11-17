using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RicardoSousaDetails()
        {
            return View();
        }

        public IActionResult RuiCondessoDetails()
        {
            return View();
        }
    }
}
