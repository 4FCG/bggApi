using bggApi.OptionalResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace bggApi
{
    public partial class Thing
    {
        public List<VersionItem> Versions { get; set; }

        public Thing(XmlNode node)
        {
            //Primary properties
            try
            {
                Description = node["description"].InnerText.ToString();
                Image = node["image"].InnerText.ToString();
                Thumbnail = node["thumbnail"].InnerText.ToString();

                Id = Convert.ToInt32(node.Attributes["id"].Value);
                Type = node.Attributes["type"].Value.ToString();

                Names = node.SelectNodes("name").Cast<XmlNode>().Select(node => new Name(node)).ToList();
                Links = node.SelectNodes("link").Cast<XmlNode>().Select(node => new Link(node)).ToList();
            }
            catch (NullReferenceException) {
                throw new Exception("Xml node is of a wrong format or is missing required fields");
            }

            //Boardgame properties
            if (node["yearpublished"] != null && node["minplayers"] != null && node["maxplayers"] != null && node["playingtime"] != null && node["maxplaytime"] != null && node["minplaytime"] != null && node["minage"] != null)
            {
                Yearpublished = Convert.ToInt32(node["yearpublished"].GetAttribute("value"));
                Minplayers = Convert.ToInt32(node["minplayers"].GetAttribute("value"));
                Maxplayers = Convert.ToInt32(node["maxplayers"].GetAttribute("value"));
                Playingtime = Convert.ToInt32(node["playingtime"].GetAttribute("value"));
                Maxplaytime = Convert.ToInt32(node["maxplaytime"].GetAttribute("value"));
                Minplaytime = Convert.ToInt32(node["minplaytime"].GetAttribute("value"));
                Minage = Convert.ToInt32(node["minage"].GetAttribute("value"));
            }
            //TODO : Check null properly
            try
            {
                Polls = node.SelectNodes("poll").Cast<XmlNode>().Select(node => new Poll(node)).ToList();
            }
            catch (ArgumentNullException)
            {
                Polls = new List<Poll>();
            }

            //Rpgissue properties
            if (node["datepublished"] != null && node["issueindex"] != null)
            {
                Datepublished = node["datepublished"].GetAttribute("value").ToString();
                Issueindex = Convert.ToInt32(node["issueindex"].GetAttribute("value"));
            }

            //Rpgitem properties
            //TODO: Is seriescode a string or an int?
            if (node["seriescode"] != null)
            {
                Seriescode = Convert.ToInt32(node["seriescode"].GetAttribute("value"));
            }

            //Videogame properties
            if (node["releasedate"] != null)
            {
                Releasedate = node["releasedate"].GetAttribute("value").ToString();
            }

            //Version information, optional
            if (node["versions"] != null)
            {
                Versions = new List<VersionItem>();
                foreach (XmlNode version in node["versions"].SelectNodes("item"))
                {
                    Versions.Add(new VersionItem(version));
                }
            }
        }
    }
}
