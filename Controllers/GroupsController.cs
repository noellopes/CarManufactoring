﻿using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Controllers {
    public class GroupsController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Group1Details()
        {
            return View();
        }

        // TODO: Each group should add a page to show their group information and status
    }
}
