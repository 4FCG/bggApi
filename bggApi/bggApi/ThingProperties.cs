using System;
using System.Collections.Generic;
using System.Text;

namespace bggApi
{
    public partial class Thing
    {
        //Boardgame properties
        public int? Yearpublished { get; private set; }

        public int? Minplayers { get; private set; }

        public int? Maxplayers { get; private set; }

        public int? Playingtime { get; private set; }

        public int? Minplaytime { get; private set; }

        public int? Maxplaytime { get; private set; }

        public int? Minage { get; private set; }

        public List<Poll> Polls { get; private set; }

        //Rpgissue properties
        public string Datepublished { get; private set; }

        public int? Issueindex { get; private set; }

        //Rpgitem properties
        public int? Seriescode { get; private set; }

        //Videogame properties
        public string Releasedate { get; private set; }
    }
}
