using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2020
{
    class Day20 : Helper
    {
        private Dictionary<int, List<int>> tiles = new Dictionary<int, List<int>>();
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day20.txt");
            var tileSection = allText.Split("\r\n\r\n").ToList();
            foreach (var section in tileSection)
            {
                var lines = section.Split("\r\n");
                Regex r = new Regex(@"^[^ ]* (\d*):$");
                var tileId = Int32.Parse(r.Match(lines[0]).Groups[1].Value);
                tiles[tileId] = new List<int>();
                ParseTile(tileId, lines.Skip(1).ToList());
            }
            var edgeCount = new Dictionary<int, int>();
            var edgeToKey = new Dictionary<int, int>();
            
            foreach (var key in tiles.Keys)
            {
                foreach (var edge in tiles[key])
                {
                    if (edgeCount.ContainsKey(edge))
                    {
                        edgeCount[edge] += 1;
                    }
                    else
                    {
                        edgeCount.Add(edge, 1);
                        edgeToKey.Add(edge, key);
                    }
                }
            }
            
            part1 = edgeCount.Where(d => d.Value == 1)
                .Select(x => edgeToKey[x.Key])
                .GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() })
                .Where(x => x.Count == 4)
                .Select(x => x.Key)
                .Aggregate((long)1, (res, x) => (res * x));
         

            WriteResult(20, part1, part2, result.silver);
        }


        private void ParseTile(int tileId, List<string> lines)
        {
            parseEdge(tileId, lines[0]);
            parseEdge(tileId, lines[9]);
            string left = "";
            string right = "";
            for (int i = 0; i < lines.Count; i++)
            {
                left += lines[i][0];
                right += lines[i][9];
            }
            parseEdge(tileId, left);
            parseEdge(tileId, right);

        }

        private void parseEdge(int tileId, string edge)
        {
            int forward = 0;
            int backward = 0;
            for (int i = 0; i < edge.Length; i++)
            {
                if (edge[i] == '#')
                {
                    forward += (int)Math.Pow(2, i);
                    backward += (int)Math.Pow(2, edge.Length - i - 1);
                }
            }
            tiles[tileId].Add(forward);
            tiles[tileId].Add(backward);
        }
    }
}
