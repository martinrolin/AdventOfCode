using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day1 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day1.txt");
            var listOfValues = allText.Split("\r\n").ToList();
            for (int i = 0; i < listOfValues.Count - 1; i++)
            {
                int inum = Int32.Parse(listOfValues[i]);
                for (int j = i + 1; j < listOfValues.Count; j++)
                {
                    int jnum = Int32.Parse(listOfValues[j]);
                    if (inum + jnum == 2020)
                    {
                        part1 = inum * jnum;
                    }
                }


            }

            for (int i = 0; i < listOfValues.Count - 2; i++)
            {
                int inum = Int32.Parse(listOfValues[i]);
                for (int j = i + 1; j < listOfValues.Count - 1; j++)
                {
                    int jnum = Int32.Parse(listOfValues[j]);
                    for (int k = j + 1; k < listOfValues.Count; k++)
                    {
                        int knum = Int32.Parse(listOfValues[k]);

                        if (inum + jnum + knum == 2020)
                        {
                            part2 = inum * jnum * knum;
                        }
                    }
                }
            }
            WriteResult(1, part1, part2, Result.twoStars);

        }
    }
}
