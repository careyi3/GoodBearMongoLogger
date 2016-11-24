using System;
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

        public int IndexOf(string name)
        {
            name = name.ToLower();

            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Name.ToLower() == name)
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
            return ((Logger)element).Name;
        }

        protected override string ElementName
        {
            get { return "logger"; }
        }

    }
}


