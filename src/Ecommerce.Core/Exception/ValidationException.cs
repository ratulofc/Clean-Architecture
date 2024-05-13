using System;
using System.Runtime.Serialization;

namespace Ecommerce.Core.Exception
{
    [Serializable]
    public class ValidationException : DomainException
    {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected ValidationException( SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
