using Autofac.Features.Indexed;
using GoodBearMongoLogger.Logging.Interfaces;

namespace GoodBearMongoLogger.Autofac
{
    internal class LoggerWrapper : ILoggerWrapper
    {
        private IIndex<string, ILogger> _index;

        public LoggerWrapper(IIndex<string, ILogger> index)
        {
            _index = index;
        }

        public ILogger GetLogger(string loggerName)
        {
            return _index[loggerName];
        }
    }
}
