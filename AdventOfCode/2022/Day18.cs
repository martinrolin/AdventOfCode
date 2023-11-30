using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2022
{
    class Day18 : Helper
    {


        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string input = System.IO.File.ReadAllText("Input\\2022\\day18.txt");
            var lines = input.Split("\r\n").ToList();
            var dict = new Dictionary<(double, double, double),int>();
            var offset = new List<(double, double, double)>();
            offset.Add((0.5, 0, 0));
            offset.Add((0, 0.5, 0));
            offset.Add((0, 0, 0.5));
            offset.Add((-0.5, 0, 0));
            offset.Add((0, -0.5, 0));
            offset.Add((0, 0, -0.5));


            foreach (var line in lines)
            {
                foreach (var o in offset)
                {
                    var p = (double.Parse(line.Split(",")[0]) + o.Item1, double.Parse(line.Split(",")[1]) + o.Item2, double.Parse(line.Split(",")[2]) + o.Item3);
                    if (!dict.ContainsKey(p))
                        dict.Add(p, 0);
                    dict[p]++;

                }
            }

            part1 = dict.Where(x => x.Value == 1).Count();


            // Part 2
            var droplet = new HashSet<(double, double, double)>();

            var mx = double.MaxValue;
            var my = double.MaxValue;
            var mz = double.MaxValue;

            var Mx = double.MinValue;
            var My = double.MinValue;
            var Mz = double.MinValue;

            dict.Clear();
            foreach (var line in lines)
            {
                var l = line.Split(",");
                var x = double.Parse(l[0]);
                var y = double.Parse(l[1]);
                var z = double.Parse(l[2]);

                droplet.Add((x, y, z));

                mx = Math.Min(mx, x);
                my = Math.Min(my, y);
                mz = Math.Min(mz, z);
                Mx = Math.Max(Mx, x);
                My = Math.Max(My, y);
                Mz = Math.Max(Mz, z);
                foreach (var o in offset)
                {
                    var p = (x + o.Item1, y + o.Item2, z + o.Item3);
                    if (!dict.ContainsKey(p))
                        dict.Add(p, 0);
                    dict[p]++;

                }
            }

            mx--;
            my--;
            mz--;
            Mx++;
            My++;
            Mz++;

            var q = new Queue<(double, double, double)>();
            var air = new HashSet<(double, double, double)>();

            q.Enqueue((mx, my, mz));
            air.Add((mx, my, mz));

            while (q.Count > 0)
            {
                (double x, double y, double z) = q.Dequeue();

                foreach (var o in offset)
                {
                    var k = (x + o.Item1 * 2, y + o.Item2 * 2, z + o.Item3 * 2);

                    if (k.Item1 < mx || k.Item1 > Mx || k.Item2 < my || k.Item2 > My || k.Item3 < mz || k.Item3 > Mz)
                        continue;

                    if (droplet.Contains(k) || air.Contains(k))
                        continue;

                    air.Add(k);
                    q.Enqueue(k);
                }
            }

            var free = new HashSet<(double, double, double)>();

            foreach ((double x, double y, double z) in air)
            {
                foreach ((double dx, double dy, double dz) in offset)
                {
                    free.Add((x + dx, y + dy, z + dz));
                }
            }

            foreach (var item in dict)
            {
                if (free.Contains(item.Key))
                {
                    part2++;
                }
            }


            WriteResult(18, part1, part2, Result.twoStars);
        }
    }
}







