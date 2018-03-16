using System.Collections.Generic;

namespace ITechArt.DrawIoSharing.Foundation
{
    public class OperationResult
    {
        public IReadOnlyCollection<string> Errors { get; }

        public bool Success { get; }


        public OperationResult(IReadOnlyCollection<string> errors, bool success)
        {
            Errors = errors;
            Success = success;
        }
    }
}
