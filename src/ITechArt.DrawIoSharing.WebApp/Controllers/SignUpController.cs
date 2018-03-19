using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation;
using ITechArt.DrawIoSharing.Foundation.Services;
using ITechArt.DrawIoSharing.WebApp.Models;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity.Owin;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserService<User> _userService;


        public SignUpController(ILogger logger, IUserService<User> userService)
        {
            _logger = logger;
            _userService = userService;
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
                var result = await _userService.CreateUserAsync(user, model.Password);

                if (result.IsSuccessful)
                {
                    _logger.Info($"User registered with UserName: {user.UserName}");
                    return RedirectToAction("Index");
                }
                AddErrorsFromResult(result);
            }

            return View(model);
        }

        private void AddErrorsFromResult(SignUpOperationResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}