using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Autofac.Exceptions
{
    internal class FailedToCreateLoggerAutofacModuleException : Exception
    {
        public FailedToCreateLoggerAutofacModuleException() { }

        public FailedToCreateLoggerAutofacModuleException(string message) : base(message) { }

        public FailedToCreateLoggerAutofacModuleException(string message, Exception innerException) : base(message, innerException) { }
    }
}
