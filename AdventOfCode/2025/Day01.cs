using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2025
{

    class Day01 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2025\\day01.txt");
            var input = allText.Split("\r\n").ToList();

            var instructions = new List<int>();
            foreach (var line in input)
            {
                if (line[0] == 'L')
                    instructions.Add(-int.Parse(line.Substring(1)));
                else
                    instructions.Add(int.Parse(line.Substring(1)));
            }
            var dial = 50;

            foreach (var line in instructions)
            {              
                dial += line;
                dial = (dial % 100 + 100) % 100;

                if (dial == 0)
                    part1++;
            }

            dial = 50;

            foreach (var line in instructions)
            {
                var step = 1;
                if (line < 0)
                    step = -1;

                var x = 0;
                while (x != line)
                {
                    dial += step;
                    x += step;

                    if (dial < 0)
                        dial = 99;
                    dial = (dial % 100 + 100) % 100;
                    if (dial == 0)
                        part2++;

                }                
            }

            WriteResult(1, part1, part2, Result.twoStars);

            }
        }
    }


