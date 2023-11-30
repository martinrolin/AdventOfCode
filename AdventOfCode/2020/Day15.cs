using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day15 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day15.txt");
            var numbers = allText.Split(",").ToList();
            
            int lastSpoken = 0;
            Dictionary<int, int> spokenWhen = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
                spokenWhen[Int32.Parse(numbers[i])] = i;
                            
            lastSpoken = Int32.Parse(numbers[^1]);

            for (int i = numbers.Count; i < 30000000; i++)
            {
                var next = 0;
                if (spokenWhen.ContainsKey(lastSpoken))
                    next = i - 1 - spokenWhen[lastSpoken];                
                
                spokenWhen[lastSpoken] = i - 1;
                lastSpoken = next;

                if (i == 2019)
                    part1 = lastSpoken;               
            }
            part2 = lastSpoken;

            WriteResult(15, part1, part2, Result.twoStars);
        }
    }
}
