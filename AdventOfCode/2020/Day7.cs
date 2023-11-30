using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day7:Helper
    {
        private List<string> answer = new List<string>();

        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2020\\day7.txt");
            allText = allText.Replace("bags", "bag");
            var listOfValues = allText.Split("\r\n").ToList();

            var Bags = new List<string>();
            Bags.Add("shiny gold bag");
            while (Bags.Count > 0)
            {
                Bags = FindBagsThatContainCurrentBags(Bags, listOfValues);
            }

            part1 = answer.Count();
            part2 = CountContainingBags("shiny gold bag", listOfValues) - 1;

            WriteResult(7, part1, part2, Result.twoStars);
        }

        int CountContainingBags(string inputBag, List<string> listOfValues)
        {
            var localSum = 1;

            foreach (string inputLine in listOfValues)
            {
                var line = inputLine.Split("contain");
                if (line[0].Contains(inputBag) && line[1].Trim() != "no other bag.")
                {
                    var bags = line[1].Replace(".", ",").Split(",");
                    foreach (string bag in bags)
                    {
                        var bag2 = bag.Trim();
                        if (bag2 != "")
                        {
                            localSum += Int32.Parse(bag2.Substring(0, 1)) * CountContainingBags(bag2.Substring(2), listOfValues);
                        }
                    }
                }

            }
            return localSum;
        }

        List<string> FindBagsThatContainCurrentBags(List<string> inputBags, List<string> listOfValues)
        {
            var listOfBags = new List<string>();

            foreach (string ibag in inputBags)
            {
                foreach (string group in listOfValues)
                {
                    var line = group.Split("contain");
                    if (line[1].Trim() != "no other bags")
                    {
                        var bags = line[1].Replace(".", ",").Split(",");
                        foreach (string bag in bags)
                        {
                            var bag2 = bag.Trim();
                            if (bag2 != "")
                            {
                                if (bag2.Contains(ibag.Trim()))
                                {
                                    if (!listOfBags.Contains(line[0]))
                                    {
                                        listOfBags.Add(line[0]);
                                        if (!answer.Contains(line[0].Trim()))
                                            answer.Add(line[0].Trim());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return listOfBags;
        }
    }
}
