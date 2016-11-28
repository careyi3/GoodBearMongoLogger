using System;

namespace GoodBearMongoLogger.Exceptions
{
    internal class FailedToLogException : Exception
    {
        public FailedToLogException() { }

        public FailedToLogException(string message) : base(message) { }

        public FailedToLogException(string message, Exception innerException) : base(message, innerException) { }
    }
}
