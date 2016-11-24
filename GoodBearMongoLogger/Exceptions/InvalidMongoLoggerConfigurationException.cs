using System;

namespace GoodBearMongoLogger.Exceptions
{
    class InvalidMongoLoggerConfigurationException : Exception
    {
        public InvalidMongoLoggerConfigurationException() { }

        public InvalidMongoLoggerConfigurationException(string message) : base(message) { }

        public InvalidMongoLoggerConfigurationException(string message, Exception innerException) : base(message, innerException) { }

    }
}
