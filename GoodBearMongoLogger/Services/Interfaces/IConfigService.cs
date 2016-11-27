using GoodBearMongoLogger.Config.Impl;

namespace GoodBearMongoLogger.Services.Interfaces
{
    public interface IConfigService
    {
        MongoLogger MongoLoggerConfig { get; }
    }
}
