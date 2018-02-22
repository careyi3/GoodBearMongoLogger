using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Autofac.Exceptions
{
    internal class FailedToBuildLoggerAutofacModuleException : Exception
    {
        public FailedToBuildLoggerAutofacModuleException() { }

        public FailedToBuildLoggerAutofacModuleException(string message) : base(message) { }

        public FailedToBuildLoggerAutofacModuleException(string message, Exception innerException) : base(message, innerException) { }
    }
}
