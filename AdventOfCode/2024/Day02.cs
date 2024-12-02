using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2024
{

    class Day02 : Helper
    {
        private bool Check(List<string> x) {
            
            var dd = 0;
            var safe = true;
            for (var i = 1; i < x.Count; i++)
            {
                int b = int.Parse(x[i]);
                int a = int.Parse(x[i - 1]);
                var d = 0;
                if ((b - a) > 0)
                    d = 1;
                if ((b - a) < 0)
                    d = -1;
                if (dd == 0)
                    dd = d;

                if (d != 0 && dd == d)
                    safe = true;
                else
                    safe = false;

                if (Math.Abs(b - a) > 3)
                    safe = false;

                if (!safe)
                    break;


            }

            return safe;
        }


        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2024\\day02.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            foreach (var value in listOfValues)
            {
                var x = value.Split(" ").ToList<string>();

                if (Check(x))
                    part1++;
            }

            foreach (var value in listOfValues)
            {
                var x = value.Split(" ").ToList<string>();

                if (Check(x))
                    part2++;
                else {
                    for (var i = 0; i < x.Count; i++)
                    {
                        var XX = new List<string>(x);
                        XX.RemoveAt(i);

                        if (Check(XX))
                        {
                            part2++;
                            break;
                        }
                    }
                }

            }

            WriteResult(2, part1, part2, Result.twoStars);

            }
        }
    }


