﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day08 : Helper
    {

        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day08.txt");
            var lines = allText.Split("\r\n").ToList();


            WriteResult(8, part1, part2, result.none);
        }
    }
}




