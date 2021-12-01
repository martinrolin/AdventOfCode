using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day03 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day03.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            for (int i = 1; i < listOfValues.Count - 1; i++)
            {
                if (Int32.Parse(listOfValues[i]) > Int32.Parse(listOfValues[i - 1]))
                    part1++;
            }

            for (int i = 2; i < listOfValues.Count - 2; i++)
            {
                int a = Int32.Parse(listOfValues[i - 2]) + Int32.Parse(listOfValues[i - 1]) + Int32.Parse(listOfValues[i]);
                int b = Int32.Parse(listOfValues[i - 1]) + Int32.Parse(listOfValues[i]) + Int32.Parse(listOfValues[i + 1]);
                if (b > a)
                    part2++;
            }

            WriteResult(1, part1, part2, result.none);

        }
    }
}




