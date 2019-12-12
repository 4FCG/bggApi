using System;
using System.Collections.Generic;
using System.Text;

namespace bggApi.ThingTypes
{
    //This class is is also used for boardgameexpansions
    public class Boardgame : Thing
    {
        public int Yearpublished { get; set; }

        public int Minplayers { get; set; }

        public int Maxplayers { get; set; }

        public int Playingtime { get; set; }

        public int Minplaytime { get; set; }

        public int Maxplaytime { get; set; }

        public int Minage { get; set; }

        public List<Poll> Polls { get; set; }
    }
}
