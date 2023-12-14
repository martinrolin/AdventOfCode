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
    class Day15 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day15.txt");
            var lv = allText.Split("\r\n").ToList();

            
            for (int r = 0; r < lv.Count; r++)
            {
               
            }
            

            WriteResult(15 , part1, part2, Result.none);

        }

        
    }
}





