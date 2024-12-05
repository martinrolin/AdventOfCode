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

    class Day05 : Helper
    {
      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day05.txt");
            var v = allText.Split("\r\n\r\n").ToList();

            var rules = v[0].Split("\r\n").ToList();
            var updates = v[1].Split("\r\n").ToList();

            List<string> incorrect = new List<string>();
            foreach (var update in updates)
            {
                var u = update.Split(",").ToList();

                var inOrder = true;
                foreach (var rule in rules)
                {
                    var r = rule.Split("|").ToList();
                    if (u.FindIndex(p => p == r[0]) >= 0 && u.FindIndex(p => p == r[1]) >= 0 && u.FindIndex(p => p == r[0]) > u.FindIndex(p => p == r[1])) { 
                        inOrder = false;
                        break;
                    }
                }
                if (inOrder) 
                    part1+= int.Parse(u[(u.Count/2)]);   
                else
                    incorrect.Add(update);
            }


            foreach (var update in incorrect)
            {
                var u = update.Split(",").ToList();
                var tt = true;
                while (tt) {

                    tt = false;
                    foreach (var rule in rules)
                    {
                        var r = rule.Split("|").ToList();
                        if (u.FindIndex(p => p == r[0]) >= 0 && u.FindIndex(p => p == r[1]) >= 0 && u.FindIndex(p => p == r[0]) > u.FindIndex(p => p == r[1]))
                        {
                            var r0 = u.FindIndex(p => p == r[0]);
                            var r1 = u.FindIndex(p => p == r[1]);
                            var temp = u[r0];
                            u[r0] = u[r1];
                            u[r1] = temp;
                            tt = true;
                        }
                    }
                }
                part2 += int.Parse(u[(u.Count / 2)]);
            }

            WriteResult(5, part1, part2, Result.twoStars);

            }
        }
    }


