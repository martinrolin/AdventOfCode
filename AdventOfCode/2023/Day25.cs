using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace AdventOfCode._2023
{
    class Day25 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day25.txt");
            var lv = allText.Split("\r\n").ToList();
           
            for (long r = 0; r < lv.Count; r++)
            {
                for (long c = 0; c < lv[0].Length; c++)
                {                 

                }
            }

            WriteResult(25, part1, part2, Result.none);

        }
    }
}





