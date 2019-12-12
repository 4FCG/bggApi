using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
//https://www.boardgamegeek.com/xmlapi2/search?query=die
namespace BoardGameGeekApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ThingOld test = await ThingOld.CreateThing(1);
            Console.WriteLine(test.Name);
            Console.WriteLine(test.Yearpublished);
        }
    }
}
