﻿using System;
using System.Collections.Generic;
using System.Text;

namespace bggApi.ThingTypes
{
    public class Rpgitem : Thing
    {
        public int Yearpublished { get; set; }

        //TODO: is Seriescode an int or a string?
        public int Seriescode { get; set; }
    }
}
