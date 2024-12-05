using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode._2024
{

    class Day03 : Helper
    {
      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day03.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            Regex r = new Regex(@"mul\((\d)+,(\d)+\)");
            Match m = r.Match(string.Join("",listOfValues));
            
            while (m.Success)
            {
                var x = m.ToString().Replace("mul(", "").Replace(")", "").Split(",");
                part1 += long.Parse(x[0]) * long.Parse(x[1]);
                m = m.NextMatch();
            }
            
            r = new Regex(@"mul\((\d)+,(\d)+\)|do\(\)|don't\(\)");
            m = r.Match(string.Join("", listOfValues));
            var Do = true;
            while (m.Success)
            {
                if (m.Value == "do()")
                    Do = true;
                else if (m.Value == "don't()")
                    Do = false;
                else {
                    if (Do)
                    {
                        var x = m.ToString().Replace("mul(", "").Replace(")", "").Split(",");
                        part2 += long.Parse(x[0]) * long.Parse(x[1]);
                    }                  
                }               
                m = m.NextMatch();
            }

            WriteResult(3, part1, part2, Result.twoStars);

            }
        }
    }


