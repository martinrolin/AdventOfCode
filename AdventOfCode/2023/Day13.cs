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
    class Day13 : Helper
    {


        private long FindMirror(List<string> pattern, long part1) 
        {
            long sum = 0;

            bool mirrorFound = false;
            bool mirror = true;
            for (int c = 0; c < pattern[0].Length - 1; c++)
            {
                mirror = true;
                for (int cc = 1; mirror && c + cc < pattern[0].Length; cc++)
                {
                    if ((c - cc + 1 >= 0) && (c - cc + 1 != c + cc) && String.Concat(pattern.Select(x => x[c - cc + 1]).ToArray()) != String.Concat(pattern.Select(x => x[c + cc]).ToArray()))
                        mirror = false;
                }
                if (mirror)
                {
                    if (part1 != (c + 1))
                    {
                        sum += c + 1;
                        mirrorFound = true;

                        break;
                    }
                }

            }
            if (!mirrorFound)
            {

                for (int r = 0; r < pattern.Count - 1; r++)
                {
                    mirror = true;

                    for (int rr = 1; mirror && r + rr < pattern.Count; rr++)
                    {
                        if ((r - rr + 1 >= 0) && (r - rr + 1 != r + rr) && pattern[r - rr + 1] != pattern[r + rr])
                            mirror = false;
                    }
                    if (mirror)
                    {
                        if (part1 != ((r + 1) * 100))
                        {
                            sum += (r + 1) * 100;
                            break;
                        }
                    }

                }
            }
            return sum;
        }
        

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day13.txt");
            var lv = allText.Split("\r\n").ToList();

            var pattern = new List<string>();

            var R = 0;
            foreach (var l in lv)
            {
                if (l != "")
                    pattern.Add(l);
                else
                {
                    var p1 = FindMirror(pattern, -1);
                    part1 += p1;
                    
                    bool p2 = true;
                    for (int r = 0; p2 && r < pattern.Count; r++)
                    {
                        for (int c = 0; c < pattern[0].Length; c++)
                        {
                            var line = pattern[r];
                            var temp = pattern[r].ToCharArray();
                            if (temp[c] == '.')
                                temp[c] = '#';
                            else if (temp[c] == '#')
                                temp[c] = '.';
                            pattern[r] = new string(temp);
                            if (FindMirror(pattern, p1) > 0)
                            {
                                part2 += FindMirror(pattern, p1);
                                p2 = false;
                                break;
                            }
                            pattern[r] = line;

                        }
                    }

                    pattern.Clear();
                }

            }

            WriteResult(13 , part1, part2, Result.twoStars);

        }

        
    }
}





