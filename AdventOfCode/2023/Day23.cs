using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace AdventOfCode._2023
{
    class Day23 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day23.txt");
            var lv = allText.Replace("<",".").Replace(">", ".").Replace("^", ".").Replace("v", ".").Split("\r\n").ToList();

            var directions = new List<(char ch, int r, int c)>();

            directions.Add(('^',-1, 0));
            directions.Add(('v',1, 0));
            directions.Add(('<',0, -1));
            directions.Add(('>',0, 1));

            var q = new Queue<(int r,int c,int x, HashSet<(int,int)> v)>();
            var visited = new HashSet<(int r, int c)>();

            visited.Add((0, 1));
            part1 = 0;
            q.Enqueue((1, 1, 0, visited));
            while (q.Count > 0)
            {
                var p = q.Dequeue();

                if (p.v.Contains((p.r, p.c)))
                    continue;
                if (p.r == lv.Count)
                    part1 = Math.Max(part1,p.x);
                if (p.r == lv.Count || lv[p.r][p.c] == '#')
                    continue;

                foreach (var d in directions)
                {
                    if (lv[p.r][p.c] == d.ch || lv[p.r][p.c] == '.')
                    {

                        var nv = new HashSet<(int r, int c)>(p.v);
                        nv.Add((p.r,p.c));
                        q.Enqueue((p.r + d.r, p.c + d.c, p.x + 1, nv));

                    }

                }
 

            }



            WriteResult(23, part1, part2, Result.none);

        }
    }
}





