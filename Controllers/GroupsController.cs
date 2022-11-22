using CarManufactoring.ViewModels;
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

        //get: Groups/Group4details
        public IActionResult Group4Details()
        {
            return View();
        }

    }
}
