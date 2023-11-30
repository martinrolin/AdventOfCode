using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day11 : Helper
    {

        private int Simulate(int[,] octopus, int steps)
        {
            int flashed = 0;
            Queue<(int, int)> flash = new Queue<(int, int)>();


            for (int i = 0; i < steps; i++)
            {
                int allFlashed = 0;
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        allFlashed += octopus[x, y];
                        octopus[x, y]++;
                        if (octopus[x, y] == 10)
                        {
                            flash.Enqueue((x, y));
                            flashed++;
                        }

                    }
                }

                if (allFlashed == 0)
                    return i;

                while (flash.Count > 0)

                {
                    int x;
                    int y;
                    (x, y) = flash.Dequeue();
                    octopus[x, y] = 0;

                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (x + dx >= 0 && x + dx < 10 && y + dy >= 0 && y + dy < 10 && !(dx == 0 && dy == 0))
                            {
                                if (octopus[x + dx, y + dy] > 0)
                                    octopus[x + dx, y + dy]++;
                                if (octopus[x + dx, y + dy] == 10)
                                {
                                    flashed++;
                                    flash.Enqueue((x + dx, y + dy));
                                }
                            }
                        }
                    }

                }
                
            }

            return flashed;
        }

        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;

            int[,] octopus = new int[10, 10];
            string allText = File.ReadAllText("Input\\2021\\day11.txt");
            var lines = allText.Split("\r\n").ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    octopus[j, i] = Int32.Parse(lines[i][j].ToString());
                }
            }

            part1 = Simulate(octopus,100);
            part2 = 100+Simulate(octopus,Int32.MaxValue);

            WriteResult(11, part1, part2, Result.twoStars);
        }
    }
}




