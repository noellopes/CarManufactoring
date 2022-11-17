using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Controllers {
    public class GroupsController : Controller {
        public IActionResult Index() {
            return View();
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
    }
}
