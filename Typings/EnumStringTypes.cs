using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sw_electron_bridge.Typings
{
    public class EnumStringTypes : Attribute
    {
        public string[] PossibleValues { get; set; }
    }
}
