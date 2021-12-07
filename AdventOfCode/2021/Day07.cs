using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day07 : Helper
    {

        private int CalculateFuel(List<int> values, bool partOne) 
        {
            var fuel = Int32.MaxValue;

            for (int i = values.Min(); i <= values.Max(); i++)
            {
                var temp = 0;
                for (int j = 0; j < values.Count; j++)
                {
                    if (partOne)
                        temp += Math.Abs(values[j] - i);
                    else
                        temp += Math.Abs(values[j] - i) * (Math.Abs(values[j] - i) + 1 ) / 2;                    
                }
                if (temp < fuel)
                    fuel = temp;

            }

            return fuel;
        }

        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day07.txt");
            var values = Array.ConvertAll(allText.Split(","),s => Int32.Parse(s)).ToList();
            
            

            part1 = CalculateFuel(values, true);
            part2 = CalculateFuel(values, false);

            WriteResult(7, part1, part2, result.gold);
        }
    }
}




