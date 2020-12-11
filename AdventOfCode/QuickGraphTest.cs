using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class QuickGraphTest
    {
     
        public void Run() {
            var g = new UndirectedGraph<int, TaggedUndirectedEdge<int, int>>();

            var e1 = new TaggedUndirectedEdge<int, int>(1, 2, 57);
            var e2 = new TaggedUndirectedEdge<int, int>(1, 4, 65);
            var e3 = new TaggedUndirectedEdge<int, int>(2, 3, 500);
            var e4 = new TaggedUndirectedEdge<int, int>(2, 4, 1);
            var e5 = new TaggedUndirectedEdge<int, int>(3, 4, 78);
            var e6 = new TaggedUndirectedEdge<int, int>(3, 5, 200);

            g.AddVerticesAndEdge(e1);
            g.AddVerticesAndEdge(e2);
            g.AddVerticesAndEdge(e3);
            g.AddVerticesAndEdge(e4);
            g.AddVerticesAndEdge(e5);
            g.AddVerticesAndEdge(e6);

            foreach (var v in g.Edges)
                Console.WriteLine(v);
            Console.WriteLine("--------");
            //Func<TaggedUndirectedEdge<int, int>, double> edgeWeights = (q) =>
            //{
            //    g.Edges.SingleOrDefault(m => q == m).Tag;
            //};

            var mst = g.MinimumSpanningTreePrim(e => e.Tag).ToList();
            foreach (var v in mst)
                Console.WriteLine(v);
        }
    }
}
