using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day14 : Helper
    {
        //private void PrintPaper(int[,] paper, int xMax, int yMax)
        //{
        //    for (int y = 0; y <= yMax; y++)
        //    {
        //        for (int x = 0; x <= xMax; x++)
        //        {
        //            Console.Write(paper[x, y] > 0 ? "#" : " ");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine();
        //}

        private Dictionary<string,long> StringToList(string input)
            {
            Dictionary<string,long> pairs = new Dictionary<string,long>();
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (!pairs.ContainsKey(input.Substring(i, 2)))
                    pairs.Add(input.Substring(i, 2), 1);
                else
                    pairs[input.Substring(i, 2)]++;
            }

            return pairs;
        }
        private string CombineList(List<string> input)
        {
            string s = "";
            for (int i = 0; i < input.Count; i++)
            {
                s = s + input[i];
                if(i != input.Count-1)
                    s = s.Remove(s.Length - 1, 1);

            }

            return s;
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day14.txt");
            var lines = allText.Split("\r\n").ToList();

            Dictionary<string,long> pairs = new Dictionary<string, long>();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            pairs = StringToList(lines[0]);
            for (int i = 2; i < lines.Count; i++)
            {
                var data = lines[i].Split(" -> ");
                dict.Add(data[0], data[1]);
            }

            Dictionary<string, long> letters = new Dictionary<string, long>();
            

            for (int i = 0; i < lines[0].Length; i++)
            {
                if (!letters.ContainsKey(lines[0][i].ToString()))
                    letters.Add(lines[0][i].ToString(), 1);
                else
                    letters[lines[0][i].ToString()]++;
            }

            for (int i = 0; i < 40; i++)
            {
                Dictionary<string, long> newPairs = new Dictionary<string, long>();

                foreach (var item in pairs)
                {
                    if (dict.ContainsKey(item.Key))
                    {
                        long n = item.Value;
                        if (!newPairs.ContainsKey(item.Key[0] + dict[item.Key]))
                            newPairs.Add(item.Key[0] + dict[item.Key], n);
                        else
                            newPairs[item.Key[0] + dict[item.Key]] += n;

                        if (!newPairs.ContainsKey(dict[item.Key] + item.Key[1]))
                            newPairs.Add(dict[item.Key] + item.Key[1], n);
                        else
                            newPairs[dict[item.Key] + item.Key[1]] += n;




                        if (!letters.ContainsKey(dict[item.Key]))
                            letters.Add(dict[item.Key], 1);
                        else
                            letters[dict[item.Key]] +=n;

                    }
                    else
                    {
                        newPairs.Add(item.Key, item.Value);
                    }

                }

                pairs = newPairs;
                //Console.WriteLine();
              
                if (i == 9)
                    part1 = letters.Values.Max() - letters.Values.Min();
                else
                    part2 = letters.Values.Max() - letters.Values.Min();
               
            }

     


            WriteResult(14, part1, part2, result.gold);
        }
    }
}




