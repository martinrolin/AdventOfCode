using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day15 : Helper
    {
        private Dictionary<(int, int), int> map;
        private int width;
        private int height;


        int Manhattan((int x, int y) p)
        {
            return width - 1 - p.x + width - 1 - p.y;
        }


        public void ExtendMap()
        {
            var originalWidth = width;
            var originalHeight = height;
            width *= 5;
            height *= 5;
           

            foreach (var x in Enumerable.Range(0, height))
            {
                foreach (var y in Enumerable.Range(0, width))
                {
                    var value = map[((x % originalWidth), (y % originalHeight))] + x / originalWidth + y / originalHeight;
                    while (value > 9) value -= 9;
                    map[(x, y)] = value;
                }
            }

      
        }










        bool InGrid((int x, int y) p)
        {
            return p.x >= 0 && p.x < width && p.y >= 0 && p.y < height;
        }

        IEnumerable<(int, int)> Neighbours((int x, int y) p)
        {
            return new List<(int, int)>
                {
                    (p.x - 1, p.y),
                    (p.x + 1, p.y),
                    (p.x, p.y - 1),
                    (p.x, p.y + 1),
                }.Where(InGrid);
        }


        private int CalculateRisk(bool part2) {

            if (part2) 
            {
                ExtendMap();
            }

            var dest = (width - 1, height - 1);
            var candidates = new SortedSet<(int risk, int manhattan, int x, int y)>()
                    {
                        (0, Manhattan((0, 0)), 0, 0)
                    };
            var visited = new HashSet<(int, int)> { (0, 0) };

            while (candidates.Count > 0)
            {
                var currentCandidate = candidates.First();
                candidates.Remove(currentCandidate);
                
                
                foreach (var neighbor in Neighbours((currentCandidate.x, currentCandidate.y)))
                {
                    if (neighbor == dest)
                    {
                        return currentCandidate.risk + map[dest];
                    }
                    else if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        var next = (map[neighbor] + currentCandidate.risk, Manhattan(neighbor), neighbor.Item1, neighbor.Item2);
                        candidates.Add(next);

                        
                    }
                }
            }

            throw new Exception("No valid path found");
        }
    




        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day15.txt");
            var lines = allText.Split("\r\n").ToList<string>();
            map = new Dictionary<(int, int), int>();

            width = lines[0].Length;
            height = lines.Count;

            for (int y = 0; y < lines.Count; y++)
            {
                for (int x = 0; x < lines[0].Length; x++)
                {
                    map.Add((x, y),Int32.Parse(lines[y][x].ToString()));
                }
            }

            part1 = CalculateRisk(false);
            part2 = CalculateRisk(true);



            WriteResult(15, part1, part2, result.gold);
        }
    }
}




