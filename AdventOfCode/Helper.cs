using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class Helper
    {
        protected enum Result
        {
            none,
            oneStar,
            twoStars
        }

        protected void WriteResult(int day, long? part1, long? part2, Result state)
        {
            Console.Write("{0}) ", day.ToString().PadLeft(2, ' '));
            if (state == Result.twoStars)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("** ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (state == Result.oneStar)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("*  ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write("   ");
            }
            if (part1 != null)
            {
                Console.Write("\t1 = {0}", part1);
            }
            if (part2 != null && part2 != 0)
            {
                for (int x = 0; x < 16 - (part1 != null ? part1.ToString() : "").Length; x++)
                {
                    Console.Write(" ");
                }
                Console.Write("2 = {0}", part2);
            }
            Console.WriteLine("");
        }

        protected void WriteResultStringValues(int day, string part1, string part2, Result state)
        {
            Console.Write("{0}) ", day.ToString().PadLeft(2, ' '));
            if (state == Result.twoStars)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("** ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (state == Result.oneStar)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("*  ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write("   ");
            }
            if (part1 != null)
            {
                Console.Write("\t1 = {0}", part1);
            }
            if (part2 != null)
            {
                for (int x = 0; x < 16 - (part1 != null ? part1.ToString() : "").Length; x++)
                {
                    Console.Write(" ");
                }
                Console.Write("2 = {0}", part2);
            }
            Console.WriteLine("");
        }

    }
}
