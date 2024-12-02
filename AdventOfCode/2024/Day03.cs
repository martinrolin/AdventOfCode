using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2024
{

    class Day03 : Helper
    {
      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day03.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            foreach (var value in listOfValues)
            {
                var x = value.Split(" ").ToList<string>();
            }

            WriteResult(3, part1, part2, Result.none);

            }
        }
    }


