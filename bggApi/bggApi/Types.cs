using System;
using System.Collections.Generic;
using System.Text;

namespace bggApi
{
    //Thing types

    /// <summary>
    /// The different thingtypes recognized by the BGG API.
    /// </summary>
    public enum Type
    {
        none,
        rpgitem,
        videogame,
        boardgame,
        boardgameaccessory,
        boardgameexpansion
    }
}
