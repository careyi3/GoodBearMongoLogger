using System;

namespace GoodBearMongoLogger.Exceptions
{
    internal class MongoPersistanceException : Exception
    {
        public MongoPersistanceException() { }

        public MongoPersistanceException(string message) : base(message) { }

        public MongoPersistanceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
