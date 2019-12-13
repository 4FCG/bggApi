using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi.ThingTypes
{
    public class Boardgameaccessory : Thing
    {
        public int Yearpublished { get; set; }

        public Boardgameaccessory(XmlNode node)
            : base(node)
        {

        }
    }
}
