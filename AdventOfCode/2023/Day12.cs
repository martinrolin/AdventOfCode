using QuickGraph.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdventOfCode._2023
{
    class Day12 : Helper
    {

        private int cachecalls = 0;
        private Dictionary<(string, string), long> cache = new Dictionary<(string, string), long>();

        public long Count(string cfg, int[] nums)
        {
            if (cfg == "")
            {
                return nums.Length == 0 ? 1 : 0;
            }

            if (nums.Length == 0)
            {
                return cfg.Contains("#") ? 0 : 1;
            }

            string numkey = String.Join(",",nums.Select(x => x.ToString()));

            if (cache.ContainsKey((cfg, numkey)))
            {
                cachecalls++;
                return cache[(cfg, numkey)];
            }

            long result = 0;

            if (cfg[0] == '.' || cfg[0] == '?')
            {
                result += Count(cfg.Substring(1), nums);
            }

            if (cfg[0] == '#' || cfg[0] == '?')
            {
                if (nums[0] <= cfg.Length && !cfg.Substring(0, nums[0]).Contains('.') && (nums[0] == cfg.Length || cfg[nums[0]] != '#'))
                {
                    var ss = "";
                    if (nums[0] < cfg.Length)
                        ss = cfg.Substring(nums[0] + 1);
                    
                    result += Count(ss, nums.Skip(1).ToArray());
                    
                }
            }

            cache.Add((cfg, numkey), result);

            return result;
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day12.txt");
            var lv = allText.Split("\r\n").ToList();

            foreach(string line in lv)
            {
                string[] parts = line.Split();
                string cfg = parts[0];
                int[] nums = parts[1].Split(',').Select(int.Parse).ToArray();
                part1 += Count(cfg, nums);

                cfg = parts[0];
                string numbers = parts[1];
                for (int i = 0; i < 4; i++) 
                {
                    cfg += "?" + parts[0];
                    numbers += "," + parts[1];
                }
                nums = numbers.Split(',').Select(int.Parse).ToArray();
                part2 += Count(cfg, nums);



                
            }

            WriteResult(12 , part1, part2, Result.twoStars);

        }

        
    }
}





