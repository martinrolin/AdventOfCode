using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;

namespace AdventOfCode._2022
{
    class Day11 : Helper
    {

        private class Monkey {
            public List<long> Items { get; set; }
            public long Multiply { get; set; }
            public long Add { get; set; }
            public bool Pow { get; set; }
            public long Divide { get; set; }
            public int ThrowToTrue { get; set; }
            public int ThrowToFalse { get; set; }
            public Monkey() { 
                Items = new List<long>();
            }
        }

        private long Part1(List<string> lines)
        {
            var monkeys = new List<Monkey>();
            List<int> inspected = new List<int>();
            Monkey monkey = null;
            
            foreach (var line in lines)
            {
                if (line.StartsWith("Monkey"))
                {
                    monkey = new Monkey();
                    monkeys.Add(monkey);
                    inspected.Add(0);
                }
                if (line.StartsWith("  Starting items: "))
                    monkey.Items = new List<long>(line.Replace("  Starting items: ", "").Split(", ").Select(x => long.Parse(x)).ToArray());
                
                if (line.StartsWith("  Operation: new = old * old"))
                    monkey.Pow = true;               
                else if (line.StartsWith("  Operation: new = old "))
                {
                    if (line.Contains("*"))
                        monkey.Multiply = long.Parse(line.Replace("  Operation: new = old * ", ""));
                    else
                        monkey.Add = long.Parse(line.Replace("  Operation: new = old + ", ""));
                }
                if (line.StartsWith("  Test: divisible by "))
                    monkey.Divide = int.Parse(line.Replace("  Test: divisible by ", ""));
                
                if (line.StartsWith("    If true: throw to monkey "))
                    monkey.ThrowToTrue = int.Parse(line.Replace("    If true: throw to monkey ", ""));
                
                if (line.StartsWith("    If false: throw to monkey "))
                    monkey.ThrowToFalse = int.Parse(line.Replace("    If false: throw to monkey ", ""));                
            }

            for (int round = 1; round <= 20; round++)
            {
                for (int m = 0; m < monkeys.Count; m++)
                {
                    for (int i = 0; i < monkeys[m].Items.Count; i++)
                    {
                        inspected[m] += 1;
                        if (monkeys[m].Pow)
                            monkeys[m].Items[i] *= monkeys[m].Items[i];
                        else if (monkeys[m].Multiply > 0)
                            monkeys[m].Items[i] *= monkeys[m].Multiply;                     
                        else
                            monkeys[m].Items[i] += monkeys[m].Add;
                        
                        monkeys[m].Items[i] = (int)Math.Floor(monkeys[m].Items[i] / 3.0);
                        
                        if ((monkeys[m].Items[i] % (decimal)monkeys[m].Divide) == 0)
                            monkeys[monkeys[m].ThrowToTrue].Items.Add(monkeys[m].Items[i]);
                        else
                            monkeys[monkeys[m].ThrowToFalse].Items.Add(monkeys[m].Items[i]);                     
                    }
                    monkeys[m].Items.Clear();
                }
            }

            inspected.Sort();
            inspected.Reverse();
            return inspected.Take(2).Aggregate(1, (x, y) => x * y);
        }

        public void Solve()
        {
            long part1 = 0;
            ulong part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day11.txt");
            var lines = allText.Split("\r\n").ToList();


            part1 = Part1(lines);

            // Part 2
            var monkeys = new List<Monkey>();
            List<int> inspected = new List<int>();
            Monkey monkey = null;
            long mod = 1;

            foreach (var line in lines)
            {
                if (line.StartsWith("Monkey"))
                {
                    monkey = new Monkey();
                    monkeys.Add(monkey);
                    inspected.Add(0);                  
                }
                if (line.StartsWith("  Starting items: "))
                    monkey.Items = new List<long>(line.Replace("  Starting items: ", "").Split(", ").Select(x => long.Parse(x)).ToArray());
                
                if (line.StartsWith("  Operation: new = old * old"))
                    monkey.Pow = true;
                else if (line.StartsWith("  Operation: new = old "))
                {
                    if (line.Contains("*"))
                        monkey.Multiply = long.Parse(line.Replace("  Operation: new = old * ", ""));
                    else
                        monkey.Add = long.Parse(line.Replace("  Operation: new = old + ", ""));
                }
                
                if (line.StartsWith("  Test: divisible by "))
                { 
                    monkey.Divide = int.Parse(line.Replace("  Test: divisible by ", ""));
                    mod *= monkey.Divide;
                }
                if (line.StartsWith("    If true: throw to monkey "))
                    monkey.ThrowToTrue = int.Parse(line.Replace("    If true: throw to monkey ", ""));
                
                if (line.StartsWith("    If false: throw to monkey "))
                    monkey.ThrowToFalse = int.Parse(line.Replace("    If false: throw to monkey ", ""));                
            }

            for (int round = 1; round <= 10000; round++)
            {
                for (int m = 0; m < monkeys.Count; m++)
                {
                    for (int i = 0;i< monkeys[m].Items.Count;i++)
                    {
                        inspected[m] += 1;
                        if (monkeys[m].Pow)
                            monkeys[m].Items[i] *= monkeys[m].Items[i];
                        else if (monkeys[m].Multiply > 0) 
                            monkeys[m].Items[i] *= monkeys[m].Multiply;
                        else
                            monkeys[m].Items[i] += monkeys[m].Add;

                        monkeys[m].Items[i] %= mod;

                        if ((monkeys[m].Items[i] % (decimal)monkeys[m].Divide) == 0)
                            monkeys[monkeys[m].ThrowToTrue].Items.Add(monkeys[m].Items[i]);
                        else
                            monkeys[monkeys[m].ThrowToFalse].Items.Add(monkeys[m].Items[i]);
                    }
                    monkeys[m].Items.Clear();
                }
            }

            inspected.Sort();
            inspected.Reverse();
            part2 = (ulong)inspected[0] * (ulong)inspected[1];

            WriteResultStringValues(11, part1.ToString(), part2.ToString(), Result.twoStars);
        }
    }
}







