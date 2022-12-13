using Newtonsoft.Json.Linq;
using System;
using System.Linq;


namespace AdventOfCode._2022
{
    class Day14 : Helper
    {               
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day14.txt");
            var lines = allText.Split("\r\n").ToList();

            WriteResult(14, part1, part2, Result.none);
        }
    }
}







