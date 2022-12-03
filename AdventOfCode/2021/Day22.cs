using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day22 : Helper
    {

        private List<bool> commands;
        private List<(int, int, int, int, int, int)> dimensions;
        private HashSet<(int,int,int)> cube;


        private long Part1()
        {
            for (int i = 0; i < dimensions.Count; i++)
            {
                for (int x = dimensions[i].Item1; x <= dimensions[i].Item2; x++)
                {
                    for (int y = dimensions[i].Item3; y <= dimensions[i].Item4; y++)
                    {
                        for (int z = dimensions[i].Item5; z <= dimensions[i].Item6; z++)
                        {
                            if (Math.Abs(x) > 50 || Math.Abs(y) > 50 || Math.Abs(z) > 50)
                                continue;

                            if (commands[i] && !cube.Contains((x, y, z)))
                                cube.Add((x, y, z));

                            if (!commands[i] && cube.Contains((x, y, z)))
                                cube.Remove((x, y, z));

                        }
                    }
                }

            }
            return (cube.Count);
        }


        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day22.txt");
            var lines = allText.Split("\r\n").ToList<string>();
            commands = new List<bool>();
            dimensions = new List<(int, int, int, int, int, int)>();

            for (int i = 0; i < lines.Count; i++)
            {
                commands.Add(lines[i].Contains("on"));
                var data = Array.ConvertAll(lines[i].Replace("on x=", "").Replace("off x=", "").Replace(",y=", "..").Replace(",z=", "..").Split(".."),s => Int32.Parse(s));
                dimensions.Add((data[0], data[1], data[2], data[3], data[4], data[5]));
                //minX = Math.Min(minX, data[0]);
                //maxX = Math.Max(maxX, data[1]);
                //minY = Math.Min(minY, data[2]);
                //maxY = Math.Max(maxY, data[3]);
                //minZ = Math.Min(minZ, data[4]);
                //maxZ = Math.Max(maxZ, data[5]);
            }


            for (int i = 0; i < lines.Count; i++)
            {
                //dimensions[i] = (dimensions[i].Item1 + minX, dimensions[i].Item2 + maxX, dimensions[i].Item3 + minY, dimensions[i].Item4 + maxY, dimensions[i].Item5 + minZ, dimensions[i].Item6 + maxZ);
                dimensions[i] = (dimensions[i].Item1, dimensions[i].Item2, dimensions[i].Item3, dimensions[i].Item4, dimensions[i].Item5, dimensions[i].Item6);
            }

            cube = new HashSet<(int, int, int)>();

            //part1 = Part1();


            WriteResult(22, part1, part2, Result.none);
        }
    }
}




