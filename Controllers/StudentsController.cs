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

        public IActionResult RodrigoLourencoDetails()
        {
            return View();
        }

        public IActionResult LuisBarrosDetails() { return View(); }

        public IActionResult MustafaBukhariDetails()
        {
            return View();
        }

        public IActionResult TomasEstevesDetails()
        {
            return View();
        }

        public IActionResult RicardoSousaDetails()
        {
            return View();
        }
        
        public IActionResult RicardoAndradeDetails() {
         return View();
        }

        public IActionResult PauloProencaDetails()
        {
            return View();
        }

        public IActionResult RuiCondessoDetails()
        {
            return View();
        }
        public IActionResult PedroMatosDetails()
        {
            return View();
        }
        public IActionResult GuilhermeAlvesDetails()
        {
            return View();
        }
        public IActionResult TelmoMoraisDetails()
        {
            return View();
        }
        public IActionResult FabioAbreuDetails()
        {
            return View();
        }
    }
}