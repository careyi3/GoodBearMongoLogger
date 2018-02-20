using GoodBearMongoLogger.Logging.Interfaces;

namespace GoodBearMongoLogger.Autofac
{
    public interface ILoggerWrapper
    {
        ILogger GetLogger(string loggerName);
    }
}
