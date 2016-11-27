using System.Configuration;

namespace GoodBearMongoLogger.Config.Impl
{
    public class Logger : ConfigurationElement
    {

        [ConfigurationProperty("databaseName", IsRequired = true, IsKey = true, DefaultValue = "")]
        public string DatabaseName
        {
            get { return (string)this["databaseName"]; }
            set { this["databaseName"] = value; }
        }

        [ConfigurationProperty("loggerName", IsRequired = true, IsKey = true, DefaultValue = "")]       
        public string LoggerName
        {
            get { return (string)this["loggerName"]; }
            set { this["loggerName"] = value; }
        }
        
    }
}