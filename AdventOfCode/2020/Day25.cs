using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day25 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            string allText = File.ReadAllText("Input\\2020\\day25.txt");
            var publicKeys = allText.Split("\r\n").Select(k => Int64.Parse(k)).ToList();

            long key = 1;

            long x = 0;
            while (key != publicKeys[0])
            {
                key = (key * 7) % 20201227;
                x++;
            }

            key = 1;
            for (var j = 1; j <= x; j++)
            {
                key = (key * publicKeys[1]) % 20201227;
            }

            part1 = key;

            WriteResult(25, part1, null, Result.gold);
        }
    }
}
