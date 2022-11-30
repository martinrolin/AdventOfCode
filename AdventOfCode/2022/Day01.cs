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
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2022\\day01.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            
            WriteResult(1, part1, part2, result.none);

        }
    }
}




