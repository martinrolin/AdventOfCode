using QuikGraph.Algorithms.TSP;
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

    class Day15 : Helper
    {

      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            var input = File.ReadAllText("Input\\2024\\day15.txt").Split("\r\n\r\n");

          
            var gridlines = input[0].Split("\r\n").ToList();

            char[][] charArray = new char[gridlines.Count][];

            for (int i = 0; i < gridlines.Count; i++)
            {
                charArray[i] = gridlines[i].ToCharArray();
            }

            var grid = input[0].Split("\r\n").Select(line => line.ToCharArray()).ToArray();
            



            var moves = input[1].Replace("\r\n", "");

           
            int rows = grid.Length;
            int cols = grid[0].Length;

            int r = 0, c = 0;
            bool found = false;
            for (int i = 0; i < rows && !found; i++)
            {
                for (int j = 0; j < cols && !found; j++)
                {
                    if (grid[i][j] == '@')
                    {
                        r = i;
                        c = j;
                        found = true;
                        break;
                    }
                }
            }

            foreach (char move in moves)
            {
                int dr = move == '^' ? -1 : move == 'v' ? 1 : 0;
                int dc = move == '<' ? -1 : move == '>' ? 1 : 0;

                var targets = new List<(int, int)> { (r, c) };
                int cr = r, cc = c;
                bool go = true;

                while (true)
                {
                    cr += dr;
                    cc += dc;
                    char ch = grid[cr][cc];

                    if (ch == '#')
                    {
                        go = false;
                        break;
                    }
                    if (ch == 'O')
                    {
                        targets.Add((cr, cc));
                    }
                    if (ch == '.')
                    {
                        break;
                    }
                }

                if (!go) continue;

                grid[r][c] = '.';
                grid[r + dr][c + dc] = '@';

                foreach (var (br, bc) in targets.Skip(1))
                {
                    grid[br + dr][bc + dc] = 'O';
                }

                r += dr;
                c += dc;
            }

            int result = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 'O')
                    {
                        result += 100 * i + j;
                    }
                }
            }

            part1 = result;




            WriteResult(15, part1, part2, Result.oneStar);

            }
        }
    }


