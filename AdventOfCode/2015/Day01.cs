using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2015
{
    class Day01 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2015\\day01.txt");



            // Part 1
            part1 = allText.Count(f => f == '(') - allText.Count(f => f == ')');


            // Part 2
            int floor = 0;
            for (int i = 0; i < allText.Length; i++)
            {
                if (allText[i] == '(')
                    floor += 1;
                else if (allText[i] == ')')
                    floor -= 1;

                if (floor == -1)
                {
                    part2 = i + 1;
                    break;
                }
            }

            WriteResult(1, part1, part2, Result.gold);

        }
    }
}
