using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2022
{
    class Day05 : Helper
    {
        public void Solve()
        {            
            string allText = File.ReadAllText("Input\\2022\\day05.txt");
            var lines = allText.Split("\r\n").ToList();

            WriteResultStringValues(5, Part1(lines), Part2(lines), Result.twoStars);

        }

        private string Part1(List<string> lines)
        {
            Dictionary<int, LinkedList<string>> stacks = new Dictionary<int, LinkedList<string>>();
            foreach (var line in lines)
            {
                if (line.Contains("["))
                {
                    int stackNumber = 1;
                    for (int i = 1; i < line.Length; i += 4)
                    {
                        if (line[i] != ' ')
                        {
                            if (!stacks.ContainsKey(stackNumber))
                                stacks[stackNumber] = new LinkedList<string>();
                            stacks[stackNumber].AddLast(line[i].ToString());
                        }
                        stackNumber++;
                    }
                }

                if (line.Contains("move"))
                {
                    var move = line.Replace("move ", "").Replace(" from", "").Replace(" to", "").Split(" ").Select(x => int.Parse(x)).ToList();

                    for (int j = 0; j < move[0]; j++)
                    {
                        var pop = stacks[move[1]].First();
                        stacks[move[2]].AddFirst(pop);
                        stacks[move[1]].RemoveFirst();
                    }
                }
            }

            int s = 1;
            var part1 = "";
            while (stacks.ContainsKey(s))
            {
                part1 += stacks[s].First();
                s++;
            }

            return part1;
        }

        private string Part2(List<string> lines)
        {
            Dictionary<int, LinkedList<string>> stacks = new Dictionary<int, LinkedList<string>>();
            foreach (var line in lines)
            {
                if (line.Contains("["))
                {
                    int stackNumber = 1;
                    for (int i = 1; i < line.Length; i += 4)
                    {
                        if (line[i] != ' ')
                        {
                            if (!stacks.ContainsKey(stackNumber))
                                stacks[stackNumber] = new LinkedList<string>();
                            stacks[stackNumber].AddLast(line[i].ToString());
                        }
                        stackNumber++;
                    }
                }                

                if (line.Contains("move"))
                {
                    var move = line.Replace("move ", "").Replace(" from", "").Replace(" to", "").Split(" ").Select(x => int.Parse(x)).ToList();

                    Stack<string> stack = new Stack<string>();


                    for (int j = 0; j < move[0]; j++)
                    {
                        stack.Push(stacks[move[1]].First());
                        stacks[move[1]].RemoveFirst();                        
                    }

                    while (stack.Count >0)
                    {
                        stacks[move[2]].AddFirst(stack.Pop());
                    }
                }
            }

            int s = 1;
            var part2 = "";
            while (stacks.ContainsKey(s))
            {
                part2 += stacks[s].First();
                s++;
            }

            return part2;
        }
    }
}




