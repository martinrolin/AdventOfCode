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

    class Day06 : Helper
    {
      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day06.txt");
            var map = allText.Split("\r\n").ToList();            

            var r = 0;
            var c = 0;
            var sr = 0;
            var sc = 0; 

            for (int rr = 0; rr < map.Count; rr++)
            {
                for (int cc = 0; cc < map[0].Length; cc++)
                {
                    if (map[rr][cc] == '^') {
                        r = rr;
                        sr = rr;
                        c = cc;
                        sc = cc;
                    }
                }
            }



            List<(int,int)> visited = new List<(int, int)>();
            visited.Add((r, c));



            var dr = -1;
            var dc = 0;

            var insideMap = true;

            
            while (insideMap)
            {
                if (r + dr < 0 || r + dr >= map.Count || c + dc < 0 || c + dc >= map[0].Length)
                {
                    insideMap = false;
                }
                else
                {

                    if (map[r + dr][c + dc] == '#')
                    {
                        if (dr == -1)
                        {
                            dr = 0;
                            dc = 1;
                        } else if (dr == 1)
                        {
                            dr = 0;
                            dc = -1;
                        } else if (dc == -1)
                        {
                            dr = -1;
                            dc = 0;
                        } else if (dc == 1)
                        {
                            dr = 1;
                            dc = 0;
                        }
                    }
                    else
                    { 
                        r = r + dr;
                        c = c + dc;
                        if (visited.Contains((r, c)) == false)
                        {
                            visited.Add((r, c));
                        }
                    }

                }
            }

            part1 = visited.Count;

            // Part 2

            List<(int, int, int, int)> visited2 = new List<(int, int, int, int)>();
            

            for (int or = 0; or < map.Count; or++)
            {
                for (int oc = 0; oc < map[0].Length; oc++)
                {                    

                    r = sr;
                    c = sc;
                    dr = -1;
                    dc = 0;
                    visited2.Clear();
                    visited2.Add((r, c, dr, dc));

                    insideMap = true;


                    while (insideMap)
                    {
                        if (r + dr < 0 || r + dr >= map.Count || c + dc < 0 || c + dc >= map[0].Length)
                        {
                            insideMap = false;
                        }
                        else
                        {

                            if (map[r + dr][c + dc] == '#' || (r+dr == or && c+dc == oc))
                            {
                                if (dr == -1)
                                {
                                    dr = 0;
                                    dc = 1;
                                }
                                else if (dr == 1)
                                {
                                    dr = 0;
                                    dc = -1;
                                }
                                else if (dc == -1)
                                {
                                    dr = -1;
                                    dc = 0;
                                }
                                else if (dc == 1)
                                {
                                    dr = 1;
                                    dc = 0;
                                }
                            }
                            else
                            {
                                r = r + dr;
                                c = c + dc;
                                if (visited2.Contains((r, c, dr, dc)) == false)
                                {
                                    visited2.Add((r, c, dr, dc));
                                }
                                else
                                {
                                    part2++;
                                    insideMap = false;
                                }
                            }

                        }
                    }
                }
            }

            
            WriteResult(6, part1, part2, Result.none);

            }
        }
    }


