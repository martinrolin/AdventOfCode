using QuickGraph.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AdventOfCode._2023
{
    class Day05 : Helper
    {

        private class Interval {

            public Interval(long s, long e) {
                Start = s;
                End = e;
            }

            public long Start { get; set; }
            public long End { get; set; }
        }

        private class Map
        {

            public Map(long s, long e, long ns, long ne)
            {
                Start = s;
                End = e;
                NewStart = ns;
                NewEnd = ne;
            }

            public long Start { get; set; }
            public long End { get; set; }
            public long NewStart { get; set; }
            public long NewEnd { get; set; }
        }

        private long Part1(List<string> lv)
        {
            List<long> s = null;
            var d = new List<(long, long, long)>();

            for (int i = 0; i < lv.Count; i++)
            {
                if (lv[i].StartsWith("seeds: "))
                    s = lv[i].Replace("seeds: ", "").Split(" ").Select(x => long.Parse(x)).ToList();

                else if ((lv[i].Contains("map ") || lv[i] == "") && d.Count > 0)
                {
                    var ns = new List<long>();
                    for (int j = 0; j < s.Count; j++)
                    {
                        var a = s[j];
                        var found = false;
                        foreach ((long, long, long) x in d)
                        {
                            if (a >= x.Item2 && a < x.Item2 + x.Item3)
                            {
                                var offset = a - x.Item2;
                                ns.Add(x.Item1 + offset);
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            ns.Add(a);

                    }

                    s = ns;
                    d = new List<(long, long, long)>();
                }
                else if (lv[i] == "")
                    continue;
                else if (!lv[i].Contains("map") && lv[i].Length > 0)
                {
                    var v = lv[i].Split(" ").Select(x => long.Parse(x)).ToList();
                    d.Add((v[0], v[1], v[2]));

                }
            }

            return s.Min();

        }

        private long Part2(List<string> lv)
        {
            List<Interval> s = new List<Interval>();
            List<Map> maps = new List<Map>();

            for (int i = 0; i < lv.Count; i++)
            {
                if (lv[i].StartsWith("seeds: "))
                {
                    var l = lv[i].Replace("seeds: ", "").Split(" ").Select(x => long.Parse(x)).ToList();
                    for (int j = 0; j < l.Count; j += 2)
                    {
                        s.Add(new Interval(l[j], l[j] + l[j + 1] - 1));
                    }
                }

                else if ((lv[i].Contains("map ") || lv[i] == "") && maps.Count > 0)
                {
                    var converted = new List<Interval>();

                    foreach (Map m in maps)
                    {
                        var ns = new List<Interval>();

                        for (int j = 0; j < s.Count; j++)
                        {

                            // Hela inom ett intervall
                            if (s[j].Start >= m.Start && s[j].End <= m.End)
                            {
                                var offset = s[j].Start - m.Start;
                                var len = s[j].End - s[j].Start;
                                converted.Add(new Interval(m.NewStart + offset, m.NewStart + offset + len));
                            }

                            else // Börjar innan och slutar efter
                            if (s[j].Start < m.Start && s[j].End > m.End)
                            {
                                ns.Add(new Interval(s[j].Start, m.Start - 1));
                                ns.Add(new Interval(m.End + 1, s[j].End));
                                converted.Add(new Interval(m.NewStart, m.NewEnd));
                            }
                            // Börjar innan och slutar i
                            else if (s[j].Start < m.Start && s[j].End >= m.Start)
                            {
                                ns.Add(new Interval(s[j].Start, m.Start - 1));
                                var len = s[j].End - m.Start;
                                converted.Add(new Interval(m.NewStart, m.NewStart + len));
                            }
                            // Börjar i och slutar efter
                            else if (s[j].End > m.End && s[j].Start <= m.End)
                            {
                                ns.Add(new Interval(m.End + 1, s[j].End));
                                var len = (s[j].End - s[j].Start - 1) - (s[j].End - (m.End + 1));
                                converted.Add(new Interval(m.NewEnd - len, m.NewEnd));
                            }
                            else
                            {
                                ns.Add(s[j]);
                            }
                        }
                        s = ns;
                    }

                    s.AddRange(converted);
                    converted.Clear();
                    maps.Clear();
                }
                else if (lv[i] == "")
                    continue;
                else if (!lv[i].Contains("map") && lv[i].Length > 0)
                {
                    var v = lv[i].Split(" ").Select(x => long.Parse(x)).ToList();
                    maps.Add(new Map(v[1], v[1] + v[2] - 1, v[0], v[0] + v[2] - 1));
                }
            }

            return s.Select(x => x.Start).Min();
        }

        

        public void Solve()
        {                      
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day05.txt");
            var lv = allText.Split("\r\n").ToList();

            part1 = Part1(lv);
            part2 = Part2(lv);

            
            WriteResult(5, part1, part2, Result.twoStars);

        }
    }
}




