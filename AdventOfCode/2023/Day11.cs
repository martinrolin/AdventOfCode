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
    class Day11 : Helper
    {

        private class Coordinate
        {
            public Coordinate(long r, long c)
            {
                this.r = r;
                this.c = c;
            }
            public long r { get; set; }
            public long c { get; set; }
        }

        private long P(List<string> lv, List<Coordinate> galaxies, long diff)
        {
            long sum = 0;

            for (int r = lv.Count - 1; r >= 0; r--)
            {
                if (lv[r].All(x => x == '.'))
                {
                    foreach (var g in galaxies.Where(x => x.r > r))
                    {
                        g.r += diff;
                    }
                }
            }
            for (int c = lv[0].Length - 1; c >= 0; c--)
            {
                if (lv.All(x => x[c] == '.'))
                {
                    foreach (var g in galaxies.Where(x => x.c > c))
                    {
                        g.c += diff;
                    }
                }
            }

            for (int i = 0; i < galaxies.Count - 1; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {

                        sum += Math.Abs(galaxies[j].r - galaxies[i].r) + Math.Abs(galaxies[j].c - galaxies[i].c);
                    
                }
            }

            return sum;
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day11.txt");
            var lv = allText.Split("\r\n").ToList();

            List<Coordinate> g1 = new List<Coordinate>();
            List<Coordinate> g2 = new List<Coordinate>();


            for (int r = 0; r < lv.Count; r++)
            {
                for (int c = 0; c < lv[r].Length; c++)
                {
                    if (lv[r][c] == '#')
                    {
                        g1.Add(new Coordinate(r, c));
                        g2.Add(new Coordinate(r, c));
                    }
                        
                }
            }

            part1 = P(lv, g1, 1);
            part2 = P(lv, g2, 1000000 - 1);

            WriteResult(11 , part1, part2, Result.twoStars);

        }

        
    }
}





