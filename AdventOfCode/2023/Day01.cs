using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2023
{
    class Day01 : Helper
    {

        private int GetNumber(string s, int i)
        {
            int l = s.Length;

            if (char.IsDigit(s[i]))
                return s[i] - '0';

            if (i + 4 <= l && s.Substring(i, 4) == "zero")
                return 0;
            if (i + 3 <= l && s.Substring(i, 3) == "one")
                return 1;
            if (i + 3 <= l && s.Substring(i, 3) == "two")
                return 2;
            if (i + 5 <= l && s.Substring(i, 5) == "three")
                return 3;
            if (i + 4 <= l && s.Substring(i, 4) == "four")
                return 4;
            if (i + 4 <= l && s.Substring(i, 4) == "five")
                return 5;
            if (i + 3 <= l && s.Substring(i, 3) == "six")
                return 6;
            if (i + 5 <= l && s.Substring(i, 5) == "seven")
                return 7;
            if (i + 5 <= l && s.Substring(i, 5) == "eight")
                return 8;
            if (i + 4 <= l && s.Substring(i, 4) == "nine")
                return 9;
            
            return -1;
        }

      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day01.txt");
            var listOfValues = allText.Split("\r\n").ToList();
            List<long> sums = new List<long>();

            for (int i = 0; i < listOfValues.Count; i++)
            {
                part1 += listOfValues[i].Where(x => char.IsDigit(x)).Select(x => x - '0').ToArray().First() * 10 + listOfValues[i].Where(x => char.IsDigit(x)).Select(x => x - '0').ToArray().Last();

                for (int j = 0; j < listOfValues[i].Length; j++)
                {
                    if (GetNumber(listOfValues[i], j) >= 0)
                    {
                        part2 += GetNumber(listOfValues[i], j) * 10;
                        break;
                    }
                }

                for (int j = listOfValues[i].Length - 1; j >= 0; j--)
                {
                    if (GetNumber(listOfValues[i], j) >= 0)
                    {
                        part2 += GetNumber(listOfValues[i], j);
                        break;
                    }
                }

            }


            WriteResult(1, part1, part2, Result.twoStars);

        }
    }
}




