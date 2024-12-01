using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace AdventOfCode._2023
{
    class Day24 : Helper
    {

        private (double x, double y) FindIntersection((long x, long y) A, (long x, long y) B, (long x, long y) C, (long x, long y) D)
        {
            double a1 = B.y - A.y;
            double b1 = A.x - B.x;
            double c1 = a1 * (A.x) + b1 * (A.y);

            double a2 = D.y - C.y;
            double b2 = C.x - D.x;
            double c2 = a2 * (C.x) + b2 * (C.y);

            double det = a1 * b2 - a2 * b1;

            if (det == 0)
            {
                return (double.MaxValue, double.MaxValue);
            }
            else
            {
                double x = (b2 * c1 - b1 * c2) / det;
                double y = (a1 * c2 - a2 * c1) / det;
                return (x, y);
            }
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            List<List<long>> lines = File.ReadAllLines("Input\\2023\\day24.txt").Select(line => line.Replace("@", ",").Split(',').Select(long.Parse).ToList()).ToList();

            double MIN = 200000000000000;
            double MAX = 400000000000000;

            for (int a = 0; a < lines.Count-1; a++)
            {
                for (int b = a+1; b < lines.Count; b++)
                {
                    var i = FindIntersection((lines[a][0], lines[a][1]), (lines[a][0] + lines[a][3], lines[a][1] + lines[a][4]), (lines[b][0], lines[b][1]), (lines[b][0] + lines[b][3], lines[b][1] + lines[b][4]));
                    if (i.x >= MIN && i.x <= MAX && i.y >= MIN && i.y <= MAX)
                        if ((i.x - lines[a][0]) / lines[a][3] >= 0 && (i.y - lines[a][1]) / lines[a][4] >= 0 && (i.x - lines[b][0]) / lines[b][3] >= 0 && (i.y - lines[b][1]) / lines[b][4] >= 0)
                            part1++;
                }
            }

            WriteResult(24, part1, part2, Result.none);

        }
    }
}





