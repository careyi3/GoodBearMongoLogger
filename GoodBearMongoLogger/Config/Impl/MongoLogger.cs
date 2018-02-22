using System.Collections.Generic;

namespace GoodBearMongoLogger.Config.Impl
{
    public class MongoLogger
    {

        public MongoLogger(MongoConnection mongoConnection, ICollection<Logger> loggers)
        {
            MongoConnection = mongoConnection;
            Loggers = loggers;
        }

        public MongoConnection MongoConnection { get; set; }

        public ICollection<Logger> Loggers  { get; set; }

    }
}
