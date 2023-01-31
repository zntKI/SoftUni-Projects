using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class AllUsers
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserFullInfo[] Users { get; set; }
    }
}
