using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi.SubResultTypes
{
    public class HotItem
    {
        public int Id { get; private set; }
        public int Rank { get; private set; }
        public string Thumbnail { get; private set; }
        public string Name { get; private set; }
        public string Yearpublished { get; private set; }

        public HotItem (XmlNode node)
        {
            Id = Convert.ToInt32(node.Attributes["id"].Value);
            Rank = Convert.ToInt32(node.Attributes["rank"].Value);

            Thumbnail = node["thumbnail"].GetAttribute("value").ToString();
            Name = node["name"].GetAttribute("value").ToString();
            if (node["yearpublished"] != null)
            {
                Yearpublished = node["yearpublished"].GetAttribute("value").ToString();
            }
        }
    }
}
