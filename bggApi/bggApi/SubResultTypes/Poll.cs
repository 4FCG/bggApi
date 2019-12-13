using System;
using System.Collections.Generic;
using System.Text;

namespace bggApi
{
    public class Poll
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public int Totalvotes { get; set; }

        public List<Results> ResultsList {get; set;}
    }
}
