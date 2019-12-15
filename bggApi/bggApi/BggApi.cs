using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace bggApi
{
    public class BggApi
    {
        private readonly WebClient client;
        private readonly string apiBaseAddress = "https://www.boardgamegeek.com/xmlapi2/";

        public BggApi()
        {
            this.client = new WebClient
            {
                BaseAddress = this.apiBaseAddress
            };
        }

        public List<Thing> GetThing(int id, bool versions = false)
        {
            string requestString = apiBaseAddress + "thing?id=" + id + (versions ? "&versions=1" : "");
            return ParseThing(requestString);
        }
        //Overload function GetThing, to take multiple id's in a list
        public List<Thing> GetThing(List<int> id, bool versions = false)
        {
            string requestString = apiBaseAddress + "thing?id=" + String.Join(',', id) + (versions ? "&versions=1" : "");
            return ParseThing(requestString);
        }

        private List<Thing> ParseThing(string requestString)
        {
            string resultString = client.DownloadString(requestString);
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(resultString);
            XmlNode itemsRoot = xmlData.SelectSingleNode("items");

            List<Thing> result = new List<Thing>();

            foreach (XmlNode node in itemsRoot.SelectNodes("item"))
            {
                Thing thing = new Thing(node);
                result.Add(thing);
            }
            return result;
        }
    }
}
