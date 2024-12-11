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

    class Day07 : Helper
    {

        private bool Check(long target, List<long> list, bool part2) 
        {
            if (list.Count == 1)
                return target == list[0];
            if (target % list[^1] == 0 && Check(target / list[^1], new List<long>(list.SkipLast(1)), part2))
                return true;
            if (target > list[^1] && Check(target - list[^1], new List<long>(list.SkipLast(1)),part2))
                return true;

            if (part2 && target.ToString().EndsWith(list[^1].ToString()) && target.ToString().Length > list[^1].ToString().Length && Check(long.Parse(target.ToString().Substring(0, target.ToString().Length-list[^1].ToString().Length)), new List<long>(list.SkipLast(1)), part2))
                return true;

            return false;    
        }
      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day07.txt");
            var lines = allText.Split("\r\n").ToList();

            foreach (var line in lines)
            {

                var x = line.Split(": ");
                if (Check(long.Parse(x[0]), x[1].Split(" ").Select(i => long.Parse(i)).ToList(), false))
                    part1 += long.Parse(x[0]);
                if (Check(long.Parse(x[0]), x[1].Split(" ").Select(i => long.Parse(i)).ToList(), true))
                    part2 += long.Parse(x[0]);

            }

            WriteResult(7, part1, part2, Result.twoStars);

            }
        }
    }


