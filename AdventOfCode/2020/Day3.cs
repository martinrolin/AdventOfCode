using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day3 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day3.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            part1 = CountTrees(1, 3, listOfValues);


            long p2 = CountTrees(1, 1, listOfValues) * CountTrees(1, 3, listOfValues) * CountTrees(1, 5, listOfValues) * CountTrees(1, 7, listOfValues) * CountTrees(2, 1, listOfValues);
            part2 = p2;
            WriteResult(3, part1, part2, Result.gold);
        }

        private long CountTrees(int down, int side, List<String> map)
        {
            int row = 0;
            int col = 0;
            int trees = 0;
            while (row < map.Count)
            {
                if (map[row][col] == '#')
                {
                    trees++;
                }
                col = col + side;
                if (col >= map[row].Length)
                {
                    col = col - map[row].Length;
                }
                row += down;

            }

            return trees;
        }
    }
}
