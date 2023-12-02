using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2023
{
    class Day02 : Helper
    {

      
        public void Solve()
        {
            var RED = 12;
            var GREEN = 13;
            var BLUE = 14;
            
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day02.txt");
            var lv = allText.Split("\r\n").ToList();
            List<long> sums = new List<long>();


          
            for (int i = 0; i < lv.Count; i++)
            {
                var part1Ok = true;
                
                var minRed = 0;
                var minGreen = 0;
                var minBlue = 0;

                var v = lv[i].Split(":");
                var games = v[1].Split(";");

                foreach (var game in games)
                {
                    var g = game.Split(", ");

                    foreach (var cc in g)
                    {
                        var c = cc.Trim().Split(" ");
                        if (c[1] == "red")
                            minRed = Math.Max(minRed, int.Parse(c[0]));
                        if (c[1] == "green")
                            minGreen = Math.Max(minGreen, int.Parse(c[0]));
                        if (c[1] == "blue")
                            minBlue = Math.Max(minBlue, int.Parse(c[0]));
                        if (c[1] == "red" && int.Parse(c[0]) > RED)
                            part1Ok = false;
                        if (c[1] == "green" && int.Parse(c[0]) > GREEN)
                            part1Ok = false;
                        if (c[1] == "blue" && int.Parse(c[0]) > BLUE)
                            part1Ok = false;
                    }



                    
                }

                if (part1Ok)
                {
                    v = v[0].Split(" ");
                    part1 += int.Parse(v[1]);
                }
                part2 += minRed * minGreen * minBlue;


            }


            WriteResult(2, part1, part2, Result.twoStars);

        }
    }
}




