using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2022
{
    class Day02 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2022\\day02.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            for (int i = 0; i < listOfValues.Count; i++)
            {
                var start = listOfValues[i].Split(" ")[0];
                var response = listOfValues[i].Split(" ")[1];
                

                if (start == "A") {                    
                    if (response == "X")
                    {
                        part1 += 1 + 3;
                        part2 += 3 + 0;
                    }
                    if (response == "Y")
                    {
                        part1 += 2 + 6;
                        part2 += 1 + 3;

                    }
                    if (response == "Z")
                    {
                        part1 += 3 + 0;
                        part2 += 2 + 6;
                    }
                }
                if (start == "B")
                {
                    
                    if (response == "X")
                    {
                        part1 += 1 + 0;
                        part2 += 1 + 0;
                    }
                    if (response == "Y")
                    {
                        part1 += 2 + 3;
                        part2 += 2 + 3;
                    }
                    if (response == "Z")
                    {
                        part1 += 3 + 6;
                        part2 += 3 + 6;
                    }
                }
                if (start == "C")
                {                    
                    if (response == "X")
                    {
                        part1 += 1 + 6;
                        part2 += 2 + 0;
                    }
                    if (response == "Y")
                    {
                        part1 += 2 + 0;
                        part2 += 3 + 3;
                    }
                    if (response == "Z")
                    {
                        part1 += 3 + 3;
                        part2 += 1 + 6;
                    }
                }
            }

            WriteResult(2, part1, part2, Result.gold);

        }
    }
}




