using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day09 : Helper
    {

        private (int,List<(int,int)>) CalculateRiskLevel(int[,] map)
        {
            int riskLevel = 0;
            List<(int, int)> lowPoints = new List<(int, int)>();
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    int low = 0;
                    if (y == 0 || map[x, y] < map[x, y-1])
                        low++;
                    if (y == map.GetLength(1)-1 || map[x, y] < map[x, y+1])
                        low++;
                    if (x == 0 || map[x, y] < map[x-1, y])
                        low++;
                    if (x == map.GetLength(0) - 1 || map[x, y] < map[x+1, y])
                        low++;

                    if (low == 4)
                    {
                        riskLevel += map[x, y] + 1;
                        lowPoints.Add((x, y));
                    }
                }
            }
            return (riskLevel,lowPoints);
        }


        private int Basin(int[,] map, int x, int y, List<(int,int)> thisBasin)
        {
            if (thisBasin.Contains((x, y)))
                return 0;

            thisBasin.Add((x, y));
            int sum = 1;

            if(x < map.GetLength(0) - 1 && map[x + 1, y] != 9 && map[x,y] < map[x+1,y])
                sum += Basin(map, x + 1, y, thisBasin);
            if (x > 0  && map[x - 1, y] != 9 && map[x, y] < map[x - 1, y])
                sum += Basin(map, x - 1, y, thisBasin);
            if (y < map.GetLength(1) - 1 && map[x, y+1] != 9 &&  map[x, y] < map[x, y+1])
                sum += Basin(map, x, y + 1 , thisBasin);
            if (y > 0 && map[x, y - 1] != 9 && map[x, y] < map[x, y-1] )
                sum += Basin(map, x, y-1, thisBasin);

            return sum;
        }


        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day09.txt");
            var lines = allText.Split("\r\n").ToList();

            var width = lines[0].Length;
            var height = lines.Count;

            int[,] map = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x, y] = Int32.Parse(lines[y][x].ToString());
                }
            }

            
            List<(int,int)> lowPoints;

            (part1, lowPoints) = CalculateRiskLevel(map);

            List<int> sizeOfBasins = new List<int>();
            foreach (var lowPoint in lowPoints)
            {
                sizeOfBasins.Add(Basin(map,lowPoint.Item1, lowPoint.Item2,new List<(int,int)>()));
            }

            sizeOfBasins.Sort();
            sizeOfBasins.Reverse();
            part2 = sizeOfBasins.Take(3).Aggregate(1, (x, y) => x * y);

            WriteResult(9, part1, part2, result.gold);
        }
    }
}




