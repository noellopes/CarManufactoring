﻿using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Controllers {
    public class StudentsController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult MustafaBukhariDetails() {
            return View();
        }
    }
}
