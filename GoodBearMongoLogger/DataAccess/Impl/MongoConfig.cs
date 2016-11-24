using GoodBearMongoLogger.DataAccess.Interfaces;

namespace GoodBearMongoLogger.DataAccess.Impl
{
    internal class MongoConfig : IMongoConfig
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string AuthDatabase { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public MongoConfig(IMongoConfig mongoConfig)
        {
            Username = mongoConfig.Username;
            Password = mongoConfig.Password;
            AuthDatabase = mongoConfig.AuthDatabase;
            Host = mongoConfig.Host;
            Port = mongoConfig.Port;
        }
    }
}
