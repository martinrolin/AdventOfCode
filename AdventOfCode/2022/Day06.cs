using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2022
{
    class Day06 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string code = File.ReadAllText("Input\\2022\\day06.txt");

            Queue<char> queue = new Queue<char>();

            for (int i = 0; i < code.Length; i++)
            {

                if(queue.Count== 4)
                    queue.Dequeue();

                queue.Enqueue(code[i]);

                if (i >= 4 && queue.Count() == queue.Distinct().Count())
                {
                    part1 = i + 1;
                    break;
                }
            }

            queue = new Queue<char>();

            for (int i = 0; i < code.Length; i++)
            {

                if (queue.Count == 14)
                    queue.Dequeue();

                queue.Enqueue(code[i]);

                if (i >= 14 && queue.Count() == queue.Distinct().Count())
                {
                    part2 = i + 1;
                    break;
                }
            }

            WriteResult(6, part1, part2, Result.gold);

        }

    }
}




