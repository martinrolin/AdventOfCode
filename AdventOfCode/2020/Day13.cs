using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AdventOfCode._2020
{
    class Day13 : Helper
    {
        public void Solve()
        {
            int part1 = Int32.MaxValue;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day13.txt");
            var lines = allText.Split("\r\n").ToList();


            var value = Int32.Parse(lines[0]);
            var arr = lines[1].Split(",");
            var mintime = Int32.MaxValue;
            // Part 1
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "x")
                    continue;

                if (Int32.Parse(arr[i]) * (int)Math.Ceiling(value / (double)Int32.Parse(arr[i])) < mintime) {
                    mintime = Int32.Parse(arr[i]) * (int)Math.Ceiling(value / (double)Int32.Parse(arr[i]));
                    part1 = (Int32.Parse(arr[i]) * (int)Math.Ceiling(value / (double)Int32.Parse(arr[i])) - value) * Int32.Parse(arr[i]);
                }               
            }


            // Part 2
            var N = new List<long>();
            var A = new List<long>();
            var NA = new Dictionary<long,long>();
            var offset = 0;
            var max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != "x")
                {
                    N.Add(Int32.Parse(arr[i]));
                    A.Add(Int32.Parse(arr[i]) - offset);
                    NA.Add(Int32.Parse(arr[i]), (Int32.Parse(arr[i]) - (offset % Int32.Parse(arr[i]))) % Int32.Parse(arr[i]));

                    max = Math.Max(Int32.Parse(arr[i]), max);
                }
                offset++;
            }

            part2 = ChineseRemainderTheorem.Solve(N.ToArray(), A.ToArray());


            WriteResult(13, part1, part2, Result.twoStars);

            // Slow part 2
            return;
            //long startTime = max * (long)(100000000000000 / max) + NA[max];
            //long t;
            //var found = false;

            //long count = 0;
            //while (!found)
            //{
            //    t = startTime;
            //    part2 = startTime;

            //    var allfound = true;
            //    foreach (var item in NA.Keys)
            //    {
            //        if (t % item != NA[item])
            //        {
            //            startTime += max;
            //            count += max;
            //            allfound = false;
            //            break;
            //        }

            //    }

            //    if (allfound)
            //    {
            //        found = true;                    
            //    }
                   
            //}
        }

        
    }



}
