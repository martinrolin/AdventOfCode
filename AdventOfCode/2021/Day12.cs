using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day12 : Helper
    {
        private Dictionary<string, List<string>> map;

        private Dictionary<string, List<string>> GetMap(string input)
        {
            var connections =
                from line in input.Split("\r\n")
                let parts = line.Split("-")
                let caveA = parts[0]
                let caveB = parts[1]
                from connection in new[] { (From: caveA, To: caveB), (From: caveB, To: caveA) }
                select connection;

            return (
                from p in connections
                group p by p.From into g
                select g
            ).ToDictionary(g => g.Key, g => g.Select(connnection => connnection.To).ToList());
        }
   
        int VisitCave(string currentCave, ImmutableHashSet<string> visitedCaves, bool anySmallCaveWasVisitedTwice, bool part2)
        {

            if (currentCave == "end")
            {
                return 1;
            }

            var res = 0;
            foreach (var cave in map[currentCave])
            {
                var isBigCave = cave.ToUpper() == cave;

                if (!visitedCaves.Contains(cave) || isBigCave)
                {
                    res += VisitCave(cave, visitedCaves.Add(cave), anySmallCaveWasVisitedTwice, part2);
                }
                else if (part2 && !isBigCave && cave != "start" && !anySmallCaveWasVisitedTwice)
                {
                    res += VisitCave(cave, visitedCaves, true, part2);
                }
            }
            return res;
        }   

        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string input = File.ReadAllText("Input\\2021\\day12.txt");

            map = GetMap(input);
            part1 = VisitCave("start", ImmutableHashSet.Create("start"), false, false);
            part2 = VisitCave("start", ImmutableHashSet.Create("start"), false, true);

            WriteResult(12, part1, part2, Result.gold);
        }
    }
}




