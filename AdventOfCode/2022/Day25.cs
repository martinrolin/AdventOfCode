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
    class Day25 : Helper
    {


        public void Solve()
        {
            string part1 = "";
            string input = System.IO.File.ReadAllText("Input\\2022\\day25.txt");


            var lines = input.Split("\r\n").ToList();
            
            var numbers = "=-012";
            ulong sum = 0;
            foreach (var line in lines)
            {
                long c = 1;
                for (int x = line.Length - 1; x >= 0; x--)
                {
                    sum += (ulong)((numbers.IndexOf(line[x]) - 2) * c);
                    c *= 5;
                }
            }

            while (sum != 0)
            {
                var m = (int)(sum % 5);
                sum /= 5;

                if (m<= 2)
                {
                    part1 = m + part1;                    
                }
                else
                { 
                    part1 = "   =-"[m] + part1;
                    sum++;
                }
                
            }

            WriteResultStringValues(25, part1, "", Result.oneStar);
        }
    }
}