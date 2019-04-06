using System;
using System.Collections.Generic;
using System.Text;

namespace lab4{
    public static class MyRandom{
        private static readonly Random Rnd = new Random();
        public static int Next() { return Rnd.Next(); }
        public static int Next(int max) { return Rnd.Next(max); }
        public static int Next(int min, int max) { return Rnd.Next(min, max); }
    }
}
