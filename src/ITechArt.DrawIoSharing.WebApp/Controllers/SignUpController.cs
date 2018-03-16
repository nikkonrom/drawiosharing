using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation;
using ITechArt.DrawIoSharing.WebApp.Models;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity.Owin;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class SignUpController : Controller
    {
        private ILogger _logger;
        private IUnitOfWork _unitOfWork;

        private IUserService<User> UserService => HttpContext.GetOwinContext().GetUserManager<UserService>();


        public SignUpController(ILogger logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _logger.Info($"{unitOfWork.GetHashCode()}");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User (model.Name, model.Email);
                var result = await UserService.CreateUserAsync(user, model.Password);

                if (result.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }
                AddErrorsFromResult(result);
            }

            return View(model);
        }

        private void AddErrorsFromResult(OperationResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}