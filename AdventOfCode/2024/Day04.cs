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

    class Day04 : Helper
    {
        List<string> v;
        string xmas = "XMAS";

        private bool Check(int r, int c, int dr, int dc, int depth)
        {
            if (r < 0 || r >= v.Count|| c < 0 || c >= v[0].Length)
                return false;


            if (v[r][c] == xmas[depth])
            {
                if (depth == 3)
                    return true;
                else 
                    return Check(r + dr, c + dc, dr, dc, ++depth);
            }
            else {
                return false;   
            }


        }
      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day04.txt");
            v = allText.Split("\r\n").ToList();

            var directions = new List<(int, int)>() { (1, 1), (-1,-1), (-1, 0), (-1, 1), (0, 1), (1, 0), (1, -1), (0, -1) };

            for (int r  = 0; r < v.Count; r++)
            {
                for (int c = 0; c < v[0].Length; c++)
                {                   
                    foreach(var (dr, dc) in directions)
                    {
                        if (Check(r, c, dr, dc, 0))
                            part1++;
                    }
                }
            }

            for (int r = 1; r < v.Count-1; r++)
            {
                for (int c = 1; c < v[0].Length-1; c++)
                {
                    if (v[r][c] == 'A') { 
                        if ((v[r - 1][c-1] == 'M' && v[r + 1][c + 1] == 'S' || v[r - 1][c - 1] == 'S' && v[r + 1][c + 1] == 'M') &&
                           (v[r - 1][c + 1] == 'M' && v[r + 1][c - 1] == 'S' || v[r - 1][c + 1] == 'S' && v[r + 1][c - 1] == 'M'))
                            part2++;


                    }
                }
            }


            WriteResult(4, part1, part2, Result.twoStars);

            }
        }
    }


