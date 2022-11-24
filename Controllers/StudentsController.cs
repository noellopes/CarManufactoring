using Microsoft.AspNetCore.Mvc;
using CarManufactoring.ViewModels;
using CarManufactoring.ViewModels.Group1;

namespace CarManufactoring.Controllers {
    public class StudentsController : Controller {
        public IActionResult Index() {
            var students = GroupsStudents.Students.OrderBy(s => s.Group).ThenBy(s => s.Name);
            
            return View(students);
        }

        // GET: Students/Details
        public IActionResult Details(string number) {

            if(number == "1704696")
            {
                List<Documents> tomasDocs = Group1Documents.TomasDocuments;
                
                tomasDocs.Sort((a,b) => a.Name.CompareTo(b.Name));

                return View($"Details{number}", tomasDocs);
            }
            
            if(number == "1704890")
            {
                List<Documents> pauloDocs = Group1Documents.PauloDocuments;

                pauloDocs.Sort((a, b) => a.Name.CompareTo(b.Name));

                return View($"Details{number}", pauloDocs);
            }
            return View($"Details{number}");
        }
    }
}