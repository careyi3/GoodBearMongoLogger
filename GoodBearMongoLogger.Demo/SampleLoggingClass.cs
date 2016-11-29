using GoodBearMongoLogger.Logging.Interfaces;
using GoodBearMongoLogger.Logging.Enum;
using GoodBearMongoLogger.Autofac;

namespace GoodBearMongoLogger.Demo
{
    public class SampleLoggingClass
    {
        private ILogger _logger;

        public SampleLoggingClass(ILoggerWrapper loggerWrapper)
        {
            _logger = loggerWrapper.GetLogger("Test");
        }

        public void DoStuff()
        {
            _logger.Log(LogLevel.INFO, "Done stuff");
        }

    }
}
