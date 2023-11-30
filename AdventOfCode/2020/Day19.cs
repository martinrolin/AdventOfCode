using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2020
{
    class Day19 : Helper
    {
        private Dictionary<int, string> rules = new Dictionary<int, string>();
        private Dictionary<int, string> rulesInput = new Dictionary<int, string>();

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day19.txt");
            var section = allText.Split("\r\n\r\n").ToList();
            foreach (var line in section[0].Split("\r\n"))
            {
                var l = line.Split(": ");
                rulesInput.Add(Int32.Parse(l[0]), l[1]);
            }

            Regex RegExPart1 = new Regex(@"^" + GetRulePattern(0) + "$");
            rules = new Dictionary<int, string>();
            Regex RegExPart2 = new Regex(@"^" + GetRulePattern(0, true) + "$");

            foreach (var line in section[1].Split("\r\n"))
            {
                if (RegExPart1.Match(line).Success) 
                    part1++;
                if (RegExPart2.Match(line).Success)
                    part2++;
            }

            WriteResult(19, part1, part2, Result.twoStars);
        }

        public String GetRulePattern(int rule, bool part2 = false)
        {
            if (rules.ContainsKey(rule)) 
            { 
                return rules[rule]; 
            }

            StringBuilder sb = null;

            var ruleString = rulesInput[rule];
            
            if (part2 && rule == 8)
            {
                String rule42 = "(" + GetRulePattern(42, part2) + "+)";
                rules.Add(8, rule42);
                return rule42;
            }

            if (part2 && rule == 11)
            {
                String rule42 = GetRulePattern(42, part2);
                String rule31 = GetRulePattern(31, part2);
                sb = new StringBuilder("(");
                for (int repeat = 1; repeat < 5; repeat++)
                {
                    if (repeat > 1)
                        sb.Append('|');

                    sb.Append('(');
                    
                    for (int k = 0; k < repeat; k++)
                        sb.Append(rule42);
                    
                    for (int k = 0; k < repeat; k++)
                        sb.Append(rule31);
                    
                    sb.Append(')');
                }
                sb.Append(')');

                rules.Add(11, sb.ToString());
                return sb.ToString();
            }

            if (ruleString.Contains("\"")) 
            { 
                return ruleString.Replace("\"", ""); 
            }

            sb = new StringBuilder("(");
            string[] parts = ruleString.Split(" ");
            foreach(string part in parts)
            {
                if (Char.IsDigit(part[0]))
                {
                    sb.Append(GetRulePattern(Int32.Parse(part),part2));
                }
                else if (part == "|")
                {
                    sb.Append('|');
                }
            }
            sb.Append(')');

            rules.Add(rule, sb.ToString());
            return sb.ToString();
        }

    }
}
