using QuickGraph.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdventOfCode._2023
{
    class Day06 : Helper
    {

        public void Solve()
        {                      
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day06.txt");
            var lv = allText.Split("\r\n").ToList();

            var t = Regex.Matches(lv[0], "-?\\d+").Select(x => int.Parse(x.Value)).ToList();
            var d = Regex.Matches(lv[1], "-?\\d+").Select(x => int.Parse(x.Value)).ToList();

            part1 = 1;
            for (int i = 0; i < t.Count; i++)
            {
                var w = 0;
                for (int j = 1; j < t[i]; j++)
                    if (j * (t[i] - j) > d[i])
                        w++;
                part1 *= w;
            }

            long tt = long.Parse(String.Join("",Regex.Matches(lv[0], "-?\\d+").Select(x => x.Value).ToList()));
            long dd = long.Parse(String.Join("", Regex.Matches(lv[1], "-?\\d+").Select(x => x.Value).ToList()));


            long ss = 0;           

            for (long j = 1; j < tt; j+=1000)
            {
                if (j * (tt - j) > dd)
                {
                    for (long k = j; k > 0; k--)
                    {
                        if (k * (tt - k) < dd)
                        {
                            ss += k;                           
                            break;
                        }
                    }
                    break;
                }
            }

            for (long j = tt; j > 0; j -=1000)
            {
                if (j * (tt - j) > dd)
                {
                    for (long k = j; k < tt; k++)
                    {
                        if (k * (tt - k) < dd)
                        {
                            ss += (tt-k);                            
                            break;
                        }
                    }
                    break;
                }
            }

            part2 = tt-ss-1;   

            WriteResult(6, part1, part2, Result.twoStars);

        }
    }
}




