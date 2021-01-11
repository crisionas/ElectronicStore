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
        public IActionResult Login()
        {
            return PartialView("_LoginPartial");
        }
        
        public IActionResult Register()
        {
            return PartialView("_RegisterPartial");
        }
        public ActionResult CreateEdit(int? id)
        {
            UserDto model = new UserDto();
            model.IsActive = true;
            if (id.HasValue)
            {
                //Write your get user details code here.  
            }
            return PartialView("_CreateEdit", model);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateEdit(UserDto model)
        {
            //validate user  
            if (!ModelState.IsValid)
                return PartialView("_CreateEdit", model);


            //save user into database   
            return RedirectToAction("Index");
        }
    }
}
