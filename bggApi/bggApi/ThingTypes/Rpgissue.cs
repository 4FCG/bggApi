using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi.ThingTypes
{
    public class Rpgissue : Thing
    {
        public string Datepublished { get; set; }

        public int Issueindex { get; set; }

        public Rpgissue(XmlNode node)
            : base(node)
        {

        }
    }
}
