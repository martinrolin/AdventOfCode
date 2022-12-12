using QuickGraph.Collections;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Xml;

namespace AdventOfCode._2022
{
    class Day13: Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day13.txt");
            var lines = allText.Split("\r\n").ToList();
            

            WriteResult(13, part1, part2, Result.none);
        }
    }
}







