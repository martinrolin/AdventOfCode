using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2022
{
    class Day03 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2022\\day02.txt");
            var listOfValues = allText.Split("\r\n").ToList();



            WriteResult(3, part1, part2, result.none);

        }
    }
}




