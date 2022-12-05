using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2015
{
    class Day02 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2015\\day02.txt");
            var lines = allText.Split("\r\n").ToList();

            foreach (var line in lines)
            {
                var x = line.Split("x").Select(x => int.Parse(x)).ToList();
                x.Sort();
                part1 += 2 * x[0] * x[1] + 2 * x[1] * x[2] + 2 * x[2] * x[0] + x[0] * x[1];
                part2 += 2 * x[0] + 2 * x[1] + x[0] * x[1] * x[2];
            }

            WriteResult(2, part1, part2, Result.none);

        }

    }
}




