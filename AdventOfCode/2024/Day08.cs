using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode._2024
{

    class Day08 : Helper
    {

        
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day08.txt");
            var grid = allText.Split("\r\n").ToList();

            var antennas = new Dictionary<(int row, int col),char>();
            var antinodes = new List<(int row, int col)>();

            for (int row = 0; row < grid.Count; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    antennas.Add((row, col), grid[row][col]);
                }
            }

            foreach (var a in antennas)
            {
                foreach (var b in antennas)
                {
                    if ((a.Key.row == b.Key.row && a.Key.col == b.Key.col) || a.Value != b.Value || a.Value == '.')
                        continue;
                    var dr = a.Key.row - b.Key.row;
                    var dc = a.Key.col - b.Key.col;
                    if (!antinodes.Contains((a.Key.row + dr, a.Key.col + dc)))
                        antinodes.Add((a.Key.row + dr, a.Key.col + dc));
                    if (!antinodes.Contains((b.Key.row - dr, b.Key.col - dc)))
                        antinodes.Add((b.Key.row - dr, b.Key.col - dc));

                }

            }

            part1 = antinodes.Where(a => a.row >= 0 && a.row < grid.Count && a.col >= 0 && a.col < grid[0].Length).Count();

            // Part 2
            antinodes.Clear();

            foreach (var a in antennas)
            {
                foreach (var b in antennas)
                {
                    if ((a.Key.row == b.Key.row && a.Key.col == b.Key.col) || a.Value != b.Value || a.Value == '.')
                        continue;
                    var dr = a.Key.row - b.Key.row;
                    var dc = a.Key.col - b.Key.col;


                    var nextrow = b.Key.row;
                    var nextcol = b.Key.col;

                    while (nextrow >= 0 && nextrow < grid.Count && nextcol >= 0 && nextcol < grid[0].Length)
                    {
                        if (!antinodes.Contains((nextrow, nextcol)))
                            antinodes.Add((nextrow, nextcol));
                        nextrow = nextrow + dr;
                        nextcol = nextcol + dc;
                    }

                    nextrow = a.Key.row;
                    nextcol = a.Key.col;

                    while (nextrow >= 0 && nextrow < grid.Count && nextcol >= 0 && nextcol < grid[0].Length)
                    {
                        if (!antinodes.Contains((nextrow, nextcol)))
                            antinodes.Add((nextrow, nextcol));
                        nextrow = nextrow - dr;
                        nextcol = nextcol - dc;
                    }                  

                }

            }

            part2 = antinodes.Count();

            WriteResult(8, part1, part2, Result.twoStars);

            }
        }
    }


