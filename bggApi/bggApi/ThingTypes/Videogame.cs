﻿using System;
using System.Collections.Generic;
using System.Text;

namespace bggApi.ThingTypes
{
    public class Videogame : Thing
    {
        public int Minplayers { get; set; }
        public int Maxplayers { get; set; }
        public string Releasedate { get; set; }
    }
}
