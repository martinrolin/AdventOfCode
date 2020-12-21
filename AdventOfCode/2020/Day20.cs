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
        private Dictionary<int, List<string>> tileContent= new Dictionary<int, List<string>>();
        private List<int> completePuzzle = new List<int>();
        private Dictionary<int,string> jigsaw = new Dictionary<int,string>();
        private int downOnFirstTileInRow;

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

            var cornerTiles = edgeCount.Where(d => d.Value == 1)
                .Select(x => edgeToKey[x.Key])
                .GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() })
                .Where(x => x.Count == 4)
                .Select(x => x.Key)
                .ToList();

            var singles = edgeCount.Where(d => d.Value == 1)   
                .Select(x => x.Key)
                .ToList();

            
            FlipTileHorizontal(1327);            
            RotateTileLeft(1327);
            RotateTileLeft(1327);
            RotateTileLeft(1327);

            var nextEdge = tiles[1327][6];
            downOnFirstTileInRow = tiles[1327][2];
            completePuzzle.Add(1327);

            while (completePuzzle.Count < 144)
            {
                if (completePuzzle.Count % 12 == 0)
                {
                    nextEdge = downOnFirstTileInRow;
                }

                nextEdge = FindNextTile(nextEdge);
            }


            generateJigsaw();
            
            int numberOfMonsters = 0;
            Regex reg = new Regex(@".{18}#.{77}#.{4}##.{4}##.{4}###.{77}#.{2}#.{2}#.{2}#.{2}#.{2}#");

            var line = JigsawToString();

            Match m = reg.Match(line);
            while (m.Captures.Count > 0)
            {
                numberOfMonsters++;
                line = line.Substring(m.Index + 1);

                m = reg.Match(line);
            }
            
            part2 = JigsawToString().Where(x => x == '#').Count()- 15*numberOfMonsters;


            WriteResult(20, part1, part2, result.gold);
        }

        private string JigsawToString()
        {
            var longLine = "";
            foreach (var jigline in jigsaw.Values)
            {
                longLine += jigline;
            }

            return longLine;
        }

        private void generateJigsaw() {
            
            for (int i = 0; i < completePuzzle.Count; i++)
            {
                int offset = i / 12;

                for (int row = 1; row < tileContent[completePuzzle[i]].Count-1; row++)
                {
                    if (!jigsaw.ContainsKey(8 * offset + row - 1))
                        jigsaw.Add(8 * offset + row - 1, "");

                    jigsaw[8 * offset + row - 1] += tileContent[completePuzzle[i]][row].Substring(1, 8);
                }
            }
        }

        private int FindNextTile(int edge)
        {
            foreach (var tile in tiles)
            {
                if( tile.Value.Contains(edge)) {
                    if (!completePuzzle.Contains(tile.Key))
                    {
                        completePuzzle.Add(tile.Key);
                        return TurnTileToCorrectOrientation(tile.Key, edge);
                    }
                }
            }
            return -1;
        }

        private int TurnTileToCorrectOrientation(int tile, int edge) 
        {
            if ((completePuzzle.Count % 12) != 1)
            {
                while (tiles[tile][4] != edge)
                {
                    if (tiles[tile][5] == edge)
                    {
                        FlipTileHorizontal(tile);
                        return tiles[tile][6];
                    }
                    else
                    {
                        RotateTileLeft(tile);
                    }
                }
            }
            else {
                while (tiles[tile][0] != edge)
                {
                    if (tiles[tile][1] == edge)
                    {
                        FlipTileVertical(tile);

                        downOnFirstTileInRow = tiles[tile][2];
                        return tiles[tile][6];
                    }
                    else
                    {
                        RotateTileLeft(tile);
                    }
                }
                downOnFirstTileInRow = tiles[tile][2];
            }
            return tiles[tile][6];
        
        }

        private void RotateTileLeft(int tile)
        {
            var temp = new List<string>();
            for (int col = 9; col >= 0; col--)
            {
                string s = "";
            
                for (int row = 0; row < 10; row++)
                {
                    s += tileContent[tile][row][col];                    
                }
                temp.Add(s);
            }
            var tempUp = tiles[tile][0];
            var tempUpX = tiles[tile][1];

            // Right to up
            tiles[tile][0] = tiles[tile][6];
            tiles[tile][1] = tiles[tile][7];

            // Down to right
            tiles[tile][6] = tiles[tile][3];
            tiles[tile][7] = tiles[tile][2];

            // Left to down
            tiles[tile][2] = tiles[tile][4];
            tiles[tile][3] = tiles[tile][5];
            
            // Up to left
            tiles[tile][4] = tempUpX;
            tiles[tile][5] = tempUp;

            tileContent[tile] = temp;
        }

        private void FlipTileHorizontal(int tile)
        {
            tileContent[tile].Reverse();
            (tiles[tile][0], tiles[tile][2]) = (tiles[tile][2], tiles[tile][0]);
            (tiles[tile][1], tiles[tile][3]) = (tiles[tile][3], tiles[tile][1]);
            (tiles[tile][4], tiles[tile][5]) = (tiles[tile][5], tiles[tile][4]);
            (tiles[tile][6], tiles[tile][7]) = (tiles[tile][7], tiles[tile][6]);

        }

        private void FlipTileVertical(int tile)
        {
            for (int i = 0; i < tileContent[tile].Count; i++)
            {
                char[] charArray = tileContent[tile][i].ToCharArray();
                Array.Reverse(charArray);
                tileContent[tile][i] = new string(charArray);                
            }
            
            (tiles[tile][0], tiles[tile][1]) = (tiles[tile][1], tiles[tile][0]);
            (tiles[tile][2], tiles[tile][3]) = (tiles[tile][3], tiles[tile][2]);
            (tiles[tile][4], tiles[tile][6]) = (tiles[tile][6], tiles[tile][4]);
            (tiles[tile][5], tiles[tile][7]) = (tiles[tile][7], tiles[tile][5]);
        }

        private void ParseTile(int tileId, List<string> lines)
        {
            parseEdge(tileId, lines[0]);
            parseEdge(tileId, lines[9]);
            string left = "";
            string right = "";
            tileContent[tileId] = new List<string>();
            for (int i = 0; i < lines.Count; i++)
            {
                tileContent[tileId].Add(lines[i]);
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
                    backward += (int)Math.Pow(2, i);
                    forward += (int)Math.Pow(2, edge.Length - i - 1);
                }
            }
            tiles[tileId].Add(forward);
            tiles[tileId].Add(backward);
        }
    }
}
