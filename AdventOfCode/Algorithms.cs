using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class Algorithms
    {

        static public long ChineseRemainderTheorem(long[] n, long[] a)
        {
            long prod = n.Aggregate((long)1, (i, j) => i * j);
            long p;
            long sm = 0;
            for (long i = 0; i < n.Length; i++)
            {
                p = prod / n[i];
                sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
            }
            return sm % prod;
        }

        static private long ModularMultiplicativeInverse(long a, long mod)
        {
            long b = a % mod;
            for (long x = 1; x < mod; x++)
            {
                if ((b * x) % mod == 1)
                {
                    return x;
                }
            }
            return 1;
        }
    }
}
