using System.Configuration;

namespace GoodBearMongoLogger.Config.Impl
{
    internal class Logger : ConfigurationElement
    {

        [ConfigurationProperty("databaseName", IsRequired = true, IsKey = true, DefaultValue = "Logs")]
        [StringValidator(MinLength = 1)]
        public string DatabaseName
        {
            get { return (string)this["databaseName"]; }
            set { this["databaseName"] = value; }
        }

        [ConfigurationProperty("loggerName", IsRequired = true, IsKey = true, DefaultValue = "Logger")]
        [StringValidator(MinLength = 1)]      
        public string LoggerName
        {
            get { return (string)this["loggerName"]; }
            set { this["loggerName"] = value; }
        }
        
    }
}