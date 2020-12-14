using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day2 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day2.txt");
            var listOfValues = allText.Split("\r\n").ToList();
            int correctpassword = 0;

            foreach (string element in listOfValues)
            {
                var a = element.Split(":").ToList();
                var b = a[0].Split(" ").ToList();
                var c = b[0].Split("-").ToList();

                int from = Int32.Parse(c[0].Trim());
                int to = Int32.Parse(c[1].Trim());
                string cc = b[1].Trim();
                string pass = a[1].Trim();
                int count = pass.Count(f => f == cc[0]);
                if (count >= from && count <= to)
                {
                    correctpassword += 1;
                }
            }
            part1 = correctpassword;

            correctpassword = 0;
            foreach (string element in listOfValues)
            {
                var a = element.Split(":").ToList();
                var b = a[0].Split(" ").ToList();
                var c = b[0].Split("-").ToList();

                int from = Int32.Parse(c[0].Trim());
                int to = Int32.Parse(c[1].Trim());
                string cc = b[1].Trim();
                string pass = a[1].Trim();
                int count = pass.Count(f => f == cc[0]);

                int one = cc[0] == pass[from - 1] ? 1 : 0;
                int two = cc[0] == pass[to - 1] ? 1 : 0;
                if (one + two == 1)
                {
                    correctpassword += 1;
                }
            }
            part2 = correctpassword;
            WriteResult(2, part1, part2, result.gold);
        }
    }
}
