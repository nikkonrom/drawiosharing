﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using ITechArt.DrawIoSharing.WebApp.Models;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;


        public UserController(ILogger logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        public ActionResult SignIn(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            ViewBag.returnUrl = returnUrl;

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.SignInAsync(model.UserName, model.Password);
                if (result.IsSuccessful)
                {
                    _logger.Info($"User signed in with UserName: {model.UserName}");
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                AddErrorsFromResult(result);
            }

            return View(model);
        }

        public ActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User(model.Name, model.Email);
                var result = await _userService.SignUpAsync(user, model.Password);
                if (result.IsSuccessful)
                {
                    _logger.Info($"User signed up with UserName: {user.UserName}");
                    ViewBag.IsUserSignUp = true;

                    return View("SignUpSuccess");
                }
                AddErrorsFromResult(result);
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> SignOut()
        {
            await _userService.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        private void AddErrorsFromResult(OperationResult<SignUpError> result)
        {
            var stringErrors = ConvertEnumErrorsToString(result.Errors);
            foreach (var error in stringErrors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private void AddErrorsFromResult(OperationResult<SignInError> result)
        {
            var stringErrors = ConvertEnumErrorsToString(result.Errors);
            foreach (var error in stringErrors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private static IReadOnlyCollection<string> ConvertEnumErrorsToString(IReadOnlyCollection<SignUpError> errors)
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

        private static IReadOnlyCollection<string> ConvertEnumErrorsToString(IReadOnlyCollection<SignInError> errors)
        {
            var stringErrors = new List<string>();
            foreach (var signInError in errors)
            {
                switch (signInError)
                {
                    case SignInError.WrongUserNameOrPassword:
                        stringErrors.Add(@"Wrong username or password");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(signInError), signInError, @"Enum value is out of range");
                }
            }

            return stringErrors;
        }
    }
}