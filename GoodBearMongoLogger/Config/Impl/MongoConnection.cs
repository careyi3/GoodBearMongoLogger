using System.Configuration;
using GoodBearMongoLogger.Config.Interfaces;

namespace GoodBearMongoLogger.Config.Impl
{
    public class MongoConnection : ConfigurationElement,IMongoConnection
    {
        [ConfigurationProperty("username", DefaultValue = "mongoadmin", IsRequired = true)]
        [StringValidator(MinLength = 1)]
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
        [StringValidator(MinLength = 1)]
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
        [StringValidator(MinLength = 1)]
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
        [StringValidator(MinLength = 1)]
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

        [ConfigurationProperty("port", DefaultValue = (int)27017, IsRequired = true)]
        [IntegerValidator(MinValue = 0, MaxValue = 65535, ExcludeRange = false)]
        public int Port
        {
            get
            {
                return (int)this["port"];
            }
            set
            {
                this["port"] = value;
            }
        }
    }
}
