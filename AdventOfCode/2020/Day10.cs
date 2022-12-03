using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day10 :Helper
    {
        private class Node
        {
            public Node(int v)
            {
                value = v;
                children = new List<Node>();
                paths = 0;
            }
            public int value { get; set; }
            public long paths { get; set; }
            public List<Node> children { get; set; }
        }

        Dictionary<int, Node> nodes = new Dictionary<int, Node>();

        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day10.txt");
            var lines = allText.Split("\r\n").Select(l => Int32.Parse(l)).ToList();
            var NumberOfDifferences = new Dictionary<int, int>();
            NumberOfDifferences.Add(1, 0);
            NumberOfDifferences.Add(2, 0);
            NumberOfDifferences.Add(3, 1);
            var sorted = lines.OrderBy(l => l).ToArray<int>();
            var current = 0;

            nodes.Add(0, new Node(0));
            foreach (var x in sorted)
            {
                nodes.Add(x, new Node(x));
                NumberOfDifferences[x - current] = NumberOfDifferences[x - current] + 1;
                current = x;
            }
            part1 = NumberOfDifferences[3] * NumberOfDifferences[1];

            // Part 2
            FillDictionary(sorted, nodes[0]);
            Traverse(sorted.Last<int>(), nodes[0]);

            part2 = nodes[0].paths;
            WriteResult(10, part1, part2, Result.gold);
        }

        private static void Traverse(int max, Node n)
        {
            if (n.value == max)
            {
                n.paths = 1;
                return;
            }

            foreach (var child in n.children.Where(n => n.paths == 0))
                Traverse(max, child);

            n.paths = n.children.Sum(x => x.paths);
        }

        private void FillDictionary(int[] sorted, Node n)
        {
            if (n.value == sorted[^1])
                return;

            if (nodes.ContainsKey(n.value + 1))
            {
                if (!n.children.Contains(nodes[n.value + 1]))
                {
                    n.children.Add(nodes[n.value + 1]);
                    FillDictionary(sorted, nodes[n.value + 1]);
                }
            }
            if (nodes.ContainsKey(n.value + 2))
            {
                if (!n.children.Contains(nodes[n.value + 2]))
                {
                    if (!n.children.Contains(nodes[n.value + 2]))
                    {
                        n.children.Add(nodes[n.value + 2]);
                        FillDictionary(sorted, nodes[n.value + 2]);
                    }
                }
            }
            if (nodes.ContainsKey(n.value + 3))
            {
                if (!n.children.Contains(nodes[n.value + 3]))
                {
                    n.children.Add(nodes[n.value + 3]);
                    FillDictionary(sorted, nodes[n.value + 3]);
                }
            }
        }
    }
}
