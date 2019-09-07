using System;

namespace sw_electron_bridge.Typings
{
    public class RelatedDataType : Attribute
    {
        public Type DataType { get; set; }
    }
}
