using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
    public class TextWord : IComparable<TextWord>
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public int CompareTo(TextWord other)
        {
            return Math.Sign(Count - other.Count);
        }
    }
}
