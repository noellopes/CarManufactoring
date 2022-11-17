using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JuanSilvaDetails()
        { 
            return View(); 
        }

        public IActionResult JucimarCabralDetails()
        {
            return View();
        }

        public IActionResult RafaelaLopesDetails()
        {
            return View();
        }

    }
}
