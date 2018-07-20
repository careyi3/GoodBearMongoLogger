using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Config.Interfaces
{
    public interface IMongoConfig
    {
        string Username { get; set; }

        string Password { get; set; }

        string AuthDatabase { get; set; }

        string Host { get; set; }

        int Port { get; set; }
    }
}
