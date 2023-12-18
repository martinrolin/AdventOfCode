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
    class Day16 : Helper
    {

        private long Energized(List<string> lv, int r, int c, int dr, int dc)
        {
            var energized = new HashSet<(int r, int c)>();
            var visited = new HashSet<(int r, int c, int dr, int dc)>();

            var q = new Queue<(int r, int c, int dr, int dc)>();
            q.Enqueue((r, c, dr, dc));

            while (q.Count > 0)
            {
                var a = q.Dequeue();
                if (a.r < 0 || a.r >= lv.Count)
                    continue;
                if (a.c < 0 || a.c >= lv[0].Length)
                    continue;

                energized.Add((a.r, a.c));
                if (visited.Contains(a))
                    continue;
                visited.Add(a);

                if (lv[a.r][a.c] == '.')
                    q.Enqueue((a.r + a.dr, a.c + a.dc, a.dr, a.dc));

                if (lv[a.r][a.c] == '-' && Math.Abs(a.dc) == 1)
                {
                    q.Enqueue((a.r, a.c + a.dc, a.dr, a.dc));
                }
                if (lv[a.r][a.c] == '-' && Math.Abs(a.dr) == 1)
                {
                    q.Enqueue((a.r, a.c - 1, 0, -1));
                    q.Enqueue((a.r, a.c + 1, 0, 1));
                }

                if (lv[a.r][a.c] == '|' && Math.Abs(a.dr) == 1)
                {
                    q.Enqueue((a.r + a.dr, a.c, a.dr, a.dc));
                }
                if (lv[a.r][a.c] == '|' && Math.Abs(a.dc) == 1)
                {
                    q.Enqueue((a.r - 1, a.c, -1, 0));
                    q.Enqueue((a.r + 1, a.c, 1, 0));
                }
                if (lv[a.r][a.c] == '/' && a.dr == 1)
                {
                    q.Enqueue((a.r, a.c - 1, 0, -1));
                }
                if (lv[a.r][a.c] == '/' && a.dr == -1)
                {
                    q.Enqueue((a.r, a.c + 1, 0, 1));
                }
                if (lv[a.r][a.c] == '/' && a.dc == 1)
                {
                    q.Enqueue((a.r - 1, a.c, -1, 0));
                }
                if (lv[a.r][a.c] == '/' && a.dc == -1)
                {
                    q.Enqueue((a.r + 1, a.c, 1, 0));
                }

                if (lv[a.r][a.c] == '\\' && a.dr == 1)
                {
                    q.Enqueue((a.r, a.c + 1, 0, 1));
                }
                if (lv[a.r][a.c] == '\\' && a.dr == -1)
                {
                    q.Enqueue((a.r, a.c - 1, 0, -1));
                }
                if (lv[a.r][a.c] == '\\' && a.dc == 1)
                {
                    q.Enqueue((a.r + 1, a.c, 1, 0));
                }
                if (lv[a.r][a.c] == '\\' && a.dc == -1)
                {
                    q.Enqueue((a.r - 1, a.c, -1, 0));
                }



            }

            return energized.Count;
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day16.txt");
            var lv = allText.Split("\r\n").ToList();

            part1 = Energized(lv, 0, 0, 0, 1);

            for (int i = 0; i < lv.Count; i++)
            {
                part2 = Math.Max(part2, Energized(lv, i, 0, 0, 1));
                part2 = Math.Max(part2, Energized(lv, i, lv[0].Length - 1, 0, -1));

            }
            for (int i = 0; i < lv[0].Length; i++)
            {
                part2 = Math.Max(part2, Energized(lv, 0, i, 1, 0));
                part2 = Math.Max(part2, Energized(lv, lv.Count-1, i, -1, 0));
            }

            WriteResult(16 , part1, part2, Result.twoStars);
        }
    }
}





