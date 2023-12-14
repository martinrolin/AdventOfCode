using QuickGraph.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdventOfCode._2023
{
    class Day14 : Helper
    {

        private string Key(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            StringBuilder sb = new StringBuilder();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    sb.Append(matrix[r, c]);
                }              
            }

            return sb.ToString();
        }
        private char[,] Rotate(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            char[,] rotated = new char[cols, rows];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    rotated[c, rows - 1 - r] = matrix[r, c];
                }
            }

            return rotated;
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day14.txt");
            var lv = allText.Split("\r\n").ToList();

            char[,] map = new char[lv.Count, lv[0].Length];
            Dictionary<string, long> d = new Dictionary<string, long>();
            Queue<(int r, int c)> q = new Queue<(int, int)>();
            for (int r = 0; r < lv.Count; r++)
            {
                for (int c = 0; c < lv[0].Length; c++)
                {
                    map[r, c] = lv[r][c];
                    if (map[r, c] == 'O')
                        q.Enqueue((r, c));
                }      
            }
            long cycle = 0;


            while (cycle < 1000000000)
            {
                for (int i = 0; i < 4; i++)
                {
                    while (q.Count > 0)
                    {
                        var stone = q.Dequeue();
                        if (stone.r == 0)
                            continue;
                        else if (map[stone.r - 1, stone.c] == '#' || map[stone.r - 1, stone.c] == 'O')
                            continue;
                        else
                        {
                            map[stone.r - 1, stone.c] = 'O';
                            map[stone.r, stone.c] = '.';
                            q.Enqueue((stone.r - 1, stone.c));

                        }
                    }
                    if (part1 == 0)
                    {
                        for (int r = 0; r < lv.Count; r++)
                        {
                            for (int c = 0; c < lv[0].Length; c++)
                            {
                                if (map[r, c] == 'O')
                                    part1 += lv.Count - r;
                            }
                        }
                    }
                    map = Rotate(map);
                    q.Clear();
                    for (int r = 0; r < lv.Count; r++)
                    {
                        for (int c = 0; c < lv[0].Length; c++)
                        {
                            if (map[r, c] == 'O')
                                q.Enqueue((r, c));
                        }
                    }

                }

                cycle++;
                var key = Key(map);
                if (d.ContainsKey(key))
                {
                    var delta = cycle - d[key];
                    var x = (1000000000-cycle)/delta;
                    cycle += x * delta;
                    d.Clear();
                }
                else
                    d.Add(key, cycle);
            }

            for (int r = 0; r < lv.Count; r++)
            {
                for (int c = 0; c < lv[0].Length; c++)
                {
                    if (map[r, c] == 'O')
                        part2 += lv.Count - r;                 
                }
            }


            WriteResult(14 , part1, part2, Result.twoStars);

        }

        
    }
}





