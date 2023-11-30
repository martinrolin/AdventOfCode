using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2022
{
    class Day04 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2022\\day04.txt");
            var lines = allText.Split("\r\n").ToList();

            foreach (var line in lines)
            {
                var val = line.Split(new char[] { '-', ',' }).Select(x => int.Parse(x)).ToList();

                if ((val[0] <= val[2] && val[1] >= val[3]) || (val[0] >= val[2] && val[1] <= val[3]))
                    part1++;

                if ((val[0] >= val[2] && val[0] <= val[3]) || (val[1] >= val[2] && val[1] <= val[3]) || (val[2] >= val[0] && val[2] <= val[1]) || (val[3] >= val[0] && val[3] <= val[1]))
                    part2++;

            }


            WriteResult(4, part1, part2, Result.twoStars);

        }
    }
}




