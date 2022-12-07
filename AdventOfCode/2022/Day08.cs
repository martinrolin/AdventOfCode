using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2022
{
    class Day08 : Helper
    {
     
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day08.txt");
            var lines = allText.Split("\r\n").ToList();

            
            WriteResult(8, part1, part2, Result.none);
        }
    }
}




