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
    class Day09 : Helper
    {

        private int Find(List<int> xs, bool part2)
        {
            var Next = new List<int>();
            for (int i = 1; i < xs.Count; i++)
            {
                Next.Add(xs[i] - xs[i - 1]);
            }

            if (xs.All(x => x == 0))
                return 0;
            
            if (!part2)
                return xs.Last() + Find(Next, part2);
            else 
                return xs.First() - Find(Next, part2);
        }


        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day09.txt");
            var lv = allText.Split("\r\n").ToList();


            for (int i = 0; i < lv.Count; i++)
            {
                var xs = lv[i].Split(" ").Select(x => int.Parse(x)).ToList();
                part1 += Find(xs, false);
                part2 += Find(xs, true);
            }

          

            WriteResult(9, part1, part2, Result.twoStars);

        }

        
    }
}




