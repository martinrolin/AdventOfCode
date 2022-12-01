using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2022
{
    class Day01 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2022\\day01.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            long sum = 0;
            for (int i = 0; i < listOfValues.Count; i++)
            {
                if (listOfValues[i] != "")
                    sum += int.Parse(listOfValues[i]);

                if (listOfValues[i] == "" || i == listOfValues.Count - 1)
                {
                    if (sum > part1)
                        part1 = sum;

                    sum = 0;
                }
            }

            List<long> sums = new List<long>{ 0,0,0};

            for (int i = 0; i < listOfValues.Count; i++)
            {
                if (listOfValues[i] != "")
                    sum += int.Parse(listOfValues[i]);

                if (listOfValues[i] == "" || i == listOfValues.Count - 1)
                {
                    if (sum > sums[0])
                    {
                        sums[0] = sum;
                        sums.Sort();
                    }

                    sum = 0;
                }
            }

            part2 = sums.Sum();

            WriteResult(1, part1, part2, result.gold);

        }
    }
}




