using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameGeekApi
{
    public class Thing
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Thumbnail { get; set; }

        public string Image { get; set; }

        public List<Name> Names { get; set; }

        public string Description { get; set; }

        public List<Link> Links { get; set; }
    }
}
