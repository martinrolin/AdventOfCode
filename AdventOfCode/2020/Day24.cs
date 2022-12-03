using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2020
{
    class Day24 : Helper
    {
        private Dictionary<string, bool> map = new Dictionary<string, bool>();

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day24.txt");
            var lines = allText.Split("\r\n").ToList();
            foreach (var line in lines)
            {
                var regLine = line;

                Regex reg = new Regex(@"^((ne)|(nw)|(se)|(sw)|(e)|(w))");
                Match m = reg.Match(regLine);
                var x = 0;
                var y = 0;
                while (m.Success)
                {
                    var step = m.Captures.First().Value;
                    if (step == "e")
                    {
                        x += 2;
                        regLine = regLine.Substring(1);
                    }
                    else if (step == "w")
                    {
                        x += -2;
                        regLine = regLine.Substring(1);
                    }
                    else if (step == "ne")
                    {
                        y++;
                        x++;
                        regLine = regLine.Substring(2);
                    }
                    else if (step == "nw")
                    {
                        y++;
                        x--;
                        regLine = regLine.Substring(2);
                    }
                    else if (step == "se")
                    {
                        y--;
                        x++;
                        regLine = regLine.Substring(2);
                    }
                    else if (step == "sw")
                    {
                        y--;
                        x--;
                        regLine = regLine.Substring(2);
                    }
                    
                    m = reg.Match(regLine);
                }
                if (!map.ContainsKey(new string(x + "," + y)))
                    map.Add(new string(x + "," + y), true);
                else
                    map[new string(x + "," + y)] = !map[new string(x + "," + y)];

            }
            part1 = map.Sum(x => x.Value ? 1 : 0);
            for (int i = 0; i < 100; i++)
            {

            Step();
            }
            part2 = map.Sum(x => x.Value ? 1 : 0);
            WriteResult(24, part1, part2, Result.gold);
        }

        private void Step()
        {
            var nextMap = new Dictionary<string, bool>(map);
            foreach (var key in map.Keys)
            {
                if (map[key])
                {
                    var n = GetNeighbours(key).Sum(x => GetTile(x) ? 1 : 0);
                    if (n == 0 || n > 2)
                        nextMap[key] = false;
                }
                else {
                    var n = GetNeighbours(key).Sum(x => GetTile(x) ? 1 : 0);
                    if (n == 2)
                        nextMap[key] = true;
                }
                foreach (var neighbour in GetNeighbours(key))
                {
                    if (GetTile(neighbour))
                    {
                        var n = GetNeighbours(neighbour).Sum(x => GetTile(x) ? 1 : 0);
                        if (n == 0 || n > 2) { 
                            if (!nextMap.ContainsKey(neighbour))
                                nextMap.Add(neighbour, false);
                            nextMap[neighbour] = false;
                        }
                    }
                    else
                    {
                        var n = GetNeighbours(neighbour).Sum(x => GetTile(x) ? 1 : 0);
                        if (n == 2)
                        {
                            if (!nextMap.ContainsKey(neighbour))
                                nextMap.Add(neighbour, true);

                            nextMap[neighbour] = true;
                        }
                    }
                }
            }
            map = nextMap;
        }

        private bool GetTile(string tile) {
            if (map.ContainsKey(tile))
                return map[tile];
            else 
                return false;

        }

        private List<string> GetNeighbours(string tile) {
            var ret = new List<string>();
            var t = tile.Split(",").Select(x => Int32.Parse(x)).ToArray();
            ret.Add(new string((t[0] - 2) + "," + (t[1] - 0)));
            ret.Add(new string((t[0] + 2) + "," + (t[1] - 0)));
            ret.Add(new string((t[0] + 1) + "," + (t[1] + 1)));
            ret.Add(new string((t[0] + 1) + "," + (t[1] - 1)));
            ret.Add(new string((t[0] - 1) + "," + (t[1] + 1)));
            ret.Add(new string((t[0] - 1) + "," + (t[1] - 1)));

            return ret;

        }
    }
}
