using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2022
{
    class Day03 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2022\\day03.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            foreach (var rucksack in listOfValues)
            {
                var c1 = rucksack.Substring(0,rucksack.Length / 2);
                var c2 = rucksack.Substring((rucksack.Length / 2), rucksack.Length / 2);

                var error = c1.Where(c => c2.ToCharArray().Contains(c)).FirstOrDefault();

                part1 += (int)error % 32;
                if (Char.IsUpper(error))
                    part1 += 26;
            }

            for (int i = 0; i < listOfValues.Count/3; i++ )
            {
                var badge = listOfValues[3*i].Where(c => listOfValues[3*i + 1].ToCharArray().Contains(c) && listOfValues[3*i + 2].ToCharArray().Contains(c)).FirstOrDefault();

                part2 += (int)badge % 32;
                if (Char.IsUpper(badge))
                    part2 += 26;
            }

            WriteResult(3, part1, part2, Result.twoStars);

        }
    }
}




