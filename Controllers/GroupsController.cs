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

        // TODO: Each group should add a page to show their group information and status
    }
}
