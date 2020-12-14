using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day5 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day5.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            Debug.Assert(NumberFromCode('B', "BFFFBBFRRR".Substring(0, 7)) * 8 + NumberFromCode('R', "BFFFBBFRRR".Substring(7, 3)) == 567);
            Debug.Assert(NumberFromCode('B', "BBFFBBFRLL".Substring(0, 7)) * 8 + NumberFromCode('R', "BBFFBBFRLL".Substring(7, 3)) == 820);

            int maxSeat = 0;
            var allSeats = new List<int>();

            foreach (string element in listOfValues)
            {
                maxSeat = Math.Max(maxSeat, NumberFromCode('B', element.Trim().Substring(0, 7)) * 8 + NumberFromCode('R', element.Trim().Substring(7, 3)));
                allSeats.Add(NumberFromCode('B', element.Trim().Substring(0, 7)) * 8 + NumberFromCode('R', element.Trim().Substring(7, 3)));
            }

            part1 = maxSeat;

            for (int seat = 5; seat < maxSeat; seat++)
            {
                if (!allSeats.Contains(seat) && allSeats.Contains(seat + 1) && allSeats.Contains(seat - 1))
                {
                    part2 = seat;
                    break;
                }
            }
            WriteResult(5, part1, part2, result.gold);
        }


        private static int NumberFromCode(char c, string code)
        {
            int value = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == c)
                {
                    value += (int)Math.Pow(2, code.Length - 1 - i);
                }
            }

            return value;
        }
    }
}
