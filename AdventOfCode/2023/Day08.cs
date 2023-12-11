using QuickGraph.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdventOfCode._2023
{
    class Day08 : Helper
    {
        private long GCD(long a, long b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day08.txt");
            var lv = allText.Split("\r\n").ToList();


            var q = new Queue<char>(lv[0].ToCharArray());
            var d = new Dictionary<string, (string, string)>();

            for (int i = 2; i < lv.Count; i++)
            {
                var x = lv[i].Replace(" = (", " ").Replace(",", "").Replace(")", "").Split(" ");
                d.Add(x[0], (x[1], x[2]));
            }

            List<string> ns = d.Keys.Where(x => x[2] == 'A').ToList();

            List<long> nn = new List<long>();

            for (int i = 0; i < ns.Count; i++)
            {
                var qq = q;
                var n = ns[i];
                nn.Add(0);
                while (n[2] != 'Z')
                {
                    var a = q.Dequeue();
                    q.Enqueue(a);

                    if (a == 'R')
                        n = d[n].Item2;
                    else if (a == 'L')
                        n = d[n].Item1;
                    nn[i]++;
                }

                q = qq;
                
            }

            part1 = nn[0];
            part2 = nn.Aggregate((long)1, (x, y) => x * y / GCD(x, y));

            WriteResult(8, part1, part2, Result.twoStars);

        }

        
    }
}




