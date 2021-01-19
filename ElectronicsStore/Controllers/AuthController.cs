using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicsStore.Models;
using ES.BusinessLayer;
using ES.BusinessLayer.Interfaces;
using ES.Domain.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

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
    
        [AllowAnonymous]
        public ActionResult Login()
        {
            return PartialView("_LoginPartial");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<LoginModel, ULoginData>());
                var mapper = new Mapper(config);
                var data = mapper.Map<ULoginData>(model);
                data.LoginIP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                data.LoginDate = DateTime.Now;
                var result = user.UserLogin(data);
                if (result.Status)
                {
                    var userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,model.Email),
                        new Claim(ClaimTypes.DateOfBirth, DateTime.Now.ToString()),
                        new Claim(ClaimTypes.Role, result.Role.ToString())
                    };
                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                    var authProperties = new AuthenticationProperties
                    { 
                        AllowRefresh = true,
                        IsPersistent = true
                    };
                    var userPrincipal = new ClaimsPrincipal(claimsIdentity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperties);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }
            }

            return View("Login", model);
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
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("Register", model);
                }
            }

            return View("Register", model);
        }

        public ActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
