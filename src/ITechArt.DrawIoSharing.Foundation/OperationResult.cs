using System.Collections.Generic;

namespace ITechArt.DrawIoSharing.Foundation
{
    public class OperationResult
    {
        public IReadOnlyCollection<string> Errors { get; }

        public bool IsSuccessful { get; }


        public OperationResult(IReadOnlyCollection<string> errors, bool isSuccessful)
        {
            Errors = errors;
            IsSuccessful = isSuccessful;
        }
    }
}
