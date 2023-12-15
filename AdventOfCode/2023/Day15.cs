using QuickGraph.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdventOfCode._2023
{
    class Day15 : Helper
    {
        private class Lens {

            public Lens(string Id, int Focal)
            {
                this.Id = Id;
                this.Focal = Focal;
            }
            public string Id { get; set; }
            public int Focal { get; set; }
        }
        private int Hash(string key)
        {
            var sum = 0;
            for (int c = 0; c < key.Length; c++)
            {
                var temp = (int)key[c];
                sum += temp;
                sum *= 17;
                sum %= 256;
            }
            return sum;
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day15.txt");
            var lv = allText.Split(",").ToList();

            
            for (int step = 0; step < lv.Count; step++)
            {
                part1 += Hash(lv[step]);
            }

            var d = new Dictionary<int, List<Lens>>();

            for (int step = 0; step < lv.Count; step++)
            {

                if (lv[step].Contains("-"))
                {
                    var b = lv[step].Remove(lv[step].Length - 1);
                    var box = Hash(b);
                    if (!d.ContainsKey(box))
                        continue;
                    var lens = d[box].Where(x => x.Id == b).FirstOrDefault();
                    if (lens != null)
                    {
                        d[box].Remove(lens);
                    }
                }
                else
                {
                    var a = lv[step].Split("=");
                    var box = Hash(a[0]);
                    if (!d.ContainsKey(box))
                    {
                        d.Add(box,new List<Lens>());
                    }
                    var lens = d[box].Where(x => x.Id == a[0]).FirstOrDefault();
                    if (lens != null)
                    {
                        lens.Focal = int.Parse(a[1]);
                    }
                    else
                    {
                        d[box].Add(new Lens(a[0], int.Parse(a[1])));
                    }
                }

            }

            foreach (var box in d.Keys)
            {
                for (int i = 0;i < d[box].Count;i++)
                {
                    part2 += (1 + box) * (1 + i) * d[box][i].Focal; 
                }

            }

            WriteResult(15 , part1, part2, Result.twoStars);
        }
    }
}





