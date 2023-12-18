using QuickGraph;
using QuickGraph.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdventOfCode._2023
{
    class Day17 : Helper
    {


        private long Part1(List<string> lv)
        {

            long part1 = 0;

            var pq = new PriorityQueue<(int, int, char, int), int>();

            var visited = new HashSet<(int, int, char, int)>();



            pq.Enqueue((0, 0, '-', 0), 0);

            while (part1 == 0 && pq.TryDequeue(out (int r, int c, char d, int s) x, out int priority))
            {

                if (visited.Contains((x.r, x.c, x.d, x.s)))
                    continue;

                if (x.r == lv.Count - 1 && x.c == lv[0].Length - 1)
                    part1 = priority;

                //Console.WriteLine("r = " + x.r + " c= " + x.c + " d= " + x.d + " s= " + x.s +" p= "+priority);

                visited.Add((x.r, x.c, x.d, x.s));

                var neighbours = new List<(int r, int c, char d, int s)>();

                if (x.d != 'D')
                    neighbours.Add((x.r - 1, x.c, 'U', x.d == 'U' ? x.s : 0));
                if (x.d != 'U')
                    neighbours.Add((x.r + 1, x.c, 'D', x.d == 'D' ? x.s : 0));
                if (x.d != 'R')
                    neighbours.Add((x.r, x.c - 1, 'L', x.d == 'L' ? x.s : 0));
                if (x.d != 'L')
                    neighbours.Add((x.r, x.c + 1, 'R', x.d == 'R' ? x.s : 0));

                foreach (var n in neighbours.Where(x => x.s < 3))
                {
                    if (n.r < 0 || n.c < 0 || n.r >= lv.Count || n.c >= lv[0].Length)
                        continue;
                    //if (visited.Contains((n.r, n.c)))
                    //    continue;


                    pq.Enqueue((n.r, n.c, n.d, n.s + 1), priority + (lv[n.r][n.c] - '0'));

                }
            }

            return part1;
        }

        private long Part2(List<string> lv)
        {

            long part2 = 0;

            var pq = new PriorityQueue<(int, int, char, int), int>();

            var visited = new HashSet<(int, int, char, int)>();



            pq.Enqueue((0, 0, '-', 0), 0);

            while (part2 == 0 && pq.TryDequeue(out (int r, int c, char d, int s) x, out int priority))
            {

                if (visited.Contains((x.r, x.c, x.d, x.s)))
                    continue;

                if (x.r == lv.Count - 1 && x.c == lv[0].Length - 1 && x.s >= 4)
                    part2 = priority;

                //Console.WriteLine("r = " + x.r + " c= " + x.c + " d= " + x.d + " s= " + x.s + " p= " + priority);

                visited.Add((x.r, x.c, x.d, x.s));

                var neighbours = new List<(int r, int c, char d, int s)>();

                if (x.d == 'D' || x.d == '-')
                {
                    neighbours.Add((x.r + 1, x.c, 'D', x.s));
                    if (x.s >= 4)
                    {
                        neighbours.Add((x.r, x.c - 1, 'L', 0));
                        neighbours.Add((x.r, x.c + 1, 'R', 0));
                    }
                }

                if (x.d == 'U')
                {
                    neighbours.Add((x.r - 1, x.c, 'U', x.s));
                    if (x.s >= 4)
                    {
                        neighbours.Add((x.r, x.c - 1, 'L', 0));
                        neighbours.Add((x.r, x.c + 1, 'R', 0));
                    }
                }
                if (x.d == 'L')
                {
                    neighbours.Add((x.r, x.c - 1, 'L', x.s));
                    if (x.s >= 4)
                    {
                        neighbours.Add((x.r - 1, x.c, 'U', 0));
                        neighbours.Add((x.r + 1, x.c, 'D', 0));
                    }
                }
                if (x.d == 'R' || x.d == '-')
                {
                    neighbours.Add((x.r, x.c + 1, 'R', x.s));
                    if (x.s >= 4)
                    {
                        neighbours.Add((x.r - 1, x.c, 'U', 0));
                        neighbours.Add((x.r + 1, x.c, 'D', 0));
                    }
                }
                foreach (var n in neighbours.Where(x => x.s < 10))
                {
                    if (n.r < 0 || n.c < 0 || n.r >= lv.Count || n.c >= lv[0].Length)
                        continue;
                    //if (visited.Contains((n.r, n.c)))
                    //    continue;


                    pq.Enqueue((n.r, n.c, n.d, n.s + 1), priority + (lv[n.r][n.c] - '0'));

                }
            }

            return part2;
        }


        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day17.txt");
            var lv = allText.Split("\r\n").ToList();

            part1 = Part1(lv);
            part2 = Part2(lv);

            WriteResult(17 , part1, part2, Result.twoStars);
        }
    }
}





