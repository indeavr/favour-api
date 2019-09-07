using System;

namespace sw_electron_bridge.Typings
{
    public class OneOf: Attribute
    {
        public Type[] Types { get; set; }
    }
}
