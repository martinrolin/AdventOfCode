using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode._2023
{
    class Day19 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day19.txt");
            var lv = allText.Split("\r\n").ToList();

           

            WriteResult(19, part1, part2, Result.none);
        }
    }
}





