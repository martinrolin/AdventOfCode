using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day08 : Helper
    {

        private Dictionary<int, string> DecodePatterns(IEnumerable<string> input)
        {
            var dict = new Dictionary<int, string>();
            dict.Add(1, input.First(x => x.Length == 2));
            dict.Add(4, input.First(x => x.Length == 4));
            dict.Add(7, input.First(x => x.Length == 3));
            dict.Add(8, input.First(x => x.Length == 7));
            dict.Add(9, input.First(x => x.Length == 6 && dict[4].All(y => x.Contains(y))));
            dict.Add(0, input.First(x => x.Length == 6 && x != dict[9] && dict[7].All(y => x.Contains(y))));
            dict.Add(6, input.First(x => x.Length == 6 && x != dict[0] && x != dict[9]));
            dict.Add(3, input.First(x => x.Length == 5 && dict[1].All(y => x.Contains(y))));
            var cSegment = dict[3].First(x => !dict[6].Contains(x));
            dict.Add(5, input.First(x => x.Length == 5 && x != dict[3] && !x.Contains(cSegment)));
            dict.Add(2, input.First(x => x.Length == 5 && x != dict[3] && x.Contains(cSegment)));
            return dict;
        }

        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day08.txt");
            var lines = allText.Split("\r\n").ToList();

            
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i].Split(" | ");

                var output = line[1].Split(" ");

                for (int j = 0; j < output.Length; j++)
                {
                    if (output[j].Length == 2|| output[j].Length == 3 || output[j].Length == 4 || output[j].Length == 7)
                        part1++;
                    output[j] = String.Concat(output[j].OrderBy(c => c));
                }

                var dict = DecodePatterns(line[0].Split(" "));


                var outputValue = 0;
                for (int j = 0; j <output.Length ; j++)
                {
                    outputValue += dict.First(x => String.Concat(x.Value.OrderBy(c => c)) == output[output.Length - 1 - j]).Key * (int)Math.Pow(10, j);
                }
                part2 += outputValue;

            }


            WriteResult(8, part1, part2, Result.gold);
        }
    }
}




