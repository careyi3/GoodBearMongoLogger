using MongoDB.Bson;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Services.Interfaces
{
    internal interface IDataAccessService
    {
        void Save(BsonDocument data, string targetDatabase, string targetCollection);
    }
}
