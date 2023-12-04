using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2023
{
    class Day05 : Helper
    {

      
        public void Solve()
        {
           
            
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day05.txt");
            var lv = allText.Split("\r\n").ToList();
           

            for (int i = 0; i < lv.Count; i++)
            {
             
            }


            WriteResult(5, part1, part2, Result.none);

        }
    }
}




