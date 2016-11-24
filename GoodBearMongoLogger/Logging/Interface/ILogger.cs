using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodBearMongoLogger.Logging.Enum;

namespace GoodBearMongoLogger.Logging.Interface
{
    interface ILogger
    {
        void Log(LogLevel level, string message, Exception exception);
        void Log(LogLevel level, string message);
    }
}
