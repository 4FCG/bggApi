using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
//https://www.boardgamegeek.com/xmlapi2/search?query=die
namespace bggApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            BggApi testApi = new BggApi();

            Thing test = testApi.GetThing(1)[0];
            Console.WriteLine(test.Type);
            Console.WriteLine(test.Description);
        }
    }
}
