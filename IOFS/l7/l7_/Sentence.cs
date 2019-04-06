using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace l7_
{
    public class Sentence : IComparable<Sentence>
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public int CompareTo(Sentence other)
        {
            return Math.Sign(Count - other.Count);
        }
    }
}
