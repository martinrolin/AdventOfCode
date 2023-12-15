using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AdventOfCode._2019
{
    class Day02 : Helper
    {

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2019\\day02.txt");
            var vs = allText.Split(",").Select(x => int.Parse(x)).ToList();

            int i = 0;
            vs[1] = 12;
            vs[2] = 2;
            while (vs[i] != 99)
            {
                if (vs[i] == 1)
                    vs[vs[i + 3]] = vs[vs[i + 1]] + vs[vs[i + 2]];                
                else if (vs[i] == 2)
                    vs[vs[i + 3]] = vs[vs[i + 1]] * vs[vs[i + 2]];

                i += 4;
            }

            part1 = vs[0];

            for (int a = 0; a < 100 && part2 == 0; a++)
            {
                for (int b = 0; b < 100 && part2 == 0; b++)
                {
                    vs = allText.Split(",").Select(x => int.Parse(x)).ToList();
                    vs[1] = a;
                    vs[2] = b;
                    i = 0;
                    while (vs[i] != 99)
                    {
                        if (vs[i] == 1)
                            vs[vs[i + 3]] = vs[vs[i + 1]] + vs[vs[i + 2]];
                        else if (vs[i] == 2)
                            vs[vs[i + 3]] = vs[vs[i + 1]] * vs[vs[i + 2]];

                        i += 4;
                    }

                    if (vs[0] == 19690720)
                        part2 = 100 * a + b;
                }

            }

          
            WriteResult(2, part1, part2, Result.none);

        }
    }
}
