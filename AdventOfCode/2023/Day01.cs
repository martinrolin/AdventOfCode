using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2023
{
    class Day01 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day01.txt");
            var listOfValues = allText.Split("\r\n").ToList();
            List<long> sums = new List<long>();


            WriteResult(1, part1, part2, Result.none);

        }
    }
}




