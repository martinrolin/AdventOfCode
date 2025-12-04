using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2025
{

    class Day02 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2025\\day02.txt");
            var input = allText.Split(",").ToList();

            foreach (var range in input)
            {
                var x = range.Split("-").ToList();

                for (long i = long.Parse(x[0]); i <= long.Parse(x[1]); i++)
                {
                    var s = i.ToString();
                    var len = s.Length;
                    if (s.Length % 2 == 0)
                    {
                        if (s.Substring(0,len/ 2) == s.Substring(len/ 2))
                        {
                            part1 += i;
                        }

                    }
                   
                    for (int j = 1; j <= len; j++)
                    {
                        var pattern = s.Substring(0, j);
                        
                        if (len % j == 0)
                        {
                            var n = len / j;
                            bool hasPattern = true;
                            var count = 0;
                            for (int k = 1; hasPattern && k < n; k++)
                            {
                                if (pattern == s.Substring(j * k, j))
                                {
                                    count++;
                                    
                                }
                                else {
                                    hasPattern = false;
                                }

                            }

                            if (hasPattern && count > 0)
                            { 
                                part2 += i;
                                break;
                            }
                        }
                        
                    }
                }
            }

           


            WriteResult(2, part1, part2, Result.twoStars);

            }
        }
    }


