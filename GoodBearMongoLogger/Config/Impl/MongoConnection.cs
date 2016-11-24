using System.Configuration;
using GoodBearMongoLogger.Config.Interfaces;

namespace GoodBearMongoLogger.Config.Impl
{
    public class MongoConnection : ConfigurationElement,IMongoConnection
    {
        [ConfigurationProperty("username", DefaultValue = "mongoadmin", IsRequired = true)]
        public string Username
        {
            get
            {
                return (string)this["username"];
            }
            set
            {
                this["username"] = value;
            }
        }

        [ConfigurationProperty("password", DefaultValue = "mongoadmin", IsRequired = true)]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }

        [ConfigurationProperty("authDatabase", DefaultValue = "admin", IsRequired = true)]
        public string AuthDatabase
        {
            get
            {
                return (string)this["authDatabase"];
            }
            set
            {
                this["authDatabase"] = value;
            }
        }

        [ConfigurationProperty("host", DefaultValue = "localhost", IsRequired = true)]
        public string Host
        {
            get
            {
                return (string)this["host"];
            }
            set
            {
                this["host"] = value;
            }
        }

        [ConfigurationProperty("port", DefaultValue = "27017", IsRequired = true)]
        public string Port
        {
            get
            {
                return (string)this["port"];
            }
            set
            {
                this["port"] = value;
            }
        }
    }
}
