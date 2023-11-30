using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2015
{
    class Day04 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string input = File.ReadAllText("Input\\2015\\day04.txt");
            

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                
                var checksum = "";
                while (!checksum.StartsWith("00000"))
                {
                    checksum =  Convert.ToHexString(md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input + part1.ToString())));
                    part1++;

                }
                
                while (!checksum.StartsWith("000000"))
                {
                    checksum = Convert.ToHexString(md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input + part2.ToString())));
                    part2++;

                }
            }

                WriteResult(4, part1 - 1, part2 - 1, Result.twoStars);

        }

    }
}




