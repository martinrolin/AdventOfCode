using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2025
{

    class Day03 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2025\\day03.txt");
            var input = allText.Split("\r\n").ToList();

            foreach (var line in input)
            {
                int max = 0;
                int secondMax = 0;
                foreach (var i in line.Select((value, i) => new { i, value = value - '0' }).ToList())
                {
                    if (i.value > max && i.i != line.Length - 1)
                    {
                        max = i.value;
                        secondMax = 0;
                    }
                    else if (i.value > secondMax)
                    {
                        secondMax = i.value;
                    }

                }
                part1 += 10 * max + secondMax;

                var l = line.Select(c => c - '0').ToList();
                long value = 0;
                for (int i = 1; i <= 12; i++)
                {
                    var next = l.Take(l.Count - (12 - i)).Max();
                    
                    value = value * 10 + next;

                    l = l.Skip(l.IndexOf(next)+1).ToList();
                }

                part2 += value;
            }

            WriteResult(3, part1, part2, Result.twoStars);

        }

       
    }
}


