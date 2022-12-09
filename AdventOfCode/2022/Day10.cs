using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace AdventOfCode._2022
{
    class Day10 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day10.txt");
            var lines = allText.Split("\r\n").ToList();
            
            WriteResult(10, part1, part2, Result.none);
        }
    }
}







