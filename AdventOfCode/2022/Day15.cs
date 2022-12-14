using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;


namespace AdventOfCode._2022
{
    class Day15 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day15.txt");
            var lines = allText.Split("\r\n").ToList();
            

            WriteResult(15, part1, part2, Result.none);
        }
    }
}







