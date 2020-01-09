using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi.SubResultTypes
{
    public class SearchResult
    {
        public int Id { get; private set; }

        public string Type { get; private set; }

        public Name Name { get; private set; }

        public int? Yearpublished { get; private set; }

        public SearchResult(XmlNode node)
        {
            Id = Convert.ToInt32(node.Attributes["id"].Value);
            Type = node.Attributes["type"].Value.ToString();

            if (node["yearpublished"] != null)
            {
                Yearpublished = Convert.ToInt32(node["yearpublished"].GetAttribute("value"));
            }
            
            if (node["name"] != null)
            {
                Name = new Name(node["name"]);
            }
        }
    }
}
