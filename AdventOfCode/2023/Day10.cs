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
    class Day10 : Helper
    {

        private char[,] large = null;
        private bool[,] visit = null;
        private bool[,] mainloop = null;

        private bool Traverse(int row, int col, int rows, int cols)
        {
            visit[row, col] = true;
            
            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };

            var r = false;
            for (int i = 0; i < 4; i++)
            {
                int nr = row + dr[i];
                int nc = col + dc[i];

                if (nr < 0 || nc < 0 || nr >= rows || nc >= cols)
                    return true;

                if (large[nr, nc] == '.' && !visit[nr,nc])
                    r = r | Traverse(nr, nc, rows, cols);

                if (r)
                    break;
            }

            return r;
        }
    


    public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day10.txt");
            var lv = allText.Split("\r\n").ToList();
            mainloop = new bool[lv.Count, lv[0].Length];

            int[] s = { -1, -1 };

            for (int r = 0; r < lv.Count; r++)
            {
                for (int c = 0; c < lv[r].Length; c++)
                {
                    if (lv[r][c] == 'S')
                    {
                        s[0] = r;
                        s[1] = c;
                        mainloop[r, c] = true;
                    }
                    if (lv[r][c] == '.')
                        part2++;
                }
            }

            Queue<int[]> q = new Queue<int[]>();
            q.Enqueue(new int[] { 0, s[0], s[1] });
            HashSet<string> visited = new HashSet<string>();
            long max = -1;

            while (q.Count > 0)
            {
                int[] pos = q.Dequeue();
                int d = pos[0];
                int r = pos[1];
                int c = pos[2];
                visited.Add($"{r}:{c}");

                int[][] directions = {
                new int[] { r + 1, c, 'D' },
                new int[] { r - 1, c, 'U' },
                new int[] { r, c + 1, 'R' },
                new int[] { r, c - 1, 'L' }
            };

                foreach (int[] nextPos in directions)
                {
                    int nr = nextPos[0];
                    int nc = nextPos[1];
                    char nd = (char)nextPos[2];

                    if (nr < 0 || nc < 0 || nr >= lv.Count || nc >= lv[0].Length)
                        continue;
                    else if (visited.Contains($"{nr}:{nc}"))
                        continue;

                    int found = 0;
                    if (nd == 'R' && "-LSF".Contains(lv[r][c]))
                    {
                        if (lv[nr][nc] == 'J' || lv[nr][nc] == '7' || lv[nr][nc] == '-')
                        { 
                            found = 1;
                            mainloop[nr, nc] = true;
                        }
                    }
                    else if (nd == 'L' && "-7SJ".Contains(lv[r][c]))
                    {
                        if (lv[nr][nc] == 'F' || lv[nr][nc] == 'L' || lv[nr][nc] == '-')
                        {
                            found = 1;
                            mainloop[nr, nc] = true;
                        }
                    }
                    else if (nd == 'U' && "|LSJ".Contains(lv[r][c]))
                    {
                        if (lv[nr][nc] == 'F' || lv[nr][nc] == '7' || lv[nr][nc] == '|')
                        {
                            found = 1;
                            mainloop[nr, nc] = true;
                        }
                    }
                    else if (nd == 'D' && "|7SF".Contains(lv[r][c]))
                    {
                        if (lv[nr][nc] == 'J' || lv[nr][nc] == 'L' || lv[nr][nc] == '|')
                        {
                            found = 1;
                            mainloop[nr, nc] = true;
                        }
                    }

                    if (found == 1)
                    {
                        q.Enqueue(new int[] { d + 1, nr, nc });
                        if (max < d + 1) max = d + 1;
                    }
                }
            }



            large = new char[lv.Count * 3, lv[0].Length * 3];
            visit = new bool[lv.Count * 3, lv[0].Length * 3];

            for (int r = 0; r < lv.Count; r++)
            {
                for (int c = 0; c < lv[0].Length; c++)
                {
                        

                    var tc = lv[r][c];
                    if (!mainloop[r, c] && tc != '.')
                    {
                        part2++;
                        tc = '.';
                    }

                    if (tc == '.')
                    {
                        large[r * 3, c * 3] = '.';
                        large[r * 3, c * 3 + 1] = '.';
                        large[r * 3, c * 3 + 2] = '.';
                        large[r * 3 + 1, c * 3] = '.';
                        large[r * 3 + 1, c * 3 + 1] = '.';
                        large[r * 3 + 1, c * 3 + 2] = '.';
                        large[r * 3 + 2, c * 3] = '.';
                        large[r * 3 + 2, c * 3 + 1] = '.';
                        large[r * 3 + 2, c * 3 + 2] = '.';
                    }
                    else if (tc == 'S')
                    {
                        large[r * 3, c * 3] = '.';
                        large[r * 3, c * 3 + 1] = '|';
                        large[r * 3, c * 3 + 2] = '.';
                        large[r * 3 + 1, c * 3] = '-';
                        large[r * 3 + 1, c * 3 + 1] = '+';
                        large[r * 3 + 1, c * 3 + 2] = '-';
                        large[r * 3 + 2, c * 3] = '.';
                        large[r * 3 + 2, c * 3 + 1] = '|';
                        large[r * 3 + 2, c * 3 + 2] = '.';
                    }
                    else if (tc == '-')
                    {
                        large[r * 3, c * 3] = '.';
                        large[r * 3, c * 3 + 1] = '.';
                        large[r * 3, c * 3 + 2] = '.';
                        large[r * 3 + 1, c * 3] = '-';
                        large[r * 3 + 1, c * 3 + 1] = '-';
                        large[r * 3 + 1, c * 3 + 2] = '-';
                        large[r * 3 + 2, c * 3] = '.';
                        large[r * 3 + 2, c * 3 + 1] = '.';
                        large[r * 3 + 2, c * 3 + 2] = '.';
                    }
                    else if (tc == '|')
                    {
                        large[r * 3, c * 3] = '.';
                        large[r * 3, c * 3 + 1] = '|';
                        large[r * 3, c * 3 + 2] = '.';
                        large[r * 3 + 1, c * 3] = '.';
                        large[r * 3 + 1, c * 3 + 1] = '|';
                        large[r * 3 + 1, c * 3 + 2] = '.';
                        large[r * 3 + 2, c * 3] = '.';
                        large[r * 3 + 2, c * 3 + 1] = '|';
                        large[r * 3 + 2, c * 3 + 2] = '.';
                    }
                    else if (lv[r][c] == 'L')
                    {
                        large[r * 3, c * 3] = '.';
                        large[r * 3, c * 3 + 1] = '|';
                        large[r * 3, c * 3 + 2] = '.';
                        large[r * 3 + 1, c * 3] = '.';
                        large[r * 3 + 1, c * 3 + 1] = 'L';
                        large[r * 3 + 1, c * 3 + 2] = '-';
                        large[r * 3 + 2, c * 3] = '.';
                        large[r * 3 + 2, c * 3 + 1] = '.';
                        large[r * 3 + 2, c * 3 + 2] = '.';
                    }
                    else if (tc == 'J')
                    {
                        large[r * 3, c * 3] = '.';
                        large[r * 3, c * 3 + 1] = '|';
                        large[r * 3, c * 3 + 2] = '.';
                        large[r * 3 + 1, c * 3] = '-';
                        large[r * 3 + 1, c * 3 + 1] = 'J';
                        large[r * 3 + 1, c * 3 + 2] = '.';
                        large[r * 3 + 2, c * 3] = '.';
                        large[r * 3 + 2, c * 3 + 1] = '.';
                        large[r * 3 + 2, c * 3 + 2] = '.';
                    }
                    else if (tc == '7')
                    {
                        large[r * 3, c * 3] = '.';
                        large[r * 3, c * 3 + 1] = '.';
                        large[r * 3, c * 3 + 2] = '.';
                        large[r * 3 + 1, c * 3] = '-';
                        large[r * 3 + 1, c * 3 + 1] = '7';
                        large[r * 3 + 1, c * 3 + 2] = '.';
                        large[r * 3 + 2, c * 3] = '.';
                        large[r * 3 + 2, c * 3 + 1] = '|';
                        large[r * 3 + 2, c * 3 + 2] = '.';
                    }
                    else if (tc == 'F')
                    {
                        large[r * 3, c * 3] = '.';
                        large[r * 3, c * 3 + 1] = '.';
                        large[r * 3, c * 3 + 2] = '.';
                        large[r * 3 + 1, c * 3] = '.';
                        large[r * 3 + 1, c * 3 + 1] = 'F';
                        large[r * 3 + 1, c * 3 + 2] = '-';
                        large[r * 3 + 2, c * 3] = '.';
                        large[r * 3 + 2, c * 3 + 1] = '|';
                        large[r * 3 + 2, c * 3 + 2] = '.';
                    }
                }
            }

            for (int r = 0; r < lv.Count; r++)
            {
                for (int c = 0; c < lv[0].Length; c++)
                {
                    var rr = r * 3 + 1;
                    var cc = c * 3 + 1;

                    if (large[rr, cc] == '.')
                    {
                        visit = new bool[lv.Count * 3, lv[0].Length * 3];

                        if (Traverse(rr, cc, lv.Count * 3, lv[0].Length * 3))
                            part2--;
                    
                            
                    
                    }
                }
                
            }

            part1 = max;
           
            WriteResult(10 , part1, part2, Result.twoStars);

            }

        
    }
}





