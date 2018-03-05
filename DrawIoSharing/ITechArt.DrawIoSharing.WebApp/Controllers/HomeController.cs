using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITechArt.Repositories;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.DrawIoSharing.Foundation;
using Ninject;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private IRepository<User> _repository;
    
        public HomeController(IRepository<User> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }
    }
}