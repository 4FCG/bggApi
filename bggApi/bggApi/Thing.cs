using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace bggApi
{
    public partial class Thing
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

            //Boardgame properties
            Yearpublished = Convert.ToInt32(node["yearpublished"].GetAttribute("value"));
            Minplayers = Convert.ToInt32(node["minplayers"].GetAttribute("value"));
            Maxplayers = Convert.ToInt32(node["maxplayers"].GetAttribute("value"));
            Playingtime = Convert.ToInt32(node["playingtime"].GetAttribute("value"));
            Maxplaytime = Convert.ToInt32(node["maxplaytime"].GetAttribute("value"));
            Minplaytime = Convert.ToInt32(node["minplaytime"].GetAttribute("value"));
            Minage = Convert.ToInt32(node["minage"].GetAttribute("value"));
            try
            {
                Polls = node.SelectNodes("poll").Cast<XmlNode>().Select(node => new Poll(node)).ToList();
            }
            catch (ArgumentNullException)
            {
                Polls = new List<Poll>();
            }

            //Rpgissue properties
            Datepublished = node["datepublished"].GetAttribute("value").ToString();
            Issueindex = Convert.ToInt32(node["issueindex"].GetAttribute("value"));

            //Rpgitem properties
            //TODO: Is seriescode a string or an int?
            Seriescode = Convert.ToInt32(node["seriescode"].GetAttribute("value"));

            //Videogame properties
            Releasedate = node["releasedate"].GetAttribute("value").ToString();
        }
    }
}
