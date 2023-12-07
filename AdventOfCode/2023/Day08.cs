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
        private long Part1(List<string> lv)
        {
            long part1  = 0;
            
            return part1;
        }

        private long Part2(List<string> lv)
        {
            long part2 = 0;
            
            return part2;

        }

        public void Solve()
        {                      
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day08.txt");
            var lv = allText.Split("\r\n").ToList();


            part1 = Part1(lv);
            part2 = Part2(lv);

            WriteResult(8, part1, part2, Result.none);
            
        }
    }
}




