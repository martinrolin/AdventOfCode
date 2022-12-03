using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day11 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day11.txt");
            var lines = allText.Split("\r\n").ToList();
            char[,] map = new char[lines.Count, lines[0].Length];

            for (int row = 0; row < lines.Count; row++)
            {
                for (int col = 0; col < lines[0].Length; col++)
                {
                    map[row, col] = lines[row][col];
                }
            }

            char[,] nextMap = (char[,])map.Clone();
            char[,] original = (char[,])map.Clone();

            do
            {
                map = nextMap;
                nextMap = nextStep1(map, 0, 4);
            } while (CountSeats(map) != CountSeats(nextMap));

            part1 = CountSeats(map);

            nextMap = original;
            do
            {
                map = nextMap;
                nextMap = nextStep1(map, 1, 5);
            } while (CountSeats(map) != CountSeats(nextMap));
            part2 = CountSeats(map);

            WriteResult(11, part1, part2, Result.gold);
        }

        private static void Print(char[,] map, bool adjacent)
        {
            Console.WriteLine("");
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (adjacent)
                    {
                        Console.Write(countAdjacent(map, row, col, 1));
                    }
                    else
                    {
                        Console.Write(map[row, col]);
                    }
                }
                Console.WriteLine("");
            }

        }

        private static char[,] nextStep1(char[,] map, int step, int limit)
        {
            char[,] n = (char[,])map.Clone();


            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (countAdjacent(map, row, col, step) == 0 && map[row, col] == 'L')
                    {
                        n[row, col] = '#';
                    }
                    if (countAdjacent(map, row, col, step) >= limit && map[row, col] == '#')
                    {
                        n[row, col] = 'L';
                    }
                }
            }
            return n;
        }

        private static int findSeat(char[,] map, int row, int col, int dr, int dc, int step)
        {
            row += dr;
            col += dc;
            if (row < 0 || col < 0 || row >= map.GetLength(0) || col >= map.GetLength(1))
            {
                return 0;
            }
            if (step == 1 && map[row, col] == 'L')
            {
                return 0;
            }
            if (step == 0 && (map[row, col] == 'L' || map[row, col] == '.'))
            {
                return 0;
            }
            if (map[row, col] == '#')
            {
                return 1;
            }
            else if (step == 0)
            {
                return 0;
            }
            else
            {
                return findSeat(map, row, col, dr, dc, step);
            }
        }

        private static int countAdjacent(char[,] map, int row, int col, int step)
        {
            int up = findSeat(map, row, col, -1, 0, step);
            int upright = findSeat(map, row, col, -1, 1, step);
            int right = findSeat(map, row, col, 0, 1, step);
            int downright = findSeat(map, row, col, 1, 1, step);
            int down = findSeat(map, row, col, 1, 0, step);
            int downleft = findSeat(map, row, col, 1, -1, step);
            int left = findSeat(map, row, col, 0, -1, step);
            int upleft = findSeat(map, row, col, -1, -1, step);

            return up + upright + right + downright + down + downleft + left + upleft;
        }

        private static int CountSeats(char[,] map)
        {
            int seats = 0;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (map[row, col] == '#')
                    {
                        seats++;

                    }
                }
            }
            return seats;
        }

    }
}
