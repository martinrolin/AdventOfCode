using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode._2024
{

    class Day06 : Helper
    {
      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day06.txt");
            var v = allText.Split("\r\n\r\n").ToList();

            WriteResult(6, part1, part2, Result.none);

            }
        }
    }


