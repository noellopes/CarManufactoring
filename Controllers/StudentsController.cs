using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Controllers {
    public class StudentsController : Controller {
        public IActionResult Index() {
            return View();
        }
        //get: Students/AnaVidalDetails
        public IActionResult AnaVidalDetails()
        {
            return View();
        }
    }
}
