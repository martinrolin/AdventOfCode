﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day21 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day21.txt");
            var lines = allText.Split("\r\n").ToList();
            foreach (var line in lines)
            {
            }


            WriteResult(21, part1, part2, result.none);
        }
    }
}