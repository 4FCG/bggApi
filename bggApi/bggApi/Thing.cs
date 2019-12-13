using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace bggApi
{
    public class Thing
    {
        public int Id { get; private set; }

        public string Type { get; private set; }

        public string Thumbnail { get; private set; }

        public string Image { get; private set; }

        public List<Name> Names { get; private set; }

        public string Description { get; private set; }

        public List<Link> Links { get; private set; }

        public Thing(XmlNode node)
        {
            Description = node["description"].InnerText.ToString();
            Image = node["image"].InnerText.ToString();
            Thumbnail = node["thumbnail"].InnerText.ToString();

            Id = Convert.ToInt32(node.Attributes["id"].Value);
            Type = node.Attributes["type"].Value.ToString();

            try
            {
                Names = node.SelectNodes("name").Cast<XmlNode>().Select(node => new Name(node)).ToList();
            }
            catch (ArgumentNullException) {
                Names = new List<Name>();
            }

            try
            {
                Links = node.SelectNodes("link").Cast<XmlNode>().Select(node => new Link(node)).ToList();
            }
            catch (ArgumentNullException)
            {
                Links = new List<Link>();
            }
        }
    }
}
