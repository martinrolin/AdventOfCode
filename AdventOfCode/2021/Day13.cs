using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day13 : Helper
    {
        private void PrintPaper(int[,] paper, int xMax, int yMax)
        {
                for (int y = 0; y <= yMax; y++)
            {
            for (int x = 0; x <= xMax; x++)
                {
                    Console.Write(paper[x,y]>0?"#":" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private int CountDots(int[,] paper, int xMax, int yMax)
        {
            int sum = 0;
            for (int x = 0; x <= xMax; x++)
            {
                for (int y = 0; y <= yMax; y++)
                {
                    sum += paper[x, y];
                }
            }
            return sum;
        }

        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day13.txt");
            var lines = allText.Split("\r\n").ToList();

            int[,] paper = new int[10000, 10000];
            int xMax = 0;
            int yMax = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith("fold along y"))
                {
                    var fold = Int32.Parse(lines[i].Replace("fold along y=", ""));
                    var dy = 1;
                    while(fold+dy <=yMax)
                    {
                        for (int x = 0; x <=xMax; x++)
                        {
                            paper[x, fold - dy] = paper[x, fold - dy] + paper[x, fold + dy] > 0 ? 1 : 0;
                        }
                        dy++;
                       
                    }
                    yMax = fold - 1;
                    if (part1 == 0)
                        part1 = CountDots(paper, xMax, yMax);
                }
                else if (lines[i].StartsWith("fold along x"))
                {
                    var fold = Int32.Parse(lines[i].Replace("fold along x=", ""));
                    var dx = 1;
                    while (fold + dx <= xMax)
                    {
                        for (int y = 0; y <= xMax; y++)
                        {
                            paper[fold-dx, y] = paper[fold-dx, y] + paper[fold + dx, y] > 0 ? 1 : 0;
                        }
                        dx++;

                    }
                    xMax = fold - 1;
                    if (part1 == 0)
                        part1 = CountDots(paper, xMax, yMax);
                }
                else if (lines[i] != "")
                {
                    var data = Array.ConvertAll(lines[i].Split(","), s => Int32.Parse(s));
                    xMax = Math.Max(data[0], xMax);
                    yMax = Math.Max(data[1], yMax);
                    paper[data[0], data[1]] = 1;

                }
            }

            


            WriteResult(13, part1, part2, Result.twoStars);
            PrintPaper(paper, xMax, yMax);
        }
    }
}




