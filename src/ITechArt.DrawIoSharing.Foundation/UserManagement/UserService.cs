using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Foundation.UserManagement
{
    [UsedImplicitly]
    public class UserService : IUserService
    {
        private readonly IUserManager _userManager;


        public UserService(IUserManager userManager)
        {
            _userManager = userManager;
        }


        public async Task<SignUpResult> SignUpAsync(User user, string password)
        {
            var identityResult = await _userManager.CreateAsync(user, password);
            if (identityResult.Succeeded)
            {
                return SignUpResult.CreateSuccessful();
            }
            var errors = ConvertStringErrorsToEnum(identityResult.Errors.ToList());

            return SignUpResult.CreateUnsuccessful(errors);
        }

        public Task<User> FindAsync(string userName, string password)
        {
            return _userManager.FindAsync(userName, password);
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType)
        {
            return await _userManager.CreateIdentityAsync(user, authenticationType);
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
