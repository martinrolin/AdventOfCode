using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2024
{

    class Day01 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day01.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < listOfValues.Count; i++)
            {
                var x = listOfValues[i].Split("  ");
                left.Add(int.Parse(x[0]));                    
                right.Add(int.Parse(x[1]));
            }

            left.Sort();
            right.Sort();
            for (int i = 0; i < listOfValues.Count; i++)
            {
                part1 += Math.Abs(left[i] - right[i]);
            }

            for (int i = 0; i < listOfValues.Count; i++)
            {
                part2 += left[i] * right.Where(r => r == left[i]).Count();
            }                          
             
            WriteResult(1, part1, part2, Result.twoStars);

            }
        }
    }


