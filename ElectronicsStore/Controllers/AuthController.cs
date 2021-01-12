using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsStore.Models;

namespace ElectronicsStore.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return PartialView("_LoginPartial");
        }
        
        public ActionResult Register()
        {
            return PartialView("_RegisterPartial");
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
