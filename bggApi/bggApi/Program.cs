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
            //List<int> ids = new List<int> { 1, 200, 50 };
            //List<Thing> test = testApi.GetThing(ids, versions:true);

            //foreach (Thing thing in test)
            //{
            //    Console.WriteLine(thing.Names.Find(name => name.Type == "primary").Value);
            //}

            //List<ThingType> types = new List<ThingType> { ThingType.boardgame, ThingType.videogame };

            //List<SearchResult> searchTest = testApi.Search("fortnite", type: types);

            //foreach (SearchResult result in searchTest)
            //{
            //    Console.WriteLine(result.Name.Value);
            //    Thing thing = testApi.GetThing(result.Id, comments:true)[0];
            //    foreach (bggApi.OptionalResultTypes.Comment comment in thing.Comments)
            //    {
            //        Console.WriteLine(comment.Username);
            //        Console.WriteLine(comment.Value);
            //    }
            //}

            //foreach (HotItem item in testApi.Hot(HotType.videogame))
            //{
            //    Console.WriteLine(item.Rank + ": " + item.Name);
            //}
            User user = testApi.User("sheep");
            Console.WriteLine(user.Name);
            Console.WriteLine(user.Yearregistered);
        }
    }
}
