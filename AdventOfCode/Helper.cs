using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class Helper
    {
        protected enum result
        {
            none,
            silver,
            gold
        }

        protected void WriteResult(int day, long? part1, long? part2, result state)
        {
            if (state == result.gold)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("* ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (state == result.silver)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("* ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write("  ");
            }
            Console.Write(" {0})", day.ToString().PadLeft(2, ' '));
            if (part1 != null)
            {
                Console.Write("\t1 = {0}", part1);
            }
            if (part2 != null)
            {
                for (int x = 0; x < 9 - (part1 != null ? part1.ToString() : "").Length; x++)
                {
                    Console.Write(" ");
                }
                Console.Write("2 = {0}", part2);
            }
            Console.WriteLine("");
        }
    }
}
