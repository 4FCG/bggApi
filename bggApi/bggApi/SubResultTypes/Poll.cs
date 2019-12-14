using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi
{
    public class Poll
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public int Totalvotes { get; set; }

        public List<Results> ResultsList {get; set;}

        public Poll(XmlNode node)
        {

        }
    }
}
