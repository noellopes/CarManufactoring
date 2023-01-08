using Microsoft.AspNetCore.Mvc;
using CarManufactoring.ViewModels;
using CarManufactoring.ViewModels.Group1;
using CarManufactoring.ViewModels.Group3;
using System.Collections.Generic;

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

            if (number == "1704479")
            {
                List<Documents> DiogoDocs = Group1Documents.DiogoDocuments;

                DiogoDocs.Sort((a, b) => a.Name.CompareTo(b.Name));

                return View($"Details{number}",DiogoDocs);
            }

            if(number == "1700331")
            {
                List<Documents> LuisDocs = Group3Documents.LuisDocuments;
                LuisDocs.Sort((a, b) => a.Name.CompareTo(b.Name));
                return View($"Details{number}", LuisDocs);
            }

            if (number == "1701480")
            {
                List<Documents> GuiDocs = Group3Documents.GuiDocuments;
                GuiDocs.Sort((a, b) => a.Name.CompareTo(b.Name));
                return View($"Details{number}", GuiDocs);
            }
            if (number == "1704890")
            {
                List<Documents> pauloDocs = Group1Documents.PauloDocuments;

                pauloDocs.Sort((a, b) => a.Name.CompareTo(b.Name));

                return View($"Details{number}", pauloDocs);
            }

            return View($"Details{number}");
        }
    }
}