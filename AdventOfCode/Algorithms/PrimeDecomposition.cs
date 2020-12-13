using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Algorithms
{
    class PrimeDecomposition
    {
        public static List<int> GetPrimes(decimal n)
        {
            List<int> storage = new List<int>();
            while (n > 1)
            {
                int i = 1;
                while (true)
                {
                    if (IsPrime(i))
                    {
                        if (((decimal)n / i) == Math.Round((decimal)n / i))
                        {
                            n /= i;
                            storage.Add(i);
                            break;
                        }
                    }
                    i++;
                }
            }
            return storage;
        }

        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
    }
}
