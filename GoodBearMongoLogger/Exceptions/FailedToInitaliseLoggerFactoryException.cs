using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Exceptions
{
    internal class FailedToInitaliseLoggerFactoryException : Exception
    {
        public FailedToInitaliseLoggerFactoryException() { }

        public FailedToInitaliseLoggerFactoryException(string message) : base(message) { }

        public FailedToInitaliseLoggerFactoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
