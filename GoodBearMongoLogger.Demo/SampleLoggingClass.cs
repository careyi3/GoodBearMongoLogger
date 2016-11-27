using GoodBearMongoLogger.Logging.Interfaces;
using Autofac.Extras.Attributed;

namespace GoodBearMongoLogger.Demo
{
    public class SampleLoggingClass
    {
        private ILogger _logger;

        public SampleLoggingClass([WithKey("Test")]ILogger logger)
        {
            _logger = logger;
        }

    }
}
