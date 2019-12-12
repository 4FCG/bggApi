using System;
using System.Collections.Generic;
using System.Text;

namespace bggApi
{
    public class Link
    {
        public string Type { get; set; }

        public int Id { get; set; }

        public string Value { get; set; }

        public bool Inbound { get; set; }
    }
}
