using System.Collections.Generic;

namespace ITechArt.DrawIoSharing.Foundation.Services
{
    public class SignUpOperationResult
    {
        public IReadOnlyCollection<string> Errors { get; }

        public bool IsSuccessful { get; }


        public SignUpOperationResult(IReadOnlyCollection<string> errors, bool isSuccessful)
        {
            Errors = errors;
            IsSuccessful = isSuccessful;
        }
    }
}
