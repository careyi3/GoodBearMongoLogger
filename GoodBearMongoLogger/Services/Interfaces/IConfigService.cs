using GoodBearMongoLogger.Config.Impl;

namespace GoodBearMongoLogger.Services.Interfaces
{
    internal interface IConfigService
    {
        MongoLogger MongoLoggerConfig { get; }
    }
}
