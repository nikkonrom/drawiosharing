using System.Collections.Generic;

namespace ITechArt.DrawIoSharing.Foundation.UserManagement
{
    public class SignUpResult
    {
        public IReadOnlyCollection<SignUpError> Errors { get; private set; }

        public bool IsSuccessful { get; private set; }


        private SignUpResult(IReadOnlyCollection<SignUpError> errors, bool isSuccessful)
        {
            Errors = errors;
            IsSuccessful = isSuccessful;
        }


        public static SignUpResult CreateSuccessful()
        {
            return new SignUpResult(new List<SignUpError>(), true);
        }

        public static SignUpResult CreateUnsuccessful(IReadOnlyCollection<SignUpError> errors)
        {
            return new SignUpResult(errors, false);
        }
    }
}
