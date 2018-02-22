# GoodBearMongoLogger
A .NET logger implementation for logging to MongoDB. GoodBearMongoLogger allows .Net applications to log to a MongoDb database. GoodBearMongoLogger provides a simple way to log exceptions as well as log custom Audit and Event objects to MongoDb.

## Getting Started
To begin using GoodBearMongoLogger start by installing the latest version of the package from [Nuget](https://www.nuget.org/packages/GoodBearMongoLogger) . Using this Library on its own, instances of configuered loggers can be retreived by using a Static Factory implementation. However, if you are using [Autofac](https://autofac.org) as your DI container, then we have a [nuget package](https://www.nuget.org/packages/GoodBearMongoLogger.Autofac) for that too!! 

See below for insturctions on setting up a stand alone instance of GoodBearMongoLogger and an instance using GoodBearMongoLogger.Autofac.