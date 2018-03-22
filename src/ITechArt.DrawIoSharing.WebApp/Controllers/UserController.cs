using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using ITechArt.DrawIoSharing.WebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;


        private IAuthenticationManager AuthManager => HttpContext.GetOwinContext().Authentication;

        public UserController(ILogger logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        public ActionResult SignIn(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(SignInModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await _userService.FindAsync(model.UserName, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", @"Wrong username or password");
                }
                else
                {
                    ClaimsIdentity claimsIdentity = await _userService.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties()
                    {
                        IsPersistent = false
                    }, claimsIdentity);

                    return Redirect(returnUrl);
                }
            }

            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User(model.Name, model.Email);
                var result = await _userService.SignUpAsync(user, model.Password);

                if (result.IsSuccessful)
                {
                    _logger.Info($"User registered with UserName: {user.UserName}");
                    return RedirectToAction("Index");
                }
                AddErrorsFromResult(result);
            }

            return View(model);
        }


        private void AddErrorsFromResult(SignUpResult result)
        {
            foreach (string error in ConvertSignUpErrorsToString(result.Errors))
            {
                ModelState.AddModelError("", error);
            }
        }

        private static IReadOnlyCollection<string> ConvertSignUpErrorsToString(IReadOnlyCollection<SignUpError> errors)
        {
            var stringErrors = new List<string>();

            foreach (var signUpError in errors)
            {
                switch (signUpError)
                {
                    case SignUpError.ShortPassword:
                        stringErrors.Add(@"Passwords must be at least 6 characters");
                        break;
                    case SignUpError.NoDigitsPassword:
                        stringErrors.Add(@"Passwords must have at least one digit ('0'-'9')");
                        break;
                    case SignUpError.NoUppercasePassword:
                        stringErrors.Add(@"Passwords must have at least one uppercase ('A'-'Z').");
                        break;
                    case SignUpError.UserAlreadyExists:
                        stringErrors.Add(@"User already signed up");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(signUpError), signUpError, @"Enum value is out of range");
                }
            }

            return stringErrors;
        }
    }
}