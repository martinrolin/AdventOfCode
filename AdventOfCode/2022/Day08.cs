using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace AdventOfCode._2022
{
    class Day08 : Helper
    {
     
       

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day08.txt");
            var lines = allText.Split("\r\n").ToList();

            Dictionary<(int, int), int> heightMap = new Dictionary<(int, int), int>();
            Dictionary<(int, int), bool> map = new Dictionary<(int, int), bool>();

            int maxY = lines.Count;
            int maxX = lines[0].Length;

            for (int y = 0; y < lines.Count; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    heightMap[(x, y)] = int.Parse(lines[y][x].ToString());
                }

            }


            var maxHeight = -1;
            for (int x = 0; x < maxX; x++) {
                maxHeight = -1;
                for (int y = 0; y < maxY; y++)
                {
                    var thisH = heightMap[(x, y)];
                    if (heightMap[(x, y)] > maxHeight)
                    {
                        map[(x, y)] = true;
                        maxHeight = heightMap[(x, y)];
                    }
                    else if (heightMap[(x, y)] == 9)
                        break;


                }
            }
                for (int y = 0; y < maxY; y++)
            {
                maxHeight = -1;
            for (int x = 0; x < maxX; x++)
                {
                    if (heightMap[(x, y)] > maxHeight)
                    {
                        map[(x, y)] = true;
                        maxHeight = heightMap[(x, y)];
                    }
                    else if (heightMap[(x, y)] == 9)
                        break;


                }
            }
            for (int x = maxX - 1; x >= 0; x--)
            {
                maxHeight = -1;
                for (int y = maxY-1; y >=0; y--)
                {
                    if (heightMap[(x, y)] > maxHeight)
                    {
                        map[(x, y)] = true;
                        maxHeight = heightMap[(x, y)];
                    }
                    else if (heightMap[(x, y)] == 9)
                        break;


                }
            }
            for (int y = maxY - 1; y >= 0; y--)
            {
            maxHeight = -1;
                {
                for (int x = maxX - 1; x >= 0; x--)
                    if (heightMap[(x, y)] > maxHeight)
                        {
                            map[(x, y)] = true;
                            maxHeight = heightMap[(x, y)];
                        }
                        else if (heightMap[(x, y)] == 9)
                            break;


                }
            }

            part1 = map.Values.Where(x => x == true).Count();

            foreach (var tree in heightMap)

            {
                var score = 1;
                var value = 0;
                var x = tree.Key.Item1;
                var y = tree.Key.Item2;

                x = tree.Key.Item1-1;
                value = 0;
                while (x >= 0) {
                    if (heightMap[(x, tree.Key.Item2)] < heightMap[tree.Key])
                        value++;
                    else
                    {
                        value++;
                        break;
                    }
                    x--;
                }
                score *= value;

                y = tree.Key.Item2 - 1;
                value = 0;
                while (y >= 0)
                {
                    if (heightMap[(tree.Key.Item1, y)] < heightMap[tree.Key])
                        value++;
                    else
                    {
                        value++;
                        break;
                    }
                    y--;
                }
                score *= value;

                x = tree.Key.Item1 + 1;
                value = 0;
                while (x < maxX)
                {
                    if (heightMap[(x, tree.Key.Item2)] < heightMap[tree.Key])
                        value++;
                    else
                    {
                        value++;
                        break;
                    }
                    x++;
                }
                score *= value;

                y = tree.Key.Item2 + 1;
                value = 0;
                while (y < maxY)
                {
                    if (heightMap[(tree.Key.Item1, y)] < heightMap[tree.Key])
                        value++;
                    else
                    {
                        value++;
                        break;
                    }
                    y++;
                }
                score *= value;

                if (score > part2)
                    part2 = score;

            }

            WriteResult(8, part1, part2, Result.twoStars);
        }
    }
}







