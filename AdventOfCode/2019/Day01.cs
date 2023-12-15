using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AdventOfCode._2019
{
    class Day01 : Helper
    {

        private long Fuel(long value) {
            return value / 3 - 2;
        }
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2019\\day01.txt");
            var listOfValues = allText.Split("\r\n").ToList();


            foreach (string element in listOfValues)
            {
                long n = long.Parse(element);
                part1 += Fuel(n);
                long sum = 0 ;
                while (Fuel(n) >= 0)
                {
                    n = Fuel(n);
                    sum += n;
                    
                }
                part2 += sum;

            }
            WriteResult(1, part1, part2, Result.twoStars);

        }
    }
}
