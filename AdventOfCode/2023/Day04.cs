using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2023
{
    class Day04 : Helper
    {

      
        public void Solve()
        {
           
            
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day04.txt");
            var lv = allText.Split("\r\n").ToList();
            List<List<int>> win = new List<List<int>>();
            List<List<int>> my = new List<List<int>>();

            Queue<int> queue = new Queue<int>();           

            for (int i = 0; i < lv.Count; i++)
            {
                var s = lv[i].Split(": ")[1].Split(" | ");
                var w = s[0].Trim().Replace("  ", " ").Split(" ").Select(x => int.Parse(x)).ToList();               
                var m = s[1].Trim().Replace("  "," ").Split(" ").Select(x => int.Parse(x)).ToList();
                win.Add(w);
                my.Add(m);
                queue.Enqueue(i);

                part1 += (long)Math.Pow(2, m.Where(x => w.Contains(x)).Count() - 1);
            }

            while (queue.Count > 0)
            {
                part2++;
                var i = queue.Dequeue();

                var x = my[i].Where(x => win[i].Contains(x)).Count();
                for (int j = 0; j < x; j++)
                    queue.Enqueue(i+1+j);
            }


            WriteResult(4, part1, part2, Result.twoStars);

        }
    }
}




