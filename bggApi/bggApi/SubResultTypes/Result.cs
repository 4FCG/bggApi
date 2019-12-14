using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi
{
    public class Result
    {
        public string Value { get; set; }

        public int Numvotes { get; set; }

        public string Level { get; set; }

        public Result(XmlNode node)
        {

        }
    }
}
