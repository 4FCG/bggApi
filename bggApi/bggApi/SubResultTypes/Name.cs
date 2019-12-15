using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi
{
    public class Name
    {
        public string Type { get; set; }

        public int Sortindex { get; set; }

        public string Value { get; set; }

        public Name(XmlNode node)
        {
            Type = node.Attributes["type"].Value.ToString();
            Value = node.Attributes["value"].Value.ToString();
            Sortindex = Convert.ToInt32(node.Attributes["sortindex"].Value);
        }
    }
}
