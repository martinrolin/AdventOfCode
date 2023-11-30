using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace AdventOfCode._2022
{
    class Day09 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day09.txt");
            var lines = allText.Split("\r\n").ToList();
            Dictionary<(int, int), bool> visited = new Dictionary<(int, int), bool>();
            Dictionary<string, (int,int)> direction = new Dictionary<string, (int, int)>();
            direction.Add("R", (1, 0));
            direction.Add("L", (-1, 0));
            direction.Add("U", (0, 1));
            direction.Add("D", (0, -1));
            (int, int) head = (0, 0);
            (int, int) tail = (0, 0);

            var rope = new (int, int)[10] {(0,0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0) };

            foreach (var line in lines) {
                var content = line.Split(" ");

                for (int i = 0; i < int.Parse(content[1].ToString()); i++)
                {
                    head.Item1 += direction[content[0]].Item1;
                    head.Item2 += direction[content[0]].Item2;

                    if (head.Item1 == tail.Item1 && head.Item2 - tail.Item2 == 2)
                        tail.Item2 += 1;
                    if (head.Item1 == tail.Item1 && head.Item2 - tail.Item2 == -2)
                        tail.Item2 -= 1;
                    if (head.Item2 == tail.Item2 && head.Item1 - tail.Item1 == 2)
                        tail.Item1 += 1;
                    if (head.Item2 == tail.Item2 && head.Item1 - tail.Item1 == -2)
                        tail.Item1 -= 1;

                    if (head.Item1 > tail.Item1 && head.Item2 > tail.Item2 && Math.Abs(head.Item1 - tail.Item1) + Math.Abs(head.Item2 - tail.Item2) > 2)
                    {
                        tail.Item1 += 1;
                        tail.Item2 += 1;
                    }
                    if (head.Item1 < tail.Item1 && head.Item2 > tail.Item2 && Math.Abs(head.Item1 - tail.Item1) + Math.Abs(head.Item2 - tail.Item2) > 2)
                    {
                        tail.Item1 -= 1;
                        tail.Item2 += 1;
                    }
                    if (head.Item1 < tail.Item1 && head.Item2 < tail.Item2 && Math.Abs(head.Item1 - tail.Item1) + Math.Abs(head.Item2 - tail.Item2) > 2)
                    {
                        tail.Item1 -= 1;
                        tail.Item2 -= 1;
                    }
                    if (head.Item1 > tail.Item1 && head.Item2 < tail.Item2 && Math.Abs(head.Item1 - tail.Item1) + Math.Abs(head.Item2 - tail.Item2) > 2)
                    {
                        tail.Item1 += 1;
                        tail.Item2 -= 1;
                    }
                    visited[(tail)] = true;

                }
            
            }

            part1 = visited.Values.Count();
            visited.Clear();

            foreach (var line in lines)
            {
                var content = line.Split(" ");

                for (int i = 0; i < int.Parse(content[1].ToString()); i++)
                {
                    rope[0].Item1 += direction[content[0]].Item1;
                    rope[0].Item2 += direction[content[0]].Item2;

                    for (int j= 1; j < 10; j++)
                    {
                        if (rope[j-1].Item1 == rope[j].Item1 && rope[j-1].Item2 - rope[j].Item2 == 2)
                            rope[j].Item2 += 1;
                        if (rope[j-1].Item1 == rope[j].Item1 && rope[j-1].Item2 - rope[j].Item2 == -2)
                            rope[j].Item2 -= 1;
                        if (rope[j-1].Item2 == rope[j].Item2 && rope[j-1].Item1 - rope[j].Item1 == 2)
                            rope[j].Item1 += 1;
                        if (rope[j-1].Item2 == rope[j].Item2 && rope[j-1].Item1 - rope[j].Item1 == -2)
                            rope[j].Item1 -= 1;

                        if (rope[j-1].Item1 > rope[j].Item1 && rope[j-1].Item2 > rope[j].Item2 && Math.Abs(rope[j-1].Item1 - rope[j].Item1) + Math.Abs(rope[j-1].Item2 - rope[j].Item2) > 2)
                        {
                            rope[j].Item1 += 1;
                            rope[j].Item2 += 1;
                        }
                        if (rope[j-1].Item1 < rope[j].Item1 && rope[j-1].Item2 > rope[j].Item2 && Math.Abs(rope[j-1].Item1 - rope[j].Item1) + Math.Abs(rope[j-1].Item2 - rope[j].Item2) > 2)
                        {
                            rope[j].Item1 -= 1;
                            rope[j].Item2 += 1;
                        }
                        if (rope[j-1].Item1 < rope[j].Item1 && rope[j-1].Item2 < rope[j].Item2 && Math.Abs(rope[j-1].Item1 - rope[j].Item1) + Math.Abs(rope[j-1].Item2 - rope[j].Item2) > 2)
                        {
                            rope[j].Item1 -= 1;
                            rope[j].Item2 -= 1;
                        }
                        if (rope[j-1].Item1 > rope[j].Item1 && rope[j-1].Item2 < rope[j].Item2 && Math.Abs(rope[j-1].Item1 - rope[j].Item1) + Math.Abs(rope[j-1].Item2 - rope[j].Item2) > 2)
                        {
                            rope[j].Item1 += 1;
                            rope[j].Item2 -= 1;
                        }
                    }
                    
                    visited[(rope[9])] = true;

                   
                }

            }
            part2 = visited.Values.Count();

            WriteResult(9, part1, part2, Result.twoStars);
        }
    }
}







