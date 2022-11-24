using CarManufactoring.ViewModels;
using CarManufactoring.ViewModels.Group1;
using Microsoft.AspNetCore.Mvc;

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
            return View($"Details{number}");
        }


        
    }
}
