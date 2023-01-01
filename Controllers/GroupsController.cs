using CarManufactoring.ViewModels;
using CarManufactoring.ViewModels.Group1;
using Microsoft.AspNetCore.Mvc;
using CarManufactoring.ViewModels.Group3;
using CarManufactoring.ViewModels.Group4;
using CarManufactoring.ViewModels.Group6;

namespace CarManufactoring.Controllers {
    public class GroupsController : Controller {
        public IActionResult Index() {
            var groups = GroupsStudents.Groups.OrderBy(g => g.Number);
           

            return View(groups);
        }

        // GET: Group/Details
        public IActionResult Details(string number)
        {
            if(number == "1")
            {
                var docs = Group1Documents.GroupDocuments;

                docs.Sort((a, b) => a.Name.CompareTo(b.Name));

                return View($"Details{number}", docs);
            }

            if(number == "3")
            {
                var docs = Group3Documents.G3Documents;

                docs.Sort((a, b) => a.Name.CompareTo(b.Name));

                return View($"Details{number}", docs);
            }

            if (number == "4")
            {
                var docs = Group4Documents.GroupDocuments;

                docs.Sort((a, b) => a.Name.CompareTo(b.Name));

                return View($"Details{number}", docs);
            }
            

            if (number == "6")
            {
                var docs = Group6Documents.GroupDocuments;

                docs.Sort((a, b) => a.Name.CompareTo(b.Name));

                return View($"Details{number}", docs);
            }
            return View($"Details{number}");
        }

        
    }
}
