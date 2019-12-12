using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BoardGameGeekApi
{  

    partial class ThingOld
    {
        public readonly int Id;

        public string Type { get; private set; }

        public string Thumbnail { get; private set; }

        public string Image { get; private set; }

        /// <summary>
        /// The primary name of the thing
        /// </summary>
        public string Name { get; private set; }
        //Add support for alternative names.

        public string Description { get; private set; }

        public int Yearpublished { get; private set; }

        public int Minplayers { get; private set; }

        public int Maxplayers { get; private set; }

        public int Playingtime { get; private set; }

        public int Minplaytime { get; private set; }

        public int Maxplaytime { get; private set; }

        public int Minage { get; private set; }

        //polls

        //Links to other database types with relevance like publisher and categories
    }
}
