using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class LehmerRandom
    {
        private ulong a, m, Rprev, R0;
        public LehmerRandom(ulong a, ulong m, ulong R0)
        {
            this.a = a;
            this.m = m;
            this.Rprev = R0;
            this.R0 = R0;
        }

        public double Next()
        {
            Rprev = (a * Rprev) % m;
            return (double)Rprev / m;
        }
    }
}
