using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2024
{

    class Day02 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day02.txt");
            var listOfValues = allText.Split("\r\n").ToList();

             
            WriteResult(2, part1, part2, Result.none);

            }
        }
    }


