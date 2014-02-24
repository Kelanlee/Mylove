using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataContract
{
    public class DataElement
    {
        public string Name;
        public string Value;
        public string Description;

        public DataElement()
        {
            Name = string.Empty;
            Value = string.Empty;
            Description = string.Empty;
        }
    }
}
