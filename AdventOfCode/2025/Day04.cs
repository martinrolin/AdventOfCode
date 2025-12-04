using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2025
{

    class Day04 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2025\\day04.txt");
            var input = allText.Split("\r\n").Select(x => x.ToCharArray()).ToArray();


            var directions = new List<(int row, int col)> { (-1, -1), (-1, 1), (1, -1), (1, 1), (1, 0), (-1, 0), (0, 1), (0, -1) };
            var rolls = new HashSet<(int row, int col)>();

            // Part 1

            for (int r = 0; r < input.Length; r++)
            {
                for (int c = 0; c < input[0].Length; c++)
                {
                    if (input[r][c] != '@')
                        continue;
                    var count = 0;
                    foreach (var d in directions)
                    {
                        if (r+d.row  < 0 || c +d.col < 0 || r + d.row >= input.Length || c + d.col >= input[0].Length)
                            continue;

                        if (input[r + d.row][c+d.col] == '@')
                            count++;
                    }

                    if (count < 4)
                    {
                        if (!rolls.Contains((r, c)))
                        {
                            rolls.Add((r, c ));
                        }
                    }                        
                }
            }
            part1 = rolls.Count;


            // Part 2

            var running = true;
            while (running)
            { 
                for (int r = 0; r < input.Length; r++)
                {
                    for (int c = 0; c < input[0].Length; c++)
                    {
                        if (input[r][c] != '@')
                            continue;

                        var count = 0;
                        foreach (var d in directions)
                        {
                            if (r + d.row < 0 || c + d.col < 0 || r + d.row >= input.Length || c + d.col >= input[0].Length)
                                continue;

                            if (input[r + d.row][c + d.col] == '@')
                                count++;
                        }

                        if (count < 4)
                        {
                            if (!rolls.Contains((r, c)))
                            {
                                rolls.Add((r, c));
                            }
                        }
                    }
                }

                if (rolls.Count == 0)
                {
                    running = false;
                    break;
                }

                part2 += rolls.Count;

                foreach (var pos in rolls)
                {
                    input[pos.row][pos.col] = '.';
                }

                rolls.Clear();
            }

            WriteResult(4, part1, part2, Result.none);

        }       
    }
}