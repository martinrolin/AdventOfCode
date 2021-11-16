using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day23 : Helper
    {
        private class Cup {
            public long value { get; set; }
            public long next { get; set; }
        }

        private Dictionary<long,Cup> cups = new Dictionary<long,Cup>();
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string input = File.ReadAllText("Input\\2020\\day23.txt");
            var first = -1;
            Cup prev = null;
            foreach (var number in input)
            {
                if (first == -1)
                    first = (int)Char.GetNumericValue(number);

                Cup c = new Cup() { value = (int)Char.GetNumericValue(number) };
                cups.Add((int)Char.GetNumericValue(number), c);
                if (prev != null) {
                    prev.next = c.value;
                }

                prev = c;                
            }
            prev.next = first;
            CrabCups(100, 9);
            long cc = 1;
            string res = "";
            for (int i = 0; i < 9; i++)
            {
                cc = cups[cc].next;
                res += cups[cc].value;
            }
            part1 = Int64.Parse(res.Substring(0, 8));


            // Part 2
            cups.Clear();
            first = -1;
            prev = null;
            foreach (var number in input)
            {
                if (first == -1)
                    first = (int)Char.GetNumericValue(number);

                Cup c = new Cup() { value = (int)Char.GetNumericValue(number) };
                cups.Add((int)Char.GetNumericValue(number), c);
                if (prev != null)
                {
                    prev.next = c.value;
                }

                prev = c;
            }

            for (int i = 10; i <= 1000000; i++)
            {
                Cup c = new Cup() { value = i };
                cups.Add(i, c);
                if (prev != null)
                {
                    prev.next = c.value;
                }

                prev = c;
            }

            prev.next = first;
            CrabCups(10000000, 1000000);

            part2 = cups[cups[1].next].value * cups[cups[cups[1].next].next].value;

            WriteResult(23, part1, part2, result.gold);
        }

        private void CrabCups(int rounds, int max)
        {
            var currentCup = cups.First().Key;
            
            for (int i = 0; i < rounds; i++)
            {
                var selectedCups = new List<long>();

                long cc = cups.First().Value.value;
                string res = "";
                for (int j = 0; j < 9; j++)
                {
                    res += cups[cc].value + " ";
                    cc = cups[cc].next;
                }

                selectedCups.Add(cups[currentCup].next);
                selectedCups.Add(cups[cups[currentCup].next].next);
                selectedCups.Add(cups[cups[cups[currentCup].next].next].next);

                var nextCup = currentCup;
                if (nextCup == 1)
                    nextCup = max + 1;
                while (selectedCups.Contains(--nextCup))
                {
                    if (nextCup == 1)
                        nextCup = max + 1;
                }
                cups[currentCup].next = cups[selectedCups[2]].next;
                cups[selectedCups[2]].next = cups[nextCup].next;
                cups[nextCup].next = selectedCups[0];

                currentCup = cups[currentCup].next;
            }                        
        }
    }
}
