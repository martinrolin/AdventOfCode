using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2022
{
    class Day23 : Helper
    {

        private void P(List<(int, int)> elves, int mx, int my, int Mx, int My)
        {
            for (int y = -2; y <= 9; y++)
            {
                for (int x = -3; x <= 9; x++)
                {
                    if (elves.Contains((x, y)))
                        Console.Write("#");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        private long Part1(List<string> lines)
        {
            var elves = new List<(int, int)>();

            for (int r = 0; r < lines.Count; r++)
            {
                for (int c = 0; c < lines[0].Length; c++)
                {
                    if (lines[r][c] == '#')
                        elves.Add((c, r));
                }
            }

            var lookup = new Dictionary<(int, int), List<(int, int)>>();
            lookup.Add((1, 0), new List<(int, int)> { (1, -1), (1, 0), (1, 1) });
            lookup.Add((-1, 0), new List<(int, int)> { (-1, -1), (-1, 0), (-1, 1) });
            lookup.Add((0, 1), new List<(int, int)> { (-1, 1), (0, 1), (1, 1) });
            lookup.Add((0, -1), new List<(int, int)> { (-1, -1), (0, -1), (1, -1) });

            var directions = new List<(int, int)>();
            directions.Add((0, -1));
            directions.Add((0, 1));
            directions.Add((-1, 0));
            directions.Add((1, 0));

            var alldirections = new List<(int, int)>();
            alldirections.Add((1, 0));
            alldirections.Add((1, 1));
            alldirections.Add((0, 1));
            alldirections.Add((-1, 1));
            alldirections.Add((-1, 0));
            alldirections.Add((-1, -1));
            alldirections.Add((0, -1));
            alldirections.Add((1, -1));


            for (int i = 0; i < 10; i++)
            {


                var moves = new List<(int, int)>();
                var duplicates = new List<(int, int)>();

                foreach (var elf in elves)
                {

                    if (alldirections.All(d => !elves.Contains((elf.Item1 + d.Item1, elf.Item2 + d.Item2))))
                        continue;

                    foreach (var dir in directions)
                    {
                        if (lookup[dir].All(d => !elves.Contains((elf.Item1 + d.Item1, elf.Item2 + d.Item2))))
                        {
                            var p = (elf.Item1 + dir.Item1, elf.Item2 + dir.Item2);


                            if (!moves.Contains(p))
                                moves.Add(p);
                            else if (!duplicates.Contains(p))
                                duplicates.Add(p);

                            break;
                        }
                    }
                }
                var oldelves = new List<(int, int)>(elves);

                for (int e = 0; e < elves.Count; e++)
                {
                    if (alldirections.All(d => !oldelves.Contains((elves[e].Item1 + d.Item1, elves[e].Item2 + d.Item2))))
                        continue;

                    var rejected = false;
                    foreach (var dir in directions)
                    {
                        if (!rejected && lookup[dir].All(d => !oldelves.Contains((elves[e].Item1 + d.Item1, elves[e].Item2 + d.Item2))))
                        {
                            var p = (elves[e].Item1 + dir.Item1, elves[e].Item2 + dir.Item2);

                            if (!duplicates.Contains(p))
                            {
                                elves[e] = p;

                                break;
                            }
                            else
                            {
                                rejected = true;
                                break;
                            }
                        }
                    }

                }

                var first = directions.FirstOrDefault();
                directions.Remove(first);
                directions.Add(first);



            }

            var mx = 0;
            var my = 0;
            var Mx = 0;
            var My = 0;
            foreach (var elf in elves)
            {
                mx = Math.Min(mx, elf.Item1);
                my = Math.Min(my, elf.Item2);
                Mx = Math.Max(Mx, elf.Item1);
                My = Math.Max(My, elf.Item2);
            }


            return ((Mx - mx + 1) * (My - my + 1) - elves.Count);
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string input = System.IO.File.ReadAllText("Input\\2022\\day23.txt");


            var lines = input.Split("\r\n").ToList();

            part1 = Part1(lines);

            var elves = new List<(int, int)>();

            for (int r = 0; r < lines.Count; r++)
            {
                for (int c = 0; c < lines[0].Length; c++)
                {
                    if (lines[r][c] == '#')
                        elves.Add((c, r));
                }
            }

            var lookup = new Dictionary<(int,int), List<(int, int)>>();
            lookup.Add((1, 0), new List<(int, int)> { (1, -1), (1, 0), (1, 1) });
            lookup.Add((-1, 0), new List<(int, int)> { (-1, -1), (-1, 0), (-1, 1) });
            lookup.Add((0, 1), new List<(int, int)> { (-1, 1), (0, 1), (1, 1) });
            lookup.Add((0, -1), new List<(int, int)> { (-1, -1), (0, -1), (1, -1) });

            var directions = new List<(int, int)>();
            directions.Add((0, -1));
            directions.Add((0, 1));
            directions.Add((-1, 0));
            directions.Add((1, 0));

            var alldirections = new List<(int, int)>();
            alldirections.Add((1, 0));
            alldirections.Add((1, 1));
            alldirections.Add((0, 1));
            alldirections.Add((-1, 1));
            alldirections.Add((-1, 0));
            alldirections.Add((-1, -1));
            alldirections.Add((0, -1));
            alldirections.Add((1, -1));
            
            while(true)
            {
                var n = 0;

                var moves = new List<(int, int)>();
                var duplicates = new List<(int, int)>();

                foreach (var elf in elves)
                {
                    
                    if (alldirections.All(d => !elves.Contains((elf.Item1 + d.Item1, elf.Item2 + d.Item2))))
                        continue;

                    foreach (var dir in directions)
                    {
                        if (lookup[dir].All(d => !elves.Contains((elf.Item1 + d.Item1, elf.Item2 + d.Item2))))
                        { 
                            var p = (elf.Item1 + dir.Item1, elf.Item2 + dir.Item2);


                            if (!moves.Contains(p))
                                moves.Add(p);
                            else if (!duplicates.Contains(p))
                                duplicates.Add(p);

                            break;
                        }
                    }
                }
                var oldelves = new List<(int, int)>(elves);

                for (int e = 0; e < elves.Count; e++)
                {
                    if (alldirections.All(d => !oldelves.Contains((elves[e].Item1 + d.Item1, elves[e].Item2 + d.Item2))))
                        continue;

                    var rejected = false;
                    foreach (var dir in directions)
                    {
                        if (!rejected && lookup[dir].All(d => !oldelves.Contains((elves[e].Item1 + d.Item1, elves[e].Item2 + d.Item2))))
                        {
                            var p = (elves[e].Item1 + dir.Item1, elves[e].Item2 + dir.Item2);

                            if (!duplicates.Contains(p))
                            {
                                elves[e] = p;
                                n++;
                                break;
                            }
                            else {
                                rejected = true;
                                break;
                            }
                        }
                    }

                }

                var first = directions.FirstOrDefault();
                directions.Remove(first);
                directions.Add(first);
                //if (part2 % 100 == 0)
                //    Console.WriteLine(part2);

                part2++;
                if (n == 0)
                    break;

            }

            var mx = 0;
            var my = 0;
            var Mx = 0;
            var My = 0;
            foreach (var elf in elves)
            {
                mx = Math.Min(mx, elf.Item1);
                my = Math.Min(my, elf.Item2);
                Mx = Math.Max(Mx, elf.Item1);
                My = Math.Max(My, elf.Item2);
            }


            

            WriteResult(23, part1, part2, Result.twoStars);
        }
    }
}