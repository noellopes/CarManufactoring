using CarManufactoring.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Controllers {
    public class GroupsController : Controller {
        public IActionResult Index() {
            var groups = GroupsStudents.Groups.OrderBy(g => g.Number);

            return View(groups);
        }
        //get: Groups/Grupo6details
        public IActionResult Details(string number) {
            return View($"Details{number}");
        }

    }
}
