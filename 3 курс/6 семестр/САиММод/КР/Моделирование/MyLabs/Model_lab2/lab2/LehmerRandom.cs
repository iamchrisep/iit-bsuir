using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class LRandom
    {
        private ulong a, m, X;
        public LRandom(ulong a, ulong m, ulong X0){
            this.a = a;
            this.m = m;
            this.X = X0;           
        }

        public double Next(){            
            return (double)(X = (a * X) % m) / m;
        }
    }
}
