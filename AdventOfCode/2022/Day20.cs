using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2022
{
    class Day20 : Helper
    {

        private class Node {
            public long Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

        }

        private void PP(long v,Node node)
        {
            Node start = null;
            Console.Write(v + "   ");
            //for (int o = 0; o < 7; o++)
            while (node != start)
            {
                if (start == null)
                    start = node;
                Console.Write(", " + node.Value);
                node = node.Right;
            }
            Console.WriteLine("");
        }

        private long Part1(string input)
        {
            var numbers = input.Split("\r\n").Select(x => long.Parse(x)).ToList();

            long part1 = 0;
            //Node start = null;
            Node previous = null;
            Node current = null;

            List<Node> nodes = new List<Node>();
            foreach (var number in numbers)
            {
                current = new Node();
                nodes.Add(current);
                current.Value = number;
                if (nodes.Count == 1)
                {
                    previous = current;
                    continue;
                }
                current.Left = previous;
                previous.Right = current;

                previous = current;

            }
            current.Right = nodes[0];
            nodes[0].Left = current;
            Node z = null;
            Node start = nodes[0];
            // PP(nodes[0]);


            for (int i = 0; i < nodes.Count; i++)
            {
                //PP(nodes[i].Value, start);
                //Console.Write(" " + nodes[i].Value);
                if (nodes[i].Value == 0)
                {
                    z = nodes[i];
                    continue;
                }

                var p = nodes[i];
                if (p.Value > 0)
                {
                    var moves = (p.Value % (nodes.Count - 1));
                    for (int j = 0; j < moves; j++)
                    {
                        p = p.Right;
                    }
                    if (nodes[i] == p)
                        continue;
                    //start = start.Right;

                    nodes[i].Left.Right = nodes[i].Right;

                    nodes[i].Right.Left = nodes[i].Left;

                    //PP(start);


                    nodes[i].Left = p;
                    nodes[i].Right = p.Right;

                    p.Right.Left = nodes[i];
                    p.Right = nodes[i];

                }
                else if (p.Value < 0)
                {
                    var moves = (-p.Value % (nodes.Count - 1));
                    for (int j = 0; j < moves; j++)
                    {
                        p = p.Left;
                    }
                    if (nodes[i] == p)
                        continue;
                    //start = start.Right;

                    nodes[i].Left.Right = nodes[i].Right;
                    nodes[i].Right.Left = nodes[i].Left;

                    nodes[i].Right = p;
                    nodes[i].Left = p.Left;

                    p.Left.Right = nodes[i];
                    p.Left = nodes[i];

                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    z = z.Right;
                }
                part1 += z.Value;
            }

            return part1;
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string input = System.IO.File.ReadAllText("Input\\2022\\day20.txt");

            Part1(input);
            var numbers = input.Split("\r\n").Select(x => long.Parse(x) * 811589153).ToList();

            //Node start = null;
            Node previous = null;
            Node current = null;

            List<Node> nodes = new List<Node>();
            foreach ( var number in numbers ) {
                current = new Node();
                nodes.Add(current);
                current.Value = number;
                if (nodes.Count == 1)
                { 
                    previous = current;
                    continue;
                }
                current.Left = previous;
                previous.Right = current;

                previous = current;
                
            }
            current.Right = nodes[0];
            nodes[0].Left = current;
            Node z = null;
            Node start = nodes[0];
            // PP(nodes[0]);

            for (int re = 0; re < 10; re++)
            {

            for (int i = 0; i < nodes.Count; i++)
            {
                //PP(nodes[i].Value, start);
                //Console.Write(" " + nodes[i].Value);
                if (nodes[i].Value == 0)
                {
                    z = nodes[i];
                    continue;
                }

                var p = nodes[i];
                if (p.Value > 0)
                {
                    var moves = (p.Value % (nodes.Count - 1));
                    for (int j = 0; j < moves; j++)
                    {
                        p = p.Right;
                    }
                    if (nodes[i] == p)
                        continue;
                    //start = start.Right;

                    nodes[i].Left.Right = nodes[i].Right;

                    nodes[i].Right.Left = nodes[i].Left;

                    //PP(start);


                    nodes[i].Left = p;
                    nodes[i].Right = p.Right;

                    p.Right.Left = nodes[i];
                    p.Right = nodes[i];

                }
                else if (p.Value < 0)
                {
                    var moves = (-p.Value % (nodes.Count - 1));
                    for (int j = 0; j < moves; j++)
                    {
                        p = p.Left;
                    }
                    if (nodes[i] == p)
                        continue;
                    //start = start.Right;

                    nodes[i].Left.Right = nodes[i].Right;
                    nodes[i].Right.Left = nodes[i].Left;

                    nodes[i].Right = p;
                    nodes[i].Left = p.Left;

                    p.Left.Right = nodes[i];
                    p.Left = nodes[i];

                }
            }

            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    z = z.Right;
                }
                part2 += z.Value;
            }





            WriteResult(20, part1, part2, Result.twoStars);
        }
    }
}







