using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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

        //public List<Item> GetThing(int id)
        //{
            
        //}
    }
}
