using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode._2023
{
    class Day19 : Helper
    {
        private Dictionary<string, List<(int, char, int, string)>> d = new Dictionary<string, List<(int, char, int, string)>>();

        private long Part1(List<string> lv)
        {
            long part1 = 0;

            //var d = new Dictionary<string, List<(int, char, long, string)>>();

            for (int r = 0; r < lv.Count; r++)
            {
                if (lv[r] == "")
                    continue;
                else if (lv[r][0] != '{')
                {
                    var x = lv[r].Replace(" ", "").Split("{");
                    d.Add(x[0], new List<(int, char, int, string)>());
                    var rules = x[1][..^1].Split(",");
                    foreach (var rule in rules)
                    {
                        if (rule.Contains(">"))
                        {
                            var rr = rule.Split(">");
                            var rd = rr[1].Split(":");

                            d[x[0]].Add((int.Parse(rr[0].Replace("x", "0").Replace("m", "1").Replace("a", "2").Replace("s", "3")), '>', int.Parse(rd[0]), rd[1]));
                        }
                        else if (rule.Contains("<"))
                        {
                            var rr = rule.Split("<");
                            var rd = rr[1].Split(":");

                            d[x[0]].Add((int.Parse(rr[0].Replace("x", "0").Replace("m", "1").Replace("a", "2").Replace("s", "3")), '<', int.Parse(rd[0]), rd[1]));
                        }
                        else if (rule == "A")
                        {
                            d[x[0]].Add(('A', 'A', 0, "A"));
                        }
                        else if (rule == "R")
                        {
                            d[x[0]].Add(('R', 'R', 0, "R"));
                        }
                        else
                        {
                            d[x[0]].Add((' ', ' ', 0, rule));
                        }
                    }
                }
                else
                {
                    var v = lv[r].Replace(" ", "")[1..^1].Replace("x=", "").Replace("m=", "").Replace("a=", "").Replace("s=", "").Split(",").Select(x => long.Parse(x)).ToList();

                    bool run = true;
                    var nextrule = "in";

                    while (run)
                    {
                        if (nextrule == "A")
                        {
                            part1 += v[0] + v[1] + v[2] + v[3];
                            run = false;
                        }
                        else if (nextrule == "R")
                        {
                            run = false;
                        }
                        else
                        {
                            var rules = d[nextrule];
                            foreach (var rule in rules)
                            {
                                if (rule.Item2 == '>')
                                {
                                    if (v[rule.Item1] > rule.Item3)
                                    {
                                        nextrule = rule.Item4;
                                        break;
                                    }
                                }
                                else if (rule.Item2 == '<')
                                {
                                    if (v[rule.Item1] < rule.Item3)
                                    {
                                        nextrule = rule.Item4;
                                        break;
                                    }
                                }
                                else if (rule.Item2 == 'A')
                                {
                                    nextrule = "A";
                                    break;
                                }
                                else if (rule.Item2 == 'R')
                                {
                                    nextrule = "R";
                                    break;
                                }
                                else
                                {
                                    nextrule = rule.Item4;
                                    break;
                                }
                            }

                        }

                    }
                }
            }


            return part1;
        
        }

        private long Part2(List<string> lv)
        {
            long part2 = 0;

            //var d = new Dictionary<string, List<(int, char, long, string)>>();

            //for (int r = 0; r < lv.Count; r++)
            //{
            //    if (lv[r] == "")
            //        continue;
            //    else if (lv[r][0] != '{')
            //    {
            //        var x = lv[r].Replace(" ", "").Split("{");
            //        d.Add(x[0], new List<(int, char, long, string)>());
            //        var rules = x[1][..^1].Split(",");
            //        foreach (var rule in rules)
            //        {
            //            if (rule.Contains(">"))
            //            {
            //                var rr = rule.Split(">");
            //                var rd = rr[1].Split(":");

            //                d[x[0]].Add((int.Parse(rr[0].Replace("x", "0").Replace("m", "1").Replace("a", "2").Replace("s", "3")), '>', long.Parse(rd[0]), rd[1]));
            //            }
            //            else if (rule.Contains("<"))
            //            {
            //                var rr = rule.Split("<");
            //                var rd = rr[1].Split(":");

            //                d[x[0]].Add((int.Parse(rr[0].Replace("x", "0").Replace("m", "1").Replace("a", "2").Replace("s", "3")), '<', long.Parse(rd[0]), rd[1]));
            //            }
            //            else if (rule == "A")
            //            {
            //                d[x[0]].Add(('A', 'A', 0, "A"));
            //            }
            //            else if (rule == "R")
            //            {
            //                d[x[0]].Add(('R', 'R', 0, "R"));
            //            }
            //            else
            //            {
            //                d[x[0]].Add((' ', ' ', 0, rule));
            //            }
            //        }               
            //    }
            //}

            var range = new List<(int,int)>();
            range.Add((1, 4000));
            range.Add((1, 4000));
            range.Add((1, 4000));
            range.Add((1, 4000));

            
            
            return Count(range, "in");


        }

        private long Count(List<(int, int)> ranges, string rule)
        {
            if (rule == "R")
                return 0;
            if (rule == "A")
            {
                long result = 1;
                foreach (var item in ranges)
                {
                    result *= (long)item.Item2 - (long)item.Item1 + 1;
                }
                return result;
            
            
            }

            long sum = 0;

            foreach (var item in d[rule])
            {
                var ooo = 0;
                if (item.Item2 == '<')
                {
                    (int start, int end) = ranges[item.Item1];
                    var newranges = new List<(int, int)>(ranges);
                    int newend = end;
                    if (end > item.Item3) {
                        newend = Math.Min(end, item.Item3 - 1);
                        newranges[item.Item1] = (start, newend);
                        ranges[item.Item1] = (item.Item3, end);
                    }

                    sum += Count(newranges, item.Item4);
                }
                else if (item.Item2 == '>')
                {
                    (int start, int end) = ranges[item.Item1];
                    var newranges = new List<(int, int)>(ranges);

                    int newstart = start;
                    if (start < item.Item3) { 
                        newstart = Math.Max(start, item.Item3 + 1);
                        newranges[item.Item1] = (newstart, end);
                        ranges[item.Item1] = (start, item.Item3);
                    }

                    sum += Count(newranges, item.Item4);
                    
                }
                else
                {
                    sum += Count(new List<(int, int)>(ranges), item.Item4);
                
                }

            }



            return sum;
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day19.txt");
            var lv = allText.Split("\r\n").ToList();

            part1 = Part1(lv);
            part2 = Part2(lv);

            WriteResult(19, part1, part2, Result.twoStars);
        }
    }
}





