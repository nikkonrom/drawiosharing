using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.Authorization;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace ITechArt.DrawIoSharing.Foundation.Authentication
{
    [UsedImplicitly]
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserManager _userManager;
        private readonly IAuthenticationManager _authManager;
        private readonly IAuthorizationService _authorizationService;

        public AuthenticationService(IUserManager userManager, IAuthenticationManager authManager, IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _authManager = authManager;
            _authorizationService = authorizationService;
        }


        public async Task<OperationResult<SignUpError>> SignUpAsync(User user, string password)
        {
            var identityResult = await _userManager.CreateAsync(user, password);
            if (identityResult.Succeeded)
            {
                await SignInUserAsync(user);
                await _authorizationService.SetInitialRoleAsync(user);

                return OperationResult<SignUpError>.CreateSuccessful();
            }
            var errors = ConvertStringErrorsToEnum(identityResult.Errors.ToList());

            return OperationResult<SignUpError>.CreateUnsuccessful(errors);
        }

        public async Task<OperationResult<SignInError>> SignInAsync(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);
            if (user != null)
            {
                await SignInUserAsync(user);

                return OperationResult<SignInError>.CreateSuccessful();
            }
            var errors = new List<SignInError>
            {
                SignInError.WrongUserNameOrPassword
            };

            return OperationResult<SignInError>.CreateUnsuccessful(errors);
        }

        public Task SignOutAsync()
        {
            _authManager.SignOut();

            return Task.CompletedTask;
        }


        private async Task SignInUserAsync(User user)
        {
            var claimsIdentity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authManager.SignOut();
            _authManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, claimsIdentity);
        }

        private static IReadOnlyCollection<SignUpError> ConvertStringErrorsToEnum(IReadOnlyCollection<string> errors)
        {
            var signUpErrors = new List<SignUpError>();
            foreach (var stringError in errors)
            {
                var innerErrors = stringError.Split(new[] { ". " }, StringSplitOptions.None);
                var firstSentence = innerErrors[0];
                var firstWord = firstSentence.Substring(0, firstSentence.IndexOf(" ", StringComparison.Ordinal));
                if (firstWord == @"Name")
                {
                    signUpErrors.Add(SignUpError.UserAlreadyExists);
                }
                else
                {
                    foreach (var innerError in innerErrors)
                    {
                        switch (innerError)
                        {
                            case @"Passwords must be at least 6 characters":
                                signUpErrors.Add(SignUpError.ShortPassword);
                                break;
                            case @"Passwords must have at least one digit ('0'-'9')":
                                signUpErrors.Add(SignUpError.NoDigitsPassword);
                                break;
                            case @"Passwords must have at least one uppercase ('A'-'Z').":
                                signUpErrors.Add(SignUpError.NoUppercasePassword);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(innerError), innerError, @"Enum value is out of range");
                        }
                    }
                }
            }

            return signUpErrors;
        }
    }
}
