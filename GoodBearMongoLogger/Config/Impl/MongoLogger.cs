using System.Configuration;

namespace GoodBearMongoLogger.Config.Impl
{
    public class MongoLogger : ConfigurationSection
    {
        [ConfigurationProperty("mongoConnection")]
        public MongoConnection MongoConnection
        {
            get
            {
                return (MongoConnection)base["mongoConnection"];
            }
        }

        [ConfigurationProperty("loggers", IsDefaultCollection = false)]
        public Loggers Loggers
        {
            get
            {
                return (Loggers)base["loggers"];
            }
    
        }
        
    }
}
