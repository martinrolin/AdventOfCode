using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2022
{
    class Day01 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2022\\day01.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            List<long> sums = new List<long>();
            long sum = 0;
            for (int i = 0; i < listOfValues.Count; i++)
            {
                if (listOfValues[i] != "")
                    sum += int.Parse(listOfValues[i]);

                if (listOfValues[i] == "" || i == listOfValues.Count - 1)
                {
                    sums.Add(sum);
                    sum = 0;
                }
            }

            sums.Sort();
            part1 = sums.Last();
            sums.Reverse();
            part2 = sums.Take(3).Sum();

            WriteResult(1, part1, part2, Result.gold);

        }
    }
}




