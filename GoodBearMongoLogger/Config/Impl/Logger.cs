using System.Configuration;

namespace GoodBearMongoLogger.Config.Impl
{
    public class Logger : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]       
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }  
    }
}