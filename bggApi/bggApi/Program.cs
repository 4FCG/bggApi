using bggApi.SubResultTypes;
using System;
using System.Collections.Generic;
using System.Xml;

//https://www.boardgamegeek.com/xmlapi2/search?query=die
namespace bggApi
{
    class Program
    {
        static void Main(string[] args)
        {
            BggApi testApi = new BggApi();
            List<int> ids = new List<int> { 1, 200, 50 };
            List<Thing> test = testApi.GetThing(ids, versions:true);
            
            foreach (Thing thing in test)
            {
                Console.WriteLine(thing.Names.Find(name => name.Type == "primary").Value);
            }

            List<SearchResult> searchTest = testApi.Search("fortnite");

            foreach (SearchResult result in searchTest)
            {
                Console.WriteLine(result.Name.Value);
            }
        }
    }
}
