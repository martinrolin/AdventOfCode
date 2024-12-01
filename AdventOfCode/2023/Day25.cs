using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using QuikGraph;

namespace AdventOfCode._2023
{
    class Day25 : Helper
    {

    class Graph
    {
        private readonly int _verticesCount;

        private readonly Random _random;

        private readonly List<(string from, string to)> _edges;

        public Graph(List<(string from, string to)> edges, Random random)
        {
            _verticesCount = edges.SelectMany(x => new List<string> { x.from, x.to }).Distinct().Count();
            _edges = edges;
            _random = random;
        }

        //Karger min cut algorithm. https://en.wikipedia.org/wiki/Karger%27s_algorithm. 
        public (int minCut, int vertices1Count, int verices2Count) Cut()
        {
            var contractedEdges = _edges;
            var contractedVerticesCount = _verticesCount;
            var contracted = new Dictionary<string, List<string>>();

            while (contractedVerticesCount > 2)
            {
                var edgeToContract = contractedEdges[_random.Next(0, contractedEdges.Count)];
                if (contracted.ContainsKey(edgeToContract.from))
                {
                    contracted[edgeToContract.from].Add(edgeToContract.to);
                }
                else
                {
                    contracted.Add(edgeToContract.from, [edgeToContract.to]);
                }

                if (contracted.ContainsKey(edgeToContract.to))
                {
                    contracted[edgeToContract.from].AddRange(contracted[edgeToContract.to]);
                    contracted.Remove(edgeToContract.to);
                }

                var newEdges = new List<(string from, string to)>();
                foreach (var edge in contractedEdges)
                {
                    if (edge.to == edgeToContract.to)
                    {
                        newEdges.Add((edge.from, edgeToContract.from));
                    }
                    else if (edge.from == edgeToContract.to)
                    {
                        newEdges.Add((edgeToContract.from, edge.to));
                    }
                    else
                    {
                        newEdges.Add(edge);
                    }
                }

                contractedEdges = newEdges.Where(x => x.from != x.to).ToList();
                contractedVerticesCount--;
            }

            var counts = contracted.Select(x => x.Value.Count + 1).ToList();
            return (contractedEdges.Count(), counts.First(), counts.Last());
        }


    }



    public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day25.txt");
            var lv = allText.Split("\r\n").ToList();

            HashSet<string> strings = new HashSet<string>();
            var d = new Dictionary<string, string>();
            var edges = new List<(string,string)>();

            foreach (var line in lv) { 
                var from = line.Split(":").First();
                foreach (var t in line.Split(": ").Last().Split(" ").ToList())
                {
                    edges.Add((from, t));
                }
            }
            
            //var edges =
            //    from row in lv
            //    select row.Replace(":", "").Split(" ") into split
            //    from to in split.Skip(1)
            //    let fr = split[0]
            //    select (fr, to);

            var graph = new Graph(edges.ToList(), new Random());

            var minCut = int.MaxValue;
            int count1 = 0;
            int count2 = 0;
            while (minCut != 3)
            {
                (minCut, count1, count2) = graph.Cut();
            }

            part1 = count1 * count2;
            WriteResult(25, part1, part2, Result.none);

        }
    }
}





