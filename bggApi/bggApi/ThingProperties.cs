using System;
using System.Collections.Generic;
using System.Text;

namespace bggApi
{
    public partial class Thing
    {
        //Base properties
        public int Id { get; private set; }

        public string Type { get; private set; }

        public string Thumbnail { get; private set; }

        public string Image { get; private set; }

        public List<Name> Names { get; private set; }

        public string Description { get; private set; }

        public List<Link> Links { get; private set; }

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
