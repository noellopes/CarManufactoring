using Microsoft.AspNetCore.Mvc;
using CarManufactoring.ViewModels;

namespace CarManufactoring.Controllers {
    public class StudentsController : Controller {
        public IActionResult Index() {
            var students = GroupsStudents.Students;

            students.Sort((a, b) => a.Group.CompareTo(b.Group));
            
            return View(students);
        }

        // GET: Students/Details
        public IActionResult Details(string number) {
            return View();
        }

        //get: Students/AnaVidalDetails
        public IActionResult AnaVidalDetails() {
            return View();
        }

        //get: Students/JoaoAleixoDetails
        public IActionResult JoaoAleixoDetails() {
            return View();
        }

        public IActionResult RodrigoLourencoDetails() {
            return View();
        }

        public IActionResult LuisBarrosDetails() { return View(); }

        public IActionResult MustafaBukhariDetails() {
            return View();
        }

        public IActionResult TomasEstevesDetails() {
            return View();
        }

        public IActionResult RicardoSousaDetails() {
            return View();
        }

        public IActionResult RicardoAndradeDetails() {
            return View();
        }

        public IActionResult PauloProencaDetails() {
            return View();
        }

        public IActionResult RuiCondessoDetails() {
            return View();
        }
        public IActionResult PedroMatosDetails() {
            return View();
        }
        public IActionResult GuilhermeAlvesDetails() {
            return View();
        }
        public IActionResult TelmoMoraisDetails() {
            return View();
        }
        public IActionResult FabioAbreuDetails() {
            return View();
        }


    }
}