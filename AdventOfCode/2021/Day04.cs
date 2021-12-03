using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day04 : Helper
    {

        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day04.txt");
            var listOfValues = allText.Split("\r\n").ToList();
            
            for (int i = 0; i < listOfValues.Count; i++)
            {
                
            }
            
            WriteResult(4, part1, part2, result.none);
        }
    }
}




