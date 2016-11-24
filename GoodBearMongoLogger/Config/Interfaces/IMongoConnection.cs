using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Config.Interfaces
{
    public interface IMongoConnection
    {
        string Username { get; set; }
        string Password { get; set; }
        string AuthDatabase { get; set; }
        string Host { get; set; }
        string Port { get; set; }
    }
}
