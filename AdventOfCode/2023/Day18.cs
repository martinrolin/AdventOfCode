using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode._2023
{
    class Day18 : Helper
    {

        private long Area(List<(long r, long c)> p, long edge)
        {
            long area = 0;
            for (var i = 0; i < p.Count - 1; ++i)
                area += (p[i].c + p[i + 1].c) * (p[i].r - p[i + 1].r);
            
            area += (p[^1].c + p[0].c) * (p[^1].r - p[0].r);
            area = Math.Abs(area);
            area += edge;
            area /= 2;
            area++;
            return area;
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day18.txt");
            var lv = allText.Split("\r\n").ToList();

            var points = new List<(long, long)> { (0, 0) };
            var dirs = new Dictionary<string, (long, long)>
            {
                {"U", (-1, 0)},
                {"3", (-1, 0)},
                {"D", (1, 0)},
                {"1", (1, 0)},
                {"L", (0, -1)},
                {"2", (0, -1)},
                {"R", (0, 1)},
                {"0", (0, 1)}

            };

            long edge = 0;

            foreach (string line in lv)
            {
               
                var x = line.Split();
                string d = x[0];
                long n = long.Parse(x[1]);

                (long dr, long dc) = dirs[d];
                edge += n;

                (long r, long c) = points.Last();
                points.Add((r + dr * n, c + dc * n));
            }

            part1 = Area(points, edge);

            edge = 0;
            points.Clear();
            points.Add((0, 0));


            foreach (string line in lv)
            {
                var x = line.Split(' ')[2][2..^1];

                (char d, long n) = (x[^1], Convert.ToInt64(x[..^1], 16));

               
                (long dr, long dc) = dirs[new string(d,1)];
                edge += n;

                (long r, long c) = points.Last();
                points.Add((r + dr * n, c + dc * n));
            }

            part2 = Area(points, edge);


            WriteResult(18, part1, part2, Result.twoStars);
        }
    }
}





