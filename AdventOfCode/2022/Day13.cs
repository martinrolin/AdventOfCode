using Newtonsoft.Json.Linq;
using System;
using System.Linq;


namespace AdventOfCode._2022
{
    class Day13: Helper
    {


        private int Compare(JToken x, JToken y)
        {
            if (x.Type == JTokenType.Integer)
            {
                if (y.Type == JTokenType.Integer)
                    return x.Value<int>() - y.Value<int>();
                
                else
                    return Compare(new JArray(x), y);
                
            }
            else {
                if (y.Type == JTokenType.Integer)
                    return Compare(x, new JArray(y));                
            }
                      
            foreach (var item in Enumerable.Zip(x,y))
            {
                var t = Compare(item.First, item.Second);
                if (t != 0)
                    return t;
            }

            return x.Count() - y.Count();           
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day13.txt");
            var pairs = allText.Split("\r\n\r\n").ToList();



            for (int i = 0; i < pairs.Count; i++)
            {
                var packets = pairs[i].Split("\r\n");

                if (Compare(JArray.Parse(packets[0]), JArray.Parse(packets[1])) < 0) 
                    part1 += i + 1;
                
            }

            var p = allText.Replace("\r\n\r\n","\r\n").Split("\r\n");

            int i2 = 1;
            int i6 = 2;

            foreach (var packet in p)
            {
                if (Compare(JArray.Parse(packet), new JArray(new JArray(2))) < 0)
                {
                    i2++;
                    i6++;
                }
                else if (Compare(JArray.Parse(packet), new JArray(new JArray(6))) < 0)
                {
                    i6++;
                }
            }

            part2 = i2 * i6;


            WriteResult(13, part1, part2, Result.gold);
        }
    }
}







