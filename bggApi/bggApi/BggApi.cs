using bggApi.SubResultTypes;
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
        /// <summary>
        /// Gets a 'Thing' from the BGG database.
        /// </summary>
        /// <param name="id">The ID of the thing to get.</param>
        /// <param name="versions">Set to true to load versions data.</param>
        /// <returns>Returns a list of Things from the api request.</returns>
        public List<Thing> GetThing(int id, bool versions = false)
        {
            string requestString = apiBaseAddress + "thing?id=" + id + (versions ? "&versions=1" : "");
            return GetThing(requestString);
        }
        //Overload function GetThing, to take multiple id's in a list
        public List<Thing> GetThing(List<int> id, bool versions = false)
        {
            string requestString = apiBaseAddress + "thing?id=" + String.Join(',', id) + (versions ? "&versions=1" : "");
            return GetThing(requestString);
        }
        //TODO : Type for search is not yet functional
        public List<SearchResult> Search(string query, Type type = Type.none, bool exact = false)
        {
            string requestString = apiBaseAddress + "search?query=" + query.Replace(' ', '+') + (type == Type.none ? "" : nameof(type)) + (exact ? "&exact=1" : "");
            return GetSearchresults(requestString);
        }
        //TODO : Overload for multiple types

        private List<SearchResult> GetSearchresults(string requestString)
        {
            List<SearchResult> searchResults = new List<SearchResult>();

            foreach (XmlNode node in GetItems(requestString))
            {
                SearchResult searchResult = new SearchResult(node);
                searchResults.Add(searchResult);
            }

            return searchResults;
        }

        private List<Thing> GetThing(string requestString)
        {
            List<Thing> result = new List<Thing>();

            foreach (XmlNode node in GetItems(requestString))
            {
                Thing thing = new Thing(node);
                result.Add(thing);
            }
            return result;
        }

        private XmlNodeList GetItems(string requestString)
        {
            string resultString = client.DownloadString(requestString);
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(resultString);
            XmlNode itemsRoot = xmlData.SelectSingleNode("items");

            return itemsRoot.SelectNodes("item");
        }
    }
}
