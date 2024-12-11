using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode._2024
{

    class Day10 : Helper
    {

        private List<string> grid;

        private int Walk_Part1(int row, int col)
        {
            var visited = new HashSet<(int row, int col)>();
            var queue = new Queue<(int row, int col)>();
            var directions = new List<(int row, int col)> { (1, 0), (-1, 0), (0, 1), (0, -1) };
            queue.Enqueue((row, col));

            var nines = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var d in directions)
                {
                    var newrow = current.row + d.row;
                    var newcol = current.col + d.col;
                    if (newrow < 0 || newrow >= grid.Count || newcol < 0 || newcol >= grid[newrow].Length)
                        continue;
                    if (int.Parse(grid[newrow][newcol].ToString()) != int.Parse(grid[current.row][current.col].ToString()) + 1)
                        continue;
                    if (visited.Contains((newrow, newcol)))
                        continue;
                    visited.Add((newrow, newcol));
                    if (grid[newrow][newcol] == '9')
                        nines++;
                    else
                        queue.Enqueue((newrow, newcol));
                }

            }

            return nines;


        }

        private int Walk_Part2(int row, int col)
        {
            var visited = new Dictionary<(int row, int col),int>();
            var queue = new Queue<(int row, int col)>();
            var directions = new List<(int row, int col)> { (1, 0), (-1, 0), (0, 1), (0, -1) };
            queue.Enqueue((row, col));
            visited.Add((row, col), 1);

            var nines = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (grid[current.row][current.col] == '9')
                    nines += visited[(current.row, current.col)];
                foreach (var d in directions)
                {
                    var newrow = current.row + d.row;
                    var newcol = current.col + d.col;
                    if (newrow < 0 || newrow >= grid.Count || newcol < 0 || newcol >= grid[newrow].Length)
                        continue;
                    if (int.Parse(grid[newrow][newcol].ToString()) != int.Parse(grid[current.row][current.col].ToString()) + 1)
                        continue;
                    if (visited.ContainsKey((newrow, newcol)))
                    {
                        visited[(newrow, newcol)] += visited[(current.row, current.col)];
                        continue;
                    }
                    else
                        visited.Add((newrow, newcol), visited[(current.row, current.col)]);
                    
                    queue.Enqueue((newrow, newcol));
                }

            }

            return nines;


        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string input = File.ReadAllText("Input\\2024\\day10.txt");

            grid = input.Split("\r\n").ToList();  
            List<(int row, int col)> zeros = new List<(int row, int col)>();
           
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '0')
                    {
                        part1 += Walk_Part1(i, j);
                        part2 += Walk_Part2(i, j);
                    }
                }
            }

            


            WriteResult(10, part1, part2, Result.twoStars);

            }
        }
    }


