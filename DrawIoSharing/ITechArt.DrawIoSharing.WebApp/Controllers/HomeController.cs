using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITechArt.Common;
using ITechArt.Repositories;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.DrawIoSharing.Foundation;
using Ninject;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private IUnitOfWork _unitOfWork;
        private ILogger _logger;


        public HomeController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public ActionResult Index()
        {
            _logger.Debug("App runs!");
            return View(_unitOfWork.Repository<User>().GetAll());
        }
    }
}