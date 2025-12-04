using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode._2024
{

    class Day25 : Helper
    {
       

      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            List<string> input = File.ReadAllText("Input\\2024\\day25.txt").Split("\r\n\r\n").ToList(); ;

            List<List<int>> locks = new List<List<int>>();
            List < List<int>> keys = new List<List<int>>();

            foreach (string item in input)
            {
                var pattern = item.Split("\r\n").ToList();
                List<int> n = new List<int>();
                if (pattern[0] == "#####")
                {

                    for (int a = 0; a < pattern[0].Length; a++)
                    {
                        n.Add(pattern.Skip(1).Count(x => x[a] == '#'));
                        
                    }
                    locks.Add(n);
                }
                if (pattern[^1] == "#####")
                {

                    for (int a = 0; a < pattern[0].Length; a++)
                    {
                        n.Add(pattern.Take(pattern.Count()-1).Count(x => x[a] == '#'));

                    }
                    keys.Add(n);
                }

            }
            var o = 0;
            foreach (var l in locks)
            {
                foreach (var k in keys)
                {
                    o++;
                    var r = l.Zip(k,(a, b) => a+b).Where(c => c<=5).Count();
                    
                    if (r == 5)
                        part1++;
                }
            }



            WriteResult(25, part1, part2, Result.oneStar);

            }
        }
    }


