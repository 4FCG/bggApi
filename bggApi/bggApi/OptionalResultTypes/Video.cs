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
            //TODO : Set properties
        }
    }
}
