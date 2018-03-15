using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITechArt.DrawIoSharing.Repositories;
using Microsoft.AspNet.Identity.Owin;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private UserManager UserManager => HttpContext.GetOwinContext().GetUserManager<UserManager>();


        public ActionResult Index()
        {
            var users = HttpContext.GetOwinContext().GetUserManager<UserManager>().Users;
            return View(users);
        }
    }
}