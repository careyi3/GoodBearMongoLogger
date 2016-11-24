using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodBearMongoLogger.Config.Impl;

namespace GoodBearMongoLogger.Services.Interfaces
{
    public interface IConfigService
    {
        MongoLogger MongoLoggerConfig { get; }
    }
}
