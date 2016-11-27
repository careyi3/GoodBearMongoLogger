using MongoDB.Bson;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Services.Interfaces
{
    internal interface IDataAccessService
    {
        Task SaveAsync(BsonDocument data, string targetDatabase, string targetCollection);
    }
}
