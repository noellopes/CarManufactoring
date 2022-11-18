using Microsoft.AspNetCore.Mvc;
using CarManufactoring.ViewModels;

namespace CarManufactoring.Controllers {
    public class StudentsController : Controller {
        public IActionResult Index() {
            var students = GroupsStudents.Students.OrderBy(s => s.Group).ThenBy(s => s.Name);
            
            return View(students);
        }

        // GET: Students/Details
        public IActionResult Details(string number) {
            return View($"Details{number}");
        }
    }
}