using System.Configuration;

namespace GoodBearMongoLogger.Config.Impl
{
    public class MongoLogger : ConfigurationSection
    {
        [ConfigurationProperty("mongoConnection", IsRequired = false)]
        public MongoConnection MongoConnection
        {
            get
            {
                return (MongoConnection)base["mongoConnection"];
            }
        }

        [ConfigurationProperty("loggers", IsDefaultCollection = false, IsRequired = true)]
        public Loggers Loggers
        {
            get
            {
                return (Loggers)base["loggers"];
            }
    
        }
        
    }
}
