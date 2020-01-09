using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi
{
    public class Results
    {
        public string Numplayers { get; set; }

        public List<Result> ResultList { get; set; }

        public Results(XmlNode node)
        {
            //TODO implement
        }
    }
}
