using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2019
{
    class Day1 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("input\\2019_day1.txt");
            var listOfValues = allText.Split("\r\n").ToList();


            foreach (string element in listOfValues)
            {
                int number = Int32.Parse(element);
                var val = number / 3 - 2;
                part1 += val;

            }
            WriteResult(1, part1, null, result.silver);

        }
    }
}
