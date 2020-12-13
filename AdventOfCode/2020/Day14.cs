using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day14 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("input\\2020_day14.txt");
            var lines = allText.Split("\r\n").ToList();

            WriteResult(14, part1, part2, result.none);

        }
    }
}
