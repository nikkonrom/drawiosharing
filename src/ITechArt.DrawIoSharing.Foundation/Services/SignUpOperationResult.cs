using System;
using System.Collections.Generic;

namespace ITechArt.DrawIoSharing.Foundation.Services
{
    public class SignUpOperationResult
    {
        public IReadOnlyCollection<string> StringErrors { get; }

        public IReadOnlyCollection<SignUpOperationError> Errors { get; }

        public bool IsSuccessful { get; }


        public SignUpOperationResult(IReadOnlyCollection<string> stringErrors, bool isSuccessful)
        {
            StringErrors = stringErrors;
            Errors = ConvertStringErrorsToEnum(StringErrors);
            IsSuccessful = isSuccessful;
        }

        private static IReadOnlyCollection<SignUpOperationError> ConvertStringErrorsToEnum(
            IReadOnlyCollection<string> errors)
        {
            var signUpOperationErrors = new List<SignUpOperationError>();

            foreach (var stringError in errors)
            {
                var innerErrors = stringError.Split(new[] { ". " }, StringSplitOptions.None);

                var errorType = innerErrors[0].Substring(0, innerErrors[0].IndexOf(" ", StringComparison.Ordinal));
                if (errorType == "Name")
                {
                    signUpOperationErrors.Add(SignUpOperationError.UserAlreadyExists);
                }
                else
                {
                    foreach (var innerError in innerErrors)
                    {
                        switch (innerError)
                        {
                            case "Passwords must be at least 6 characters":
                                signUpOperationErrors.Add(SignUpOperationError.ShortPassword);
                                break;
                            case "Passwords must have at least one digit (\'0\'-\'9\')":
                                signUpOperationErrors.Add(SignUpOperationError.NoDigitsPassword);
                                break;
                            case "Passwords must have at least one uppercase (\'A\'-\'Z\').":
                                signUpOperationErrors.Add(SignUpOperationError.NoUppercasePassword);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(innerError), innerError,
                                    "Enum value is out of range");
                        }
                    }
                }
            }

            return signUpOperationErrors;
        }
    }
}
