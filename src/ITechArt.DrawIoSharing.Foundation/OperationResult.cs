using System;
using System.Collections.Generic;

namespace ITechArt.DrawIoSharing.Foundation
{
    public class OperationResult<TErrors> where TErrors : struct, IConvertible 
    {
        public IReadOnlyCollection<TErrors> Errors { get;}

        public bool IsSuccessful { get;}


        private OperationResult(IReadOnlyCollection<TErrors> errors, bool isSuccessful)
        {
            Errors = errors;
            IsSuccessful = isSuccessful;
        }


        public static OperationResult<TErrors> CreateSuccessful()
        {
            return new OperationResult<TErrors>(new List<TErrors>(), true);
        }

        public static OperationResult<TErrors> CreateUnsuccessful(IReadOnlyCollection<TErrors> errors)
        {
            return new OperationResult<TErrors>(errors, false);
        }
    }
}
