using QuickGraph.Collections;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Xml;

namespace AdventOfCode._2022
{
    class Day12 : Helper
    {

        private long Part1(List<string> lines, int sr, int sc, int er, int ec)
        {
           
            PriorityQueue<string, int> queue = new PriorityQueue<string, int>();
            

            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            pq.Enqueue((sr, sc), 0);

            while (pq.TryDequeue(out (int, int) x, out int priority))
            {
                if (visited.Contains((x.Item1, x.Item2)))
                    continue;

                visited.Add((x.Item1, x.Item2));

                var neighbours = new List<(int, int)>();
                neighbours.Add((x.Item1 - 1, x.Item2));
                neighbours.Add((x.Item1 + 1, x.Item2));
                neighbours.Add((x.Item1, x.Item2 - 1));
                neighbours.Add((x.Item1, x.Item2 + 1));

                foreach (var n in neighbours)
                {
                    if (n.Item1 < 0 || n.Item2 < 0 || n.Item1 >= lines.Count || n.Item2 >= lines[0].Length)
                        continue;
                    if (visited.Contains((n.Item1, n.Item2)))
                        continue;
                    if (lines[n.Item1][n.Item2] - lines[x.Item1][x.Item2] > 1)
                        continue;
                    if (n.Item1 == er && n.Item2 == ec)
                        return priority + 1;
                    
                    pq.Enqueue((n.Item1, n.Item2), priority + 1);
                   
                }
            }

            return 0;
        }


        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day12.txt");
            var lines = allText.Split("\r\n").ToList();
            var sr = -1;
            var sc = -1;
            var er = -1;
            var ec = -1;

            for (int r = 0; r < lines.Count; r++)
            {
                for (int c = 0; c < lines[0].Length; c++)
                {
                    if (lines[r][c] == 'S')
                    {
                        sr = r;
                        sc = c;
                    }
                    if (lines[r][c] == 'E')
                    {
                        er = r;
                        ec = c;
                    }
                }
                lines[r] = lines[r].Replace("S", "a").Replace("E", "z");
            }

            part1 = Part1(lines, sr, sc, er, ec);

            // Part 2

            LinkedList<(int, int, int)> queue = new LinkedList<(int, int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            queue.AddFirst((er, ec, 0));
            visited.Add((er, ec));

            while (queue.Count() > 0)
            {
                (int, int, int) x = queue.First();
                queue.RemoveFirst();

                var neighbours = new List<(int, int)>();
                neighbours.Add((x.Item1 - 1, x.Item2));
                neighbours.Add((x.Item1 + 1, x.Item2));
                neighbours.Add((x.Item1, x.Item2 - 1));
                neighbours.Add((x.Item1, x.Item2 + 1));

                foreach (var n in neighbours)
                {
                    if (n.Item1 < 0 || n.Item2 < 0 || n.Item1 >= lines.Count || n.Item2 >= lines[0].Length)
                        continue;
                    if (visited.Contains((n.Item1, n.Item2)))
                        continue;
                    if (lines[n.Item1][n.Item2] - lines[x.Item1][x.Item2] < -1)
                        continue;
                    if (lines[n.Item1][n.Item2] == 'a')
                    {

                        part2 = x.Item3 + 1;
                        queue.Clear();
                        break;
                    }
                    visited.Add((n.Item1, n.Item2));
                    queue.AddLast((n.Item1, n.Item2, x.Item3 + 1));
                }                
            }
           
            WriteResult(12, part1, part2, Result.twoStars);
        }
    }
}







