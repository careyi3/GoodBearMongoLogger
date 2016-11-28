using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Exceptions
{
    internal class LoggerFactoryNotInitalisedException : Exception
    {
        public LoggerFactoryNotInitalisedException() { }

        public LoggerFactoryNotInitalisedException(string message) : base(message) { }

        public LoggerFactoryNotInitalisedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
