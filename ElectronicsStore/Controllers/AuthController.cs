using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicsStore.Models;
using ES.BusinessLayer;
using ES.BusinessLayer.Interfaces;
using ES.Domain.Models;

namespace ElectronicsStore.Controllers
{
    public class AuthController : Controller
    {
        private IUser user;
        public AuthController()
        {
            var bl = new BusinessManager();
            user = bl.GetUserBL();
        }
    
        public ActionResult Login()
        {
            return PartialView("_LoginPartial");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return PartialView("_RegisterPartial");
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<RegisterModel, URegisterData>());
                var mapper = new Mapper(config);
                var data = mapper.Map<URegisterData>(model);
                data.IP= Request.HttpContext.Connection.RemoteIpAddress.ToString();
                data.RegisteDateTime=DateTime.Now;
                var result = user.UserRegister(data);
                if (result.Status)
                {
                    ViewBag.Message = result.Message;
                    ViewBag.State = result.Status;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("Register", model);
                }
            }

            return View("Register", model);
        }
    }
}
