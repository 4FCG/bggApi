﻿using bggApi.SubResultTypes;
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
        public List<Thing> GetThing(int id, bool versions = false, bool videos = false, bool comments = false)
        {
            string requestString = apiBaseAddress + "thing?id=" + id + (versions ? "&versions=1" : "") + (videos ? "&videos=1" : "") + (comments ? "&comments=1" : "");
            return GetThing(requestString);
        }
        // TODO optimize optional parameters
        //Overload function GetThing, to take multiple id's in a list
        public List<Thing> GetThing(List<int> id, bool versions = false, bool videos = false, bool comments = false)
        {
            string requestString = apiBaseAddress + "thing?id=" + String.Join(',', id) + (versions ? "&versions=1" : "") + (videos ? "&videos=1" : "") + (comments ? "&comments=1" : "");
            return GetThing(requestString);
        }
        public List<SearchResult> Search(string query, ThingType type = ThingType.none, bool exact = false)
        {
            string requestString = apiBaseAddress + "search?query=" + query.Replace(' ', '+') + (type == ThingType.none ? "" : "&type=" + type.ToString()) + (exact ? "&exact=1" : "");
            return GetSearchresults(requestString);
        }

        //Overload function for multiple types
        public List<SearchResult> Search(string query, IEnumerable<ThingType> type = null, bool exact = false)
        {
            string searchTypes;
            if (type == null)
            {
                searchTypes = "";
            }
            else
            {
                searchTypes = "&type=";
                foreach (ThingType single in type)
                {
                    searchTypes += single.ToString() + ",";
                }
            }

            string requestString = apiBaseAddress + "search?query=" + query.Replace(' ', '+') + searchTypes + (exact ? "&exact=1" : "");
            return GetSearchresults(requestString);
        }
        /// <summary>
        /// Gets the top 50 most active items on the site.
        /// </summary>
        /// <param name="type">Type of item to sort by.</param>
        /// <returns></returns>
        public List<HotItem> Hot(HotType type = HotType.none)
        {
            string requeststring = apiBaseAddress + "hot" + (type == HotType.none ? "" : "?type=" + type.ToString());
            List<HotItem> items = new List<HotItem>();
            foreach (XmlNode node in GetItems(requeststring))
            {
                HotItem item = new HotItem(node);
                items.Add(item);
            }
            return items;
        }

        public User User(string name)
        {
            string requestString = apiBaseAddress + "user?name=" + name;
            string resultString = client.DownloadString(requestString);
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(resultString);
            XmlNode user = xmlData.SelectSingleNode("user");
            return new User(user);
        }

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
        //Loads xml data from the client
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
