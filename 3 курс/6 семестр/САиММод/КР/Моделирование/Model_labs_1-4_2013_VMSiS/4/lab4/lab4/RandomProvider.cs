using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    public static class RandomProvider
    {
        private static readonly Random Rnd = new Random();

        private static object _sync = new object();


        public static int Next()
        {
            lock (_sync)
            {
                return Rnd.Next();
            }
        }

        public static int Next(int max)
        {
            lock (_sync)
            {
                return Rnd.Next(max);
            }
        }

        public static int Next(int min, int max)
        {
            lock (_sync)
            {
                return Rnd.Next(min, max);
            }
        }

    }
}
