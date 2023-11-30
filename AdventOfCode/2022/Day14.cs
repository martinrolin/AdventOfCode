using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;


namespace AdventOfCode._2022
{
    class Day14 : Helper
    {
        private void Print(Dictionary<(int, int),string> map, int sx, int sy)
        {
            Console.Clear();
            for (int y = 0; y < 15; y++)
            {
                for (int x = 490; x < 520; x++)
                {
                    if (map.ContainsKey((x, y)))
                        Console.Write(map[(x, y)]);
                    else if (sx == x && sy == y)
                        Console.Write("O");
                    else
                        Console.Write(" ");

                }
                Console.WriteLine("");
            }
        }

        private (int,int) Part1(List<string> lines)
        {
            var part1 = 0;
            var map = new Dictionary<(int, int), string>();
            var maxY = 0;
            foreach (var line in lines)
            {
                var c = line.Replace(" -> ", ",").Split(',');
                var lx = -1;
                var ly = -1;
                for (int i = 0; i < c.Count(); i += 2)
                {
                    var x = int.Parse(c[i]);
                    var y = int.Parse(c[i + 1]);

                    maxY = Math.Max(y, maxY);

                    if (i == 0)
                    {
                        if (!map.ContainsKey((x, y)))
                            map.Add((x, y), "#");
                        lx = x;
                        ly = y;
                    }
                    else
                    {
                        var step = (0, 0);
                        if (x == lx && y < ly)
                            step = (0, -1);
                        else if (x == lx && y > ly)
                            step = (0, 1);
                        else if (x < lx && y == ly)
                            step = (-1, 0);
                        else if (x > lx && y == ly)
                            step = (1, 0);

                        while (lx != x || ly != y)
                        {
                            lx += step.Item1;
                            ly += step.Item2;
                            if (!map.ContainsKey((lx, ly)))
                                map.Add((lx, ly), "#");
                        }

                    }
                }
            }

            //Print(map, 500, 0);
            var t = true;
            while (t)
            {
                var sx = 500;

                for (int y = 0; y <= maxY + 1; y++)
                {
                    if (y == maxY)
                    {
                        t = false;
                        break;
                    }
                    if (!map.ContainsKey((sx, y + 1)))
                    {
                        //Print(map, sx, y);
                        continue;
                    }
                    if (map.ContainsKey((sx, y + 1)) && (!map.ContainsKey((sx - 1, y + 1)) || !map.ContainsKey((sx + 1, y + 1))))
                    {

                        if (!map.ContainsKey((sx - 1, y + 1)))
                            sx--;
                        else if (!map.ContainsKey((sx + 1, y + 1)))
                            sx++;
                    }
                    else
                    {
                        part1++;
                        map.Add((sx, y), "O");
                        //Print(map, sx, y);
                        break;
                    }

                    //Print(map, sx, y);
                }

            }
            return (part1, maxY);
        }
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day14.txt");
            var lines = allText.Split("\r\n").ToList();
            var maxY = 0;
            (part1, maxY) = Part1(lines);
            maxY += 2;
            lines.Add("0,"+maxY+" -> 1000," + maxY);


            var a = (1, 1);
            var b = (5, 1);

            var test = Enumerable.Zip(Enumerable.Range(a.Item1, b.Item1), Enumerable.Range(a.Item2, b.Item2));


            var map = new Dictionary<(int, int),string>();
            foreach (var line in lines)
            {
                var c = line.Replace(" -> ",",").Split(',');
                var lx = -1;
                var ly = -1;
                for (int i = 0; i < c.Count(); i += 2)
                {
                    var x = int.Parse(c[i]);
                    var y = int.Parse(c[i + 1]);

                    maxY = Math.Max(y, maxY);

                    if (i == 0)
                    {
                        if (!map.ContainsKey((x, y)))
                            map.Add((x, y),"#");
                        lx = x;
                        ly = y;
                    }
                    else
                    {
                        var step = (0, 0);
                        if (x == lx && y < ly)
                            step = (0, -1);
                        else if (x == lx && y > ly)
                            step = (0, 1);
                        else if (x < lx && y == ly)
                            step = (-1, 0);
                        else if (x > lx && y == ly)
                            step = (1, 0);

                        while (lx != x || ly != y)
                        {
                            lx += step.Item1;
                            ly += step.Item2;
                            if (!map.ContainsKey((lx, ly)))
                                map.Add((lx, ly),"#");
                        }

                    }
                }
            }

            var t = true;
            while (t)
            {
                var sx = 500;
                
                for (int y = 0; y <= maxY+1; y++)
                {
                    if (y == maxY)
                    {
                        t = false;
                        break;
                    }
                    if (!map.ContainsKey((sx, y + 1)))
                    {
                        continue;
                    }
                    if (map.ContainsKey((sx, y + 1)) && (!map.ContainsKey((sx - 1, y + 1)) || !map.ContainsKey((sx + 1, y + 1))))
                    {

                        if (!map.ContainsKey((sx - 1, y + 1)))
                            sx--;
                        else if (!map.ContainsKey((sx + 1, y + 1)))
                            sx++;                        
                    } 
                    else
                    { 
                        part2++;
                        if (sx == 500 && y == 0)
                            t = false;
                        map.Add((sx, y), "O");
                        break;
                    }
                }
            
            }
            
            WriteResult(14, part1, part2, Result.twoStars);
        }
    }
}







