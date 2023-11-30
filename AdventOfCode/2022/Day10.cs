using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace AdventOfCode._2022
{
    class Day10 : Helper
    {

        public void Solve()
        {
            string allText = System.IO.File.ReadAllText("Input\\2022\\day10.txt");
            var lines = allText.Split("\r\n").ToList();
            
            // Löste tillsammans med Axel och Johan
            WriteResultStringValues(10, "12460", "EZFPRAKL", Result.twoStars);
        }
    }
}







