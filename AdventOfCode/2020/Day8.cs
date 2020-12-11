using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day8: Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("input\\2020_day8.txt");
            var lines = allText.Split("\r\n").ToList();
            var visited = new List<int>();
            var line = 0;
            var sum = 0;

            while (!visited.Contains(line))
            {
                visited.Add(line);
                if (lines[line].Contains("nop"))
                {
                    line++;
                }
                else if (lines[line].Contains("acc"))
                {
                    sum += Int32.Parse(lines[line].Split(" ")[1]);
                    line++;
                }
                else if (lines[line].Contains("jmp"))
                {
                    line += Int32.Parse(lines[line].Split(" ")[1]);
                }
            }

            part1 = sum;

            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].Contains("acc"))
                    continue;
                else
                    lines[i] = lines[i].Contains("nop") ? lines[i].Replace("nop", "jmp") : lines[i].Replace("jmp", "nop");

                visited.Clear();
                line = 0;
                sum = 0;
                while (!visited.Contains(line) && line < lines.Count())
                {
                    visited.Add(line);
                    if (lines[line].Contains("nop"))
                    {
                        line++;
                    }
                    else if (lines[line].Contains("acc"))
                    {
                        sum += Int32.Parse(lines[line].Split(" ")[1]);
                        line++;
                    }
                    else if (lines[line].Contains("jmp"))
                    {
                        line += Int32.Parse(lines[line].Split(" ")[1]);
                    }
                }
                if (line == lines.Count())
                {
                    part2 = sum;
                    break;
                }

                lines[i] = lines[i].Contains("nop") ? lines[i].Replace("nop", "jmp") : lines[i].Replace("jmp", "nop");
            }
            WriteResult(8, part1, part2, result.gold);
        }
    }
}
