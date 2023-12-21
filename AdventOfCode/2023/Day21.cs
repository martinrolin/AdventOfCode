using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace AdventOfCode._2023
{
    class Day21 : Helper
    {
        private List<string> lv;
        private HashSet<(long r, long c, long depth)> visited;
        private List<(long r, long c)> directions = new List<(long r, long c)>();

        

        private long Count(long r, long c, long depth)
        {
            int rr = (int)((r % lv.Count) + lv.Count) % lv.Count;
            int cc = (int)((c % lv[0].Length) + lv[0].Length) % lv[0].Length;


            //if (r < 0 || c < 0 || r >= lv.Count || c >= lv[0].Length)
            //    return 0;
            if (lv[rr][cc] == '#')
                return 0;

            if (visited.Contains((r, c, depth)))
                return 0;

            if (depth == 64)
            { 
                visited.Add((r, c, depth));
                return 1;
            }

            

            long sum = 0;
            foreach (var d in directions) {

                sum += Count(r + d.r, c + d.c, depth + 1);
            }

            visited.Add((r, c, depth));

            return sum;


        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day21.txt");
            lv = allText.Split("\r\n").ToList();
            visited = new HashSet<(long r, long c, long depth)>();

            directions.Add((-1, 0));
            directions.Add((1, 0));
            directions.Add((0, -1));
            directions.Add((0, 1));

            var x = 99 % 100;
            for (long r = 0; r < lv.Count; r++)
            {
                for (long c = 0; c < lv[0].Length; c++)
                {
                    if (lv[(int)r][(int)c] == 'S')
                        part1 = Count(r, c, 0);

                }

            }

            WriteResult(21, part1, part2, Result.oneStar);

        }
    }
}





