using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HRMS.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace HRMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LogOff();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                AppUser user = userManager.Find(login.Email, login.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    //use the instance that has been created. 
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);
                    if(userManager.IsInRole(user.Id, "admin"))
                        return Redirect(Url.Action("Index", "Admin"));
                    else
                        return Redirect(Url.Action("Index", "Employee"));
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View("Index");
        }
        [Authorize]
        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult TestView()
        {
            return View();
        }

    }
}