using GoodBearMongoLogger.Logging.Interfaces;
using Autofac.Extras.Attributed;
using GoodBearMongoLogger.Logging.Enum;

namespace GoodBearMongoLogger.Demo
{
    public class SampleLoggingClass
    {
        private ILogger _logger;

        public SampleLoggingClass([WithKey("Test")]ILogger logger)
        {
            _logger = logger;
        }

        public void DoStuff()
        {
            _logger.Log(LogLevel.INFO, "Done stuff");
        }

    }
}
