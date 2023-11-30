using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day6 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string input = File.ReadAllText("Input\\2020\\day6.txt");
            var inputList = input.Split("\r\n\r\n").ToList();

            //Part  1
            part1 = inputList.Sum(element => element.Replace("\r\n", "").Distinct().Count());

            // Part 2
            var sum = 0;
            foreach (string group in inputList)
            {
                var person = group.Split("\r\n");

                var combined = person.Take(1).First().Distinct().ToArray();
                foreach (string p in person.Skip(1))
                {
                    combined = (char[])combined.Intersect(p.Distinct().ToArray()).ToArray();
                }

                sum += combined.Count();
            }

            part2 = sum;
            WriteResult(6, part1, part2, Result.twoStars);
        }
    }
}
