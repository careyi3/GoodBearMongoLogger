using MongoDB.Driver;

namespace GoodBearMongoLogger.DataAccess.Interfaces
{
    public interface IConnectionManager
    {
        IMongoClient MongoClient { get; }
    }
}
