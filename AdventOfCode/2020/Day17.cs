using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2020
{
    class Day17 : Helper
    {
        char[,,,] currentState = new char[100, 100, 100, 100];
        char[,,,] nextState = new char[100, 100, 100, 100];
        char[,,,] originalState = new char[100, 100, 100, 100];


        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day17.txt");
            var lines = allText.Split("\r\n").ToList();
            var offset = 50;

            for (int row = 0; row < lines.Count; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    currentState[offset + row, offset + col, offset,offset] = lines[row][col];
                    originalState[offset + row, offset + col, offset, offset] = lines[row][col];
                }
            }
            for (int i = 0; i < 6; i++)
            {
                NextCycle(i);
                
            }
            part1 = CountActive();

            currentState = (char[,,,])originalState.Clone();
            for (int i = 0; i < 6; i++)
            {
                NextCycle(i, true);
            
            }
            part2 = CountActive();

            WriteResult(17, part1, part2, result.gold);
        }

        private void NextCycle(int cycle, bool part2 = false) {
            var limit = cycle + 11;
            var wLimit = part2 ? limit + 3 : 0;
            for (int w = -wLimit; w <= wLimit; w++)
            {
                for (int z = -limit; z < limit + 3 ; z++)
                {
                    for (int y = -limit; y < limit + 3; y++)
                    {
                        for (int x = -limit; x < limit + 3; x++)
                        {
                            int numberOfNeighbours = countNeighbours(y, x, z, w);
                            if (IsPositionActive(y, x, z, w) == 1 && (numberOfNeighbours == 2 || numberOfNeighbours == 3))
                            {
                                nextState[50 + y, 50 + x, 50 + z, 50 + w] = '#';
                            }
                            else if (IsPositionActive(y, x, z, w) == 0 && numberOfNeighbours == 3)
                            {
                                nextState[50 + y, 50 + x, 50 + z, 50 + w] = '#';
                            }
                            else
                            {
                                nextState[50 + y, 50 + x, 50 + z, 50 + w] = '.';
                            }
                        }
                    }
                }
            }
            currentState = (char[,,,])nextState.Clone();
        }

        private int CountActive()
        {
            int numberOfActive = 0;
            for (int w = -20; w < 20; w++)
            {
                for (int z = -20; z < 20; z++)
                {
                    for (int y = -20; y < 20; y++)
                    {
                        for (int x = -20; x < 20; x++)
                        {
                            if (IsPositionActive(y, x, z, w) == 1)
                                numberOfActive++;
                        }
                    }
                }
            }

            return numberOfActive;
        }

        private int countNeighbours(int y, int x, int z, int w) {
            int activeNeighbours = 0;
            for (int dw = -1; dw <= 1; dw++)
            {
                for (int dz = -1; dz <= 1; dz++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            if (dx == 0 && dy == 0 && dz == 0 && dw == 0)
                                continue;
                            else
                                activeNeighbours += IsPositionActive(y + dy, x + dx, z + dz, w + dw);
                        }
                    }
                }
            }

            return activeNeighbours;
        }

        private int IsPositionActive(int y, int x, int z, int w) {
            if (currentState[50 + y, 50 + x, 50 + z, 50 + w] == '#')
                return 1;
            else
                return 0;
        }

    }
}


