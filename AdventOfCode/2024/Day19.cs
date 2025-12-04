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

    class Day19 : Helper
    {
        private List<string> stripes = null;

        private Dictionary<string, long> cache = new Dictionary<string, long>();


        private long Count(string pattern)
        {
            if (pattern == "")
                return 1;
            if (cache.ContainsKey(pattern))
                return cache[pattern];
            long sum = 0;

            foreach (string stripe in stripes)
            {
                if (pattern.StartsWith(stripe))
                    sum += Count(pattern.Substring(stripe.Length));
                    
            }

            cache[pattern] = sum;
            return sum;
        }

        private bool IsValid(string pattern)
        { 
            if(pattern == "")
                return true;

            foreach (string stripe in stripes)
            {
                if (pattern.StartsWith(stripe) && IsValid(pattern.Substring(stripe.Length)))
                    return true;
            }

                return false;
        }
      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string input = File.ReadAllText("Input\\2024\\day19.txt");


            var d = input.Split("\r\n\r\n");
            stripes = d[0].Split(", ").ToList();

            foreach (var pattern in d[1].Split("\r\n").ToList())
            {
                if (IsValid(pattern))
                    part1++;
                part2 += Count(pattern);

            }




            WriteResult(19, part1, part2, Result.twoStars);

            }
        }
    }


