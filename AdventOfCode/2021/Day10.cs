using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day10 : Helper
    {
       
        private (int,Stack<char>) FindCorruptCode(string code)
        {
            Stack<char> stack = new Stack<char>();
            
            for (int i = 0; i < code.Length; i++)
            {
                
                if (code[i] == '(' || code[i] == '[' || code[i] == '<' || code[i] == '{')
                {
                    stack.Push(code[i]);
                }
                else
                {
                    if (stack.Peek() == '(' && code[i] == ')' || stack.Peek() == '[' && code[i] == ']' || stack.Peek() == '<' && code[i] == '>' || stack.Peek() == '{' && code[i] == '}')
                        stack.Pop();
                    else if (code[i] == ')')
                        return (3, new Stack<char>());
                    else if (code[i] == ']')
                        return (57, new Stack<char>());
                    else if (code[i] == '}')
                        return (1197, new Stack<char>());
                    else if (code[i] == '>')
                        return (25137, new Stack<char>());
        }
            }
            return (0,stack);
        }

        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day10.txt");
            var lines = allText.Split("\r\n").ToList();
            Stack<char> stack;
            for (int i = 0; i < lines.Count; i++)
            {
                int points;
                (points, stack) = FindCorruptCode(lines[i]);
                part1 += points;
            }

            List<long> scores = new List<long>();
            for (int i = 0; i < lines.Count  ; i++)
            {
                int points;
                long score = 0;
                (points, stack) = FindCorruptCode(lines[i]);

                while (points == 0 && stack.Count > 0)
                {
                    char c = stack.Pop();
                    if (c == '(')
                        score = score * 5 + 1;
                    if (c == '[')
                        score = score * 5 + 2;
                    if (c == '{')
                        score = score * 5 + 3;
                    if (c == '<')
                        score = score * 5 + 4;
                    
                }
                if (score > 0) 
                    scores.Add(score);

            }

            scores.Sort();
            part2 = scores[scores.Count / 2];

            WriteResult(10, part1, part2, Result.gold);
        }
    }
}




