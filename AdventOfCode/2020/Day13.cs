﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day13 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("input\\2020_day13.txt");
            var lines = allText.Split("\r\n").ToList();
            WriteResult(13, part1, part2, result.none);
        }
    }
}
