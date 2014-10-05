using System;
using System.Runtime.Serialization;

namespace BMRF.Domain.Exceptions
{
    [Serializable]
    public class InventoryParseException : Exception
    {
        public InventoryParseException()
            : base() { }

        public InventoryParseException(string message)
            : base(message) { }

        public InventoryParseException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public InventoryParseException(string message, Exception innerException)
            : base(message, innerException) { }

        public InventoryParseException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected InventoryParseException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
