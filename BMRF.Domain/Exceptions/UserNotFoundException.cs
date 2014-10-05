using System;
using System.Runtime.Serialization;

namespace BMRF.Domain.Exceptions
{
    [Serializable]
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base() { }

        public UserNotFoundException(string message)
            : base(message) { }

        public UserNotFoundException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public UserNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }

        public UserNotFoundException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected UserNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
