using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day16 : Helper
    {
        private List<int[]> listOfRules = new List<int[]>();
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day16.txt");
            var lines = allText.Split("\r\n").ToList();
            var validLines = new List<int[]>();
            int row = 0;
            while (lines[row] != "") {
                listOfRules.Add(new int[] { 
                    Int32.Parse(lines[row].Split(": ")[1].Split(" or ")[0].Split("-")[0]),
                    Int32.Parse(lines[row].Split(": ")[1].Split(" or ")[0].Split("-")[1]),
                    Int32.Parse(lines[row].Split(": ")[1].Split(" or ")[1].Split("-")[0]),
                    Int32.Parse(lines[row].Split(": ")[1].Split(" or ")[1].Split("-")[1])
                });
                row++;
            }
            validLines.Add(lines[row+2].Split(",").Select(x => Int32.Parse(x)).ToArray());
            row += 5;
            while (row < lines.Count) {
                if (TestTicket(lines[row].Split(",").ToArray()) > 0)
                {
                    part1 += TestTicket(lines[row].Split(",").ToArray());
                }
                else {
                    if (lines[row][0] !='0' && !lines[row].Contains(",0,"))
                        validLines.Add(lines[row].Split(",").Select(x => Int32.Parse(x)).ToArray());
                }               
                row++;
            }
        
            List<int>[] validRulesForColumn = new List<int>[20];            
            for (int c = 0; c < validLines[0].Count(); c++)
            {
                               
                int ruleRow = 0;
                foreach (int[] rule in listOfRules)
                {
                    bool passed = true;

                    for (int l = 0;l< validLines.Count();l++)
                    {
                        int testval = validLines[l][c];
                        if ((testval < rule[0] || testval > rule[1]) && (testval < rule[2] || testval > rule[3]))
                            passed = false;
                    }
                    if (passed)
                    {
                        if (validRulesForColumn[c] == null)
                            validRulesForColumn[c] = new List<int>();
                        validRulesForColumn[c].Add(ruleRow);
                    }

                    ruleRow++;
                }            
            }
            var ll = new List<int>();
            part2 = 1;

            foreach (var r in validRulesForColumn.OrderBy(x => x.Count).Select(x=> x))
            {
                int index = 0;
                for (int i = 0; i < 20; i++) {
                    if (validRulesForColumn[i].Count == r.Count) {
                        index = i;
                    }
                }

                if (r.Except(ll).FirstOrDefault() < 6)
                {
                    part2 *= validLines[0][index];
                }
                ll.Add(r.Except(ll).FirstOrDefault());
            }
            
            WriteResult(16, part1, part2, result.gold);
        }

        private int TestTicket(string[] values) {
            var rval = 0;
            foreach (string value in values) {
                int testval = Int32.Parse(value);
                bool passed = false;
                foreach (int[] rule in listOfRules)
                {
                    if ((testval >= rule[0] && testval <= rule[1]) || (testval >= rule[2] && testval <= rule[3]))
                        passed = true;
                }
                if (!passed)
                    rval += testval;
            }
            return rval;
        }
    }
}
