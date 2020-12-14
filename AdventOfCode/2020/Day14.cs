using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day14 : Helper
    {
        private Dictionary<long, long> dict = new Dictionary<long, long>();

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day14.txt");
            var lines = allText.Split("\r\n").ToList(); 
            var currentMask = "";

            dict[1] = 2;

            // Part 1
            foreach (var line in lines)
            {
                if (line.Contains("mask"))
                {
                    currentMask = line.Substring(7);
                }
                else {
                    var memoryIndex = Int64.Parse(line.Substring(4, line.IndexOf(']')-4));
                    var value = Int64.Parse(line.Substring(line.IndexOf("=")+1));
                    var valueString = ToBinaryString((int)value, 36);
                    
                    for (int i = 35; i >= 0; i--)
                    {
                        if (currentMask[i] == '1' && valueString[i] == '0') 
                        {
                            value += (long)Math.Pow(2, 35-i);
                        }
                        if (currentMask[i] == '0' && valueString[i] == '1')
                        {
                            value -= (long)Math.Pow(2, 35-i);
                        }
                    }

                    dict[memoryIndex] = value;                    
                }
            }

            part1 = dict.Sum(d => d.Value);

            // Part 2
            dict.Clear();
            foreach (var line in lines)
            {
                if (line.Contains("mask"))
                {
                    currentMask = line.Substring(7);
                }
                else
                {
                    var memoryIndex = Int64.Parse(line.Substring(4, line.IndexOf(']') - 4));
                    var value = Int64.Parse(line.Substring(line.IndexOf("=") + 1));
                    var valueString = ToBinaryString((int)value, 36);

                    var memoryString = ToBinaryString(memoryIndex, 36);
                    
                    for (int i = 35; i >= 0; i--)
                    {
                        if (currentMask[i] == '1')
                        {
                            StringBuilder sb = new StringBuilder(memoryString);
                            sb[i] = '1';
                            memoryString = sb.ToString();
                        }
                        if (currentMask[i] == 'X')
                        {
                            StringBuilder sb = new StringBuilder(memoryString);
                            sb[i] = 'X';
                            memoryString = sb.ToString();
                        }
                    }

                    UpdateMemory(memoryString, value);
                }
            }

            part2 = dict.Sum(d => d.Value);

            WriteResult(14, part1, part2, result.gold);
        }

        private void UpdateMemory(string memoryAddress, long value) {            
            for (int i = 0; i < Math.Pow(2, memoryAddress.Where(c => c == 'X').Count()); i++) 
                dict[Convert.ToInt64(ReplaceXWithValues((string)memoryAddress.Clone(), ToBinaryString(i, memoryAddress.Where(c => c == 'X').Count())), 2)] = value;                              
        }

        private string ReplaceXWithValues(string input, string replacement)
        {
            if (replacement.Length == 0)
                return input;
            else {
                StringBuilder sb = new StringBuilder(input);

                sb[input.IndexOf('X')] = replacement[0];
                input = sb.ToString();
            }
            return ReplaceXWithValues(input, replacement.Substring(1));
        }

        private string ToBinaryString(long x, int length)
        {
            char[] bits = new char[100];
            int i = 0;

            while (x != 0)
            {
                bits[i++] = (x & 1) == 1 ? '1' : '0';
                x >>= 1;
            }

            Array.Reverse(bits, 0, i);
            return new string(bits).Replace("\0","").PadLeft(length,'0');
        }
    }
}
