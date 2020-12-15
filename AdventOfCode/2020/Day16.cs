using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day16 : Helper
    {
        private class Node
        {
            public Node()
            {
                
                children = new List<Node>();
                
            }
            public int value { get; set; }
            public long paths { get; set; }
            public List<Node> children { get; set; }
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day16.txt");
            var lines = allText.Split("\r\n").ToList();

            WriteResult(16, part1, part2, result.none);
        }
    }
}
