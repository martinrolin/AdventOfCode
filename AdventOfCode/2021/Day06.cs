using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day06 : Helper
    {

        private long Simulate(List<long> input, int days)
        {
            long[] fish = new long[9];
            foreach (var value in input)
            {
                fish[value]++;
            }

            for (int i = 0; i < days; i++)
            {
                var newFish = fish[0];
                for (int j = 0; j < 8; j++)
                {
                    fish[j] = fish[j + 1];
                }
                fish[8] = newFish;
                fish[6] += newFish;
            }

            return fish.Sum();
        }

        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day06.txt");
            var values = Array.ConvertAll(allText.Split(","),s => long.Parse(s)).ToList();

            part1 = (int)Simulate(values, 80);
            part2 = Simulate(values, 256);
            
            WriteResult(6, part1, part2, Result.twoStars);
        }
    }
}




