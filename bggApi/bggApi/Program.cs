using System;
using System.Xml;

//https://www.boardgamegeek.com/xmlapi2/search?query=die
namespace bggApi
{
    class Program
    {
        static void Main(string[] args)
        {
            BggApi testApi = new BggApi();

            Thing test = testApi.GetThing(1, versions:true)[0];
            Console.WriteLine(test.Type);
            Console.WriteLine(test.Versions.Count);

            
        }
    }
}
