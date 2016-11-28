using System;

namespace GoodBearMongoLogger.Exceptions
{
    class MongoPersistanceException : Exception
    {
        public MongoPersistanceException() { }

        public MongoPersistanceException(string message) : base(message) { }

        public MongoPersistanceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
