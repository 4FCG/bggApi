using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi.OptionalResultTypes
{
    public class Comment
    {
        public string Username { get; private set; }

        public string Rating { get; private set; }

        public string Value { get; private set; }

        public Comment(XmlNode node)
        {
            Username = node.Attributes["username"].Value.ToString();
            Rating = node.Attributes["rating"].Value.ToString();
            Value = node.Attributes["value"].Value.ToString();
        }
    }
}
