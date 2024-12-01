using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace AdventOfCode._2023
{
    class Day22 : Helper
    {

        bool Overlaps(List<int> a, List<int> b)
        {
            return Math.Max(a[0], b[0]) <= Math.Min(a[3], b[3]) &&
                   Math.Max(a[1], b[1]) <= Math.Min(a[4], b[4]);
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day22.txt");
            var lv = allText.Split("\r\n").ToList();

            List<List<int>> bricks = File.ReadAllLines("Input\\2023\\day22.txt") .Select(line => line.Replace("~", ",").Split(',').Select(int.Parse).ToList()).ToList();

            bricks.Sort((a, b) => a[2].CompareTo(b[2]));
          
            for (int index = 0; index < bricks.Count; index++)
            {
                int maxheight = 1;
                for (int i = 0; i < index; i++)
                {
                    if (Overlaps(bricks[index], bricks[i]))
                        maxheight = Math.Max(maxheight, bricks[i][5] + 1);                    
                }
                
                bricks[index][5] = maxheight + (bricks[index][5] - bricks[index][2]);
                bricks[index][2] = maxheight;
            }

            bricks.Sort((a, b) => a[2].CompareTo(b[2]));

            Dictionary<int, HashSet<int>> supports = new Dictionary<int, HashSet<int>>();
            Dictionary<int, HashSet<int>> supportedby = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < bricks.Count; i++)
            {
                supports[i] = new HashSet<int>();
                supportedby[i] = new HashSet<int>();
                for (int j = 0; j < i; j++)
                {
                    if (Overlaps(bricks[j], bricks[i]) && bricks[i][2] == bricks[j][5] + 1)
                    {
                        supports[j].Add(i);
                        supportedby[i].Add(j);
                    }
                }
            }

            int total = 0;

            for (int i = 0; i < bricks.Count; i++)
            {
                if (supports[i].All(j => supportedby[j].Count >= 2))
                {
                    part1++;
                }
            }

            Console.WriteLine(total);

            total = 0;

            for (int i = 0; i < bricks.Count; i++)
            {
                var q = new Queue<int>(supports[i].Where(j => supportedby[j].Count == 1));
                var falling = new HashSet<int>(q);
                falling.Add(i);

                while (q.Count > 0)
                {
                    int j = q.Dequeue();
                    foreach (int k in supports[j].Except(falling))
                    {
                        if (supportedby[k].IsSubsetOf(falling))
                        {
                            q.Enqueue(k);
                            falling.Add(k);
                        }
                    }
                }

                total += falling.Count - 1;
            }

            Console.WriteLine(total);


            WriteResult(22, part1, part2, Result.none);

        }
    }
}





