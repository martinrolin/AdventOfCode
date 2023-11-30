using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2022
{
    class Day15 : Helper
    {

        private long Part1(List<string> lines)
        {
            long part1 = 0;
            var m = new HashSet<(int, int)>();
            var input = new List<(int, int, int, int)>();
            var intervals = new List<(int, int)>();
            var beacons = new HashSet<int>();

            var Y = 2000000;
            foreach (var line in lines)
            {
                var l = Regex.Matches(line, "-?\\d+");
                var sx = int.Parse((l[0].Value));
                var sy = int.Parse((l[1].Value));
                var bx = int.Parse((l[2].Value));
                var by = int.Parse((l[3].Value));
                input.Add((sx, sy, bx, by));
            }

            foreach ((int sx, int sy, int bx, int by) in input)
            {
                var d = Math.Abs(sx - bx) + Math.Abs(sy - by);


                var o = d - Math.Abs(sy - Y);

                if (o < 0)
                    continue;

                intervals.Add((sx - o, sx + o));

                if (by == Y && !beacons.Contains(bx))
                    beacons.Add(bx);

            }
            intervals.Sort();
            for (int i = intervals.First().Item1; i <= intervals.Max(x => x.Item2); i++)
            {
                foreach (var interval in intervals)
                {
                    if (i >= interval.Item1 && i <= interval.Item2)
                    {
                        part1++;
                        break;

                    }
                }

            }
            return part1;
        }
        public void Solve()
        {
            long part1 = 0;
            ulong part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day15.txt");
            var lines = allText.Split("\r\n").ToList();

            part1 = Part1(lines);

            var input = new List<(int, int, int, int)>();
            List<(int, int)> intervals = null;
            var M = 4000000;
            
            foreach (var line in lines)
            {
                var l = Regex.Matches(line, "-?\\d+");
                var sx = int.Parse((l[0].Value));
                var sy = int.Parse((l[1].Value));
                var bx = int.Parse((l[2].Value));
                var by = int.Parse((l[3].Value));
                input.Add((sx, sy, bx, by));
            }

            for (int Y = 11; Y < M; Y++)
            {
                intervals = new List<(int, int)>();
     
                foreach ((int sx,int sy,int bx ,int by) in input)
                { 
                    var d = Math.Abs(sx - bx) + Math.Abs(sy - by);
                    var o = d - Math.Abs(sy - Y);

                    if (o < 0)
                        continue;

                    intervals.Add((sx - o, sx + o));
                }

                intervals.Sort();

                var x = 0;
                foreach (var interval in intervals)
                {
                    if (x < interval.Item1)
                    {
                        part2 = (ulong)x * 4000000 + (ulong)Y;

                    }
                    x = Math.Max(x, interval.Item2 + 1);
                    if (x > M)
                        break;
                }
            }


            WriteResultStringValues(15, part1.ToString(), part2.ToString(), Result.oneStar);
        }
    }
}







