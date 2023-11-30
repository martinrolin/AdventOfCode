using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day02 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day02.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            int distance = 0;
            int depthPartOne = 0;
            int depthPartTwo = 0;
            int aim = 0;

            for (int i = 0; i < listOfValues.Count - 1; i++)
            {
                if (listOfValues[i].Contains("forward")) {
                    distance += Int32.Parse(listOfValues[i].Replace("forward ", ""));
                    depthPartTwo += aim * Int32.Parse(listOfValues[i].Replace("forward ", ""));
                } 
                else if (listOfValues[i].Contains("down"))
                {
                    depthPartOne += Int32.Parse(listOfValues[i].Replace("down ", ""));
                    aim += Int32.Parse(listOfValues[i].Replace("down ", ""));
                } else if (listOfValues[i].Contains("up"))
                {
                    depthPartOne -= Int32.Parse(listOfValues[i].Replace("up ", ""));
                    aim -= Int32.Parse(listOfValues[i].Replace("up ", ""));
                }                
            }

            part1 = distance * depthPartOne;
            part2 = distance * depthPartTwo;

            WriteResult(2, part1, part2, Result.twoStars);

        }
    }
}




