using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Exceptions
{
    class InvalidMongoDBConfigurationException : Exception
    {
        public InvalidMongoDBConfigurationException() { }

        public InvalidMongoDBConfigurationException(string message) : base(message) { }

        public InvalidMongoDBConfigurationException(string message, Exception innerException) : base(message, innerException) { }

    }
}
