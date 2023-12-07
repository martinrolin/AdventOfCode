using QuickGraph.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdventOfCode._2023
{
    class Day07 : Helper
    {
        

        private class P : IComparable<P>
        {
            private static Dictionary<string, int> CardValue = new Dictionary<string, int> { { "A", 10 }, { "A", 14 }, { "K", 13 }, { "Q", 12 }, { "J", 11 }, { "T", 10 }, { "9", 9 }, { "8", 8 }, { "7", 7 }, { "6", 6 }, { "5", 5 }, { "4", 4 }, { "3", 3 }, { "2", 2 } };

            public P(string h, int b, string oh, bool p2)
            {
                Hand = h;
                Bid = b;
                OriginalHand = oh;
                Part2 = p2;
            }
            public string Hand { get; set; }
            public string OriginalHand { get; set; }
            public int Bid { get; set; }
            public bool Part2 { get; set; }

            public int CompareTo(P next)
            {
                var a = CountDuplicates(this.Hand);
                var b = CountDuplicates(next.Hand);

                if (a.Count() > 0 && b.Count() == 0)
                {
                    return 1;
                }
                else if (b.Count() > 0 &&  a.Count() == 0)
                {
                    return -1;
                }
                else if (a.Count() > 0 && b.Count() > 0 && a.Max() > b.Max())
                {
                    return 1;
                }
                else if (a.Count() > 0 && b.Count() > 0 && a.Max() < b.Max())
                {
                    return -1;
                }
                else if (a.Count() > 0 && b.Count() > 0 && a.Sum() > b.Sum())
                {
                    return 1;
                }
                else if (a.Count() > 0 && b.Count() > 0 && a.Sum() < b.Sum())
                {
                    return -1;
                }
                else 
                {
                    var CardValue = new Dictionary<char, int> { { 'A', 14 }, { 'K', 13 }, { 'Q', 12 }, { 'J', 11 }, { 'T', 10 }, { '9', 9 }, { '8', 8 }, { '7', 7 }, { '6', 6 }, { '5', 5 }, { '4', 4 }, { '3', 3 }, { '2', 2 } };
                    if (this.Part2)
                        CardValue = new Dictionary<char, int> { { 'A', 14 }, { 'K', 13 }, { 'Q', 12 }, { 'T', 10 }, { '9', 9 }, { '8', 8 }, { '7', 7 }, { '6', 6 }, { '5', 5 }, { '4', 4 }, { '3', 3 }, { '2', 2 }, { 'J', 1 } };


                    for (int i = 0; i < 5; i++)
                    {
                        
                        if (CardValue[this.OriginalHand[i]] > CardValue[next.OriginalHand[i]])
                            return 1;
                        if (CardValue[this.OriginalHand[i]] < CardValue[next.OriginalHand[i]])
                            return -1;

                    }
                    return 0;
                }


            }

        }

        public static List<int> CountDuplicates(string str)
        {
            var r = (from c in str
             group c by c
             into grp
             where grp.Count() > 1
             select grp.Count()).ToList();

            return r;
        }
        public static char LargestGroup(string str)
        {
            var r = (from c in str
                     group c by c
             into grp
                     where (grp.Count() > 1 && grp.Key != 'J')
                     orderby grp.Count()
                     select (grp.Key, grp.Count())).ToList();

            if (r.Count == 0)
                return '-';
            else
                return r.Last().Key;        
        }

        private long Part1(List<string> lv)
        {
            long part1  = 0;
            List<P> p = new List<P>();
            var CardValue = new Dictionary<char, int> { { 'A', 14 }, { 'K', 13 }, { 'Q', 12 }, { 'T', 10 }, { '9', 9 }, { '8', 8 }, { '7', 7 }, { '6', 6 }, { '5', 5 }, { '4', 4 }, { '3', 3 }, { '2', 2 } };


            for (int i = 0; i < lv.Count; i++)
            {
               

                p.Add(new P(lv[i].Split(" ")[0], int.Parse(lv[i].Split(" ")[1]), lv[i].Split(" ")[0],false));

            }

            p.Sort();

            for (int i = 0; i < p.Count; i++)
            {
                part1 += (i + 1) * p[i].Bid;
               
            }
            return part1;
        }

        private long Part2(List<string> lv)
        {
            long part2 = 0;
            List<P> p = new List<P>();
            var CardValue = new Dictionary<char, int> { { 'A', 14 }, { 'K', 13 }, { 'Q', 12 }, { 'T', 10 }, { '9', 9 }, { '8', 8 }, { '7', 7 }, { '6', 6 }, { '5', 5 }, { '4', 4 }, { '3', 3 }, { '2', 2 } };


            for (int i = 0; i < lv.Count; i++)
            {
                var hand = lv[i].Split(" ")[0];

                var lg = LargestGroup(hand);
                if (lg != '-')
                    hand = hand.Replace('J', lg);
                if (hand.Where(x => x != 'J').Any())
                {
                    hand = hand.Replace('J', hand.Where(x => x != 'J').First());
                }


                p.Add(new P(hand, int.Parse(lv[i].Split(" ")[1]), lv[i].Split(" ")[0], true));

            }

            p.Sort();

            for (int i = 0; i < p.Count; i++)
            {
                part2 += (i + 1) * (p[i].Bid);
            }
            return part2;

        }

        public void Solve()
        {                      
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day07.txt");
            var lv = allText.Split("\r\n").ToList();


            part1 = Part1(lv);
            part2 = Part2(lv);

           
            WriteResult(7, part1, part2, Result.twoStars);
            
        }
    }
}




