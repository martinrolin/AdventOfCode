using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2022
{
    class Day17 : Helper
    {

        private List<(long,long)> CreateRock(long type)
        {
            var rock = new List<(long,long)>();
            if (type == 0)
            {
                rock.Add((-1, 0));
                rock.Add((0, 0));
                rock.Add((1, 0));
                rock.Add((2, 0));
            }
            else if (type == 1)
            {
                rock.Add((0, 0));
                rock.Add((0, 1));
                rock.Add((0, 2));
                rock.Add((-1, 1));
                rock.Add((1, 1));
            }
            else if (type == 2)
            {
                rock.Add((-1, 0));
                rock.Add((0, 0));
                rock.Add((1, 0));
                rock.Add((1, 1));
                rock.Add((1, 2));
            }
            if (type == 3)
            {
                rock.Add((-1, 0));
                rock.Add((-1, 1));
                rock.Add((-1, 2));
                rock.Add((-1, 3));                
            }
            if (type == 4)
            {
                rock.Add((-1, 0));
                rock.Add((0, 0));
                rock.Add((-1, 1));
                rock.Add((0, 1));
            }

            return rock;
        }

        private bool Collide(List<(long,long)> rock, long rx, long ry, HashSet<(long,long)> tower, (int,int) direction)
        {
            
            if ((ry + direction.Item2) == 0) {
                return true;
            }

            foreach (var r in rock)
            {
                //Console.WriteLine("collide X" + (r.Item1 + rx + direction.Item1));
                if ((r.Item1 + rx + direction.Item1) == 0)
                    return true;
                else if((r.Item1 + rx + direction.Item1) == 8)
                    return true;
                else if (tower.Contains((r.Item1 + rx + direction.Item1,r.Item2+ry+direction.Item2)))
                    return true;
            }

            return false;
        }

        private void PrintTower(List<(long,long)> rock, HashSet<(long,long)> tower, long rx, long ry, long maxY)
        {
            for (long y = maxY+5; y >= 0; y--)
            {
                Console.Write("|");
                if (y == 0)
                {
                    Console.WriteLine("#######|");
                    break;
                }
                for (int x = 1; x < 8; x++)
                {
                    if (tower.Contains((x, y)))
                        Console.Write("#");
                    else
                    {
                        var isROck = false;
                        foreach (var r in rock)
                        {
                            if (x == r.Item1 + rx && y == r.Item2 + ry)
                            {
                                Console.Write("@");
                                isROck = true;
                                break;
                            }
                        }
                        if(!isROck)
                            Console.Write(".");


                    }
                }
                Console.WriteLine("|");

            }
            Console.WriteLine("");

        }

        private long Part1(string input)
        {
            long faf = 1514285714288;
            long maxY = 0;
            var tower = new HashSet<(long, long)>();
            int jet = 0;
            for (int i = 0; i < 2022; i++)
            {
                var rock = CreateRock(i % 5);
                long rx = 4;
                long ry = maxY + 4; ;
                var falling = true;

                //PrintTower(rock, tower, rx, ry, maxY);
                while (falling)
                {
                    var direction = (-1, 0);
                    if (input[jet % input.Length] == '>')
                        direction = (1, 0);
                    jet++;

                    if (!Collide(rock, rx, ry, tower, direction))
                    {
                        rx += direction.Item1;
                    }
                    //PrintTower(rock, tower, rx, ry, maxY);

                    if (!Collide(rock, rx, ry, tower, (0, -1)))
                        ry--;
                    else
                    {
                        foreach (var r in rock)
                        {
                            tower.Add((r.Item1 + rx, r.Item2 + ry));
                            maxY = Math.Max(maxY, r.Item2 + ry + direction.Item2);
                        }
                        falling = false;
                        rock.Clear();
                    }


                    //PrintTower(rock, tower, rx, ry, maxY);


                }


            }

            return maxY;
        }
        
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string input = System.IO.File.ReadAllText("Input\\2022\\day17.txt");

            part1 = Part1(input);
            long faf = 1514285714288;
            long maxY = 0;
            var tower = new HashSet<(long,long)>();
            int jet = 0;
            for (long i = 0; i < 1; i++)
            {
                var rock = CreateRock(i % 5);
                long rx = 4;
                long ry = maxY + 4;;
                var falling = true;

                //PrintTower(rock, tower, rx, ry, maxY);
                while (falling)
                {
                    var direction = (-1, 0);
                    if (input[jet % input.Length] == '>')
                        direction = (1, 0);
                    jet++;

                    if (!Collide(rock, rx, ry, tower, direction))
                    {
                        rx += direction.Item1;
                    }
                    //PrintTower(rock, tower, rx, ry, maxY);

                    if (!Collide(rock, rx, ry, tower, (0, -1)))
                        ry--;
                    else
                    {
                        foreach (var r in rock)
                        {
                            tower.Add((r.Item1 + rx, r.Item2 + ry));
                            maxY = Math.Max(maxY, r.Item2 + ry + direction.Item2);  
                        }
                        falling = false;
                        rock.Clear();
                    }


                    //PrintTower(rock, tower, rx, ry, maxY);


                }


            }

            WriteResult(17, part1, part2, Result.oneStar);
        }
    }
}







