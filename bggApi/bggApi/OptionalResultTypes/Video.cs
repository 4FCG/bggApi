using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi.OptionalResultTypes
{
    public class Video
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Category { get; private set; }
        public string Language { get; private set; }
        public string Link { get; private set; }
        public string Username { get; private set; }
        public int Userid { get; private set; }
        public string Postdate { get; private set; }

        public Video(XmlNode node)
        {
            //TODO check if not null
            Id = Convert.ToInt32(node.Attributes["id"].Value);
            Title = node.Attributes["title"].ToString();
            Category = node.Attributes["category"].ToString();
            Language = node.Attributes["language"].ToString();
            Link = node.Attributes["link"].ToString();
            Username = node.Attributes["username"].ToString();
            Userid = Convert.ToInt32(node.Attributes["userid"].Value);
            Postdate = node.Attributes["postdate"].ToString(); //TODO make it a datetime
        }
    }
}
