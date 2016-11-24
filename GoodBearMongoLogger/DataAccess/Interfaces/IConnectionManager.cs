using MongoDB.Driver;

namespace GoodBearMongoLogger.DataAccess.Interfaces
{
    internal interface IConnectionManager
    {
        MongoClient MongoClient { get; }
    }
}
