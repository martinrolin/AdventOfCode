using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2023
{
    class Day03 : Helper
    {

      
        public void Solve()
        {

            string allText = File.ReadAllText("Input\\2023\\day03.txt");
            var lv = allText.Split("\r\n").ToList();
            
            // Lösning i Day03.js

            WriteResult(3, 532331, 82301120, Result.twoStars);

        }
    }
}




