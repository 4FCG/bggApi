using bggApi.SubResultTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace bggApi.OptionalResultTypes
{
    public class Statistics
    {
        //TODO : Verify properties
        public int Usersrated { get; private set; }
        public double Average { get; private set; }
        public double Bayesaverage { get; private set; }
        public List<Rank> Ranks { get; } = new List<Rank>();
        public double Stddev { get; private set; }
        public double Median { get; private set; }
        public int Owned { get; private set; }
        public int Trading { get; private set; }
        public int Wanting { get; private set; }
        public int Wishing { get; private set; }
        public int Numcomments { get; private set; }
        public int Numweights { get; private set; }
        public double Averageweight { get; private set; }
        public Statistics(XmlNode node)
        {
            Usersrated = Convert.ToInt32(node["usersrated"].GetAttribute("value"));
            Average = Convert.ToDouble(node["average"].GetAttribute("value"));
            Bayesaverage = Convert.ToDouble(node["bayesaverage"].GetAttribute("value"));
            Stddev = Convert.ToDouble(node["stddev"].GetAttribute("value"));
            Median = Convert.ToDouble(node["median"].GetAttribute("value"));
            Owned = Convert.ToInt32(node["owned"].GetAttribute("value"));
            Trading = Convert.ToInt32(node["trading"].GetAttribute("value"));
            Wanting = Convert.ToInt32(node["wanting"].GetAttribute("value"));
            Wishing = Convert.ToInt32(node["wishing"].GetAttribute("value"));
            Numcomments = Convert.ToInt32(node["numcomments"].GetAttribute("value"));
            Numweights = Convert.ToInt32(node["numweights"].GetAttribute("value"));
            Averageweight = Convert.ToDouble(node["averageweight"].GetAttribute("value"));

            foreach (XmlNode rank in node["ranks"].SelectNodes("rank"))
            {
                Ranks.Add(new Rank(rank));
            }
        }
    }
}
