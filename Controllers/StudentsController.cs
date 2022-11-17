using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Controllers {
    public class StudentsController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult RodrigoLourencoDetails()
        {
            return View();
        }
    }
}
