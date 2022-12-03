using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2020
{
    class Day18 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day18.txt");
            var lines = allText.Split("\r\n").ToList();

            foreach (var line in lines)
            {
                part1 += Int64.Parse(Calc(line));
                part2 += Int64.Parse(Calc(line,true));
            }

            WriteResult(18, part1, part2, Result.gold);
        }

        private string Calc(string equation, bool part2 = false) {
            while (equation.Contains(" ")) {
                if (equation.Contains("("))
                {
                    Regex regex = new Regex(@"\(([^()]+)\)");
                    Match match = regex.Match(equation);
                    
                    equation = equation.Replace(match.Groups[0].Value,Calc(match.Groups[1].Value, part2));
                }
                else
                {
                    Regex regex = regex = new Regex(@"(\d+) ([+*]) (\d+)");
                    Match match = regex.Match(equation);
                    
                    if (part2) {
                        regex = new Regex(@"(\d+) ([+]) (\d+)");
                        match = regex.Match(equation);
                        if (!match.Success)
                        {
                            regex = new Regex(@"(\d+) ([*]) (\d+)");
                            match = regex.Match(equation);
                        }
                    }
                     
                    var res = match.Groups[2].Value == "+" ? Int64.Parse(match.Groups[1].Value) + Int64.Parse(match.Groups[3].Value): Int64.Parse(match.Groups[1].Value) * Int64.Parse(match.Groups[3].Value);
                    equation = new Regex(Regex.Escape(match.Groups[0].Value)).Replace(equation, res.ToString(), 1);                    
                }
            }

            return equation;
        }                       
    }
}
