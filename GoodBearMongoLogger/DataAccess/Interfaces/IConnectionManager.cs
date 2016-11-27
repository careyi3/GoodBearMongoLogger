using MongoDB.Driver;

namespace GoodBearMongoLogger.DataAccess.Interfaces
{
    internal interface IConnectionManager
    {
        IMongoClient MongoClient { get; }
    }
}
