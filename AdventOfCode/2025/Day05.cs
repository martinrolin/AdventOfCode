using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2025
{

    class Day05 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2025\\day04.txt");
            var input = allText.Split("\r\n").ToArray();


            WriteResult(5, part1, part2, Result.none);

        }       
    }
}