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

        private IUnitOfWork _unitOfWork;



        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            User user1 = new User { Username = "Tom"};
            User user2 = new User { Username = "Sam"};

            _unitOfWork.Repository<User>().Create(user1);
            _unitOfWork.Save();
            

            return View(_unitOfWork.Repository<User>().GetAll());
        }
    }
}