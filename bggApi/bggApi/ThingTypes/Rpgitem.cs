using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi.ThingTypes
{
    public class Rpgitem : Thing
    {
        public int Yearpublished { get; set; }

        //TODO: is Seriescode an int or a string?
        public int Seriescode { get; set; }
        public Rpgitem(XmlNode node)
            : base(node)
        {

        }
    }
}
