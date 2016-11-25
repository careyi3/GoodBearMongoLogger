using System;
using GoodBearMongoLogger.Logging.Interfaces;
using GoodBearMongoLogger.Logging.Enum;

namespace GoodBearMongoLogger.Logging.Impl
{
    internal class Logger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            throw new NotImplementedException();
        }

        public void Log(LogLevel level, string message, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
