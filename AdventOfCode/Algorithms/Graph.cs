using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Algorithms
{
    class Graph
    {
        public int V;
        public LinkedList<int>[] edges;

        public Graph()
        {

            string maze = "##########\n" +
                            "#A#    # #\n" +
                            "# # ## # #\n" +
                            "#   ## # #\n" +
                            "#####    #\n" +
                            "#B    ## #\n" +
                            "##########\n";

            var lines = maze.Split("\n").ToList();

            Graph g = new Graph(maze.Count(t => t != '\n'));

            var width = lines[0].Length;

            for (int line = 0; line < lines.Count; line++)
            {
                for (int i = 0; i < lines[line].Length; i++)
                {
                    if (lines[line][i] != '#')
                    {
                        if (lines[line - 1][i] != '#')
                        {
                            g.addEdge(line * width + i, (line - 1) * width + i);
                        }
                        if (lines[line + 1][i] != '#')
                        {
                            g.addEdge(line * width + i, (line + 1) * width + i);
                        }
                        if (lines[line][i - 1] != '#')
                        {
                            g.addEdge(line * width + i, line * width + i - 1);
                        }
                        if (lines[line][i + 1] != '#')
                        {
                            g.addEdge(line * width + i, line * width + i + 1);
                        }
                    }
                }

            }

            Console.Write("Following is the Depth First Traversal\n");
            g.DFS(11);
            Console.WriteLine();


        }

        public Graph(int V)
        {
            this.V = V;
            edges = new LinkedList<int>[V];

            for (int i = 0; i < edges.Length; i++)
                edges[i] = new LinkedList<int>();

        }

        public void addEdge(int v, int w)
        {
            edges[v].AddLast(w);
        }

        public void DFS(int s)
        {
            Boolean[] visited = new Boolean[V];

            Stack<int> stack = new Stack<int>();

            stack.Push(s);

            while (stack.Count > 0)
            {
                s = stack.Peek();
                stack.Pop();
                if (visited[s] == false)
                {
                    Console.Write(s + " ");
                    visited[s] = true;
                }

                foreach (int v in edges[s])
                {
                    if (!visited[v])
                        stack.Push(v);
                }

            }
        }
        
    }
}
