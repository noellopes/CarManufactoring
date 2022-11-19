using CarManufactoring.ViewModels;
using CarManufactoring.ViewModels.Group1;
using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Controllers {
    public class GroupsController : Controller {
        public IActionResult Index() {
            var groups = GroupsStudents.Groups.OrderBy(g => g.Number);

            return View(groups);
        }
        //get: Groups/Grupo6details
        public IActionResult Grupo6details()
        {
            return View();
        }

        public IActionResult Group1Details()
        {
            

            return View();
        }
        
        public IActionResult Group5Details()
        {
            return View();
        }

        // TODO: Each group should add a page to show their group information and status


        public IActionResult Group7Details()
        {
          return View();
        }
        public IActionResult Group2Details() {

            return View();
        }
        public IActionResult Group3Details()
        {

            return View();
        }

        public IActionResult Group9details()
        {

            return View();
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
