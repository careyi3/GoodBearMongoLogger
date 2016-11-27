using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace GoodBearMongoLogger.Config.Impl
{
    public class Loggers : ConfigurationElementCollection
    {
        public new Logger this[string name]
        {
            get
            {
                if (IndexOf(name) < 0) return null;

                return (Logger)BaseGet(name);
            }
        }

        public Logger this[int index]
        {
            get { return (Logger)BaseGet(index); }
        }

        public ICollection<Logger> GetLoggers()
        {
            List<Logger> loggers = new List<Logger>();
            foreach (var key in this.BaseGetAllKeys())
            {
                loggers.Add((Logger)BaseGet(key));
            }
            return loggers;
        }

        public int IndexOf(string name)
        {
            name = name.ToLower();

            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].DatabaseName.ToLower() == name)
                    return idx;
            }
            return -1;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new Logger();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Logger)element).DatabaseName;
        }

        protected override string ElementName
        {
            get { return "logger"; }
        }

    }
}


