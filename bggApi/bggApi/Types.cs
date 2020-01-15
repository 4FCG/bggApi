using System;
using System.Collections.Generic;
using System.Text;

namespace bggApi
{
    /// <summary>
    /// The different thingtypes recognized by the BGG API.
    /// </summary>
    public enum ThingType
    {
        none,
        rpgitem,
        videogame,
        boardgame,
        boardgameaccessory,
        boardgameexpansion
    }
    /// <summary>
    /// The different types accepted by the hot function
    /// </summary>
    public enum HotType
    {
        none,
        boardgame,
        rpg,
        videogame,
        boardgamecompany,
        videogamecompany
        //The following types are listed as options but yield no results:
        //boardgameperson
        //rpgperson
        //rpgcompany
    }
}
