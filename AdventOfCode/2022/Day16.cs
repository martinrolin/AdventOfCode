using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2022
{
    class Day16 : Helper
    {

        private class Valve
        {
            public string Name { get; set; }

            public int Flow { get; set; }

            public List<string> Tunnels { get; set; }

            public Valve()
            {
                Tunnels = new List<string>();
            }
        }
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day16.txt");
            var lines = allText.Split("\r\n").ToList();
            var valves = new Dictionary<string,Valve> ();
            //Valve AA has flow rate = 0; tunnels lead to valves DD, II, BB
            foreach (var line in lines)
            {
                var v = new Valve();
                v.Name = line.Substring(6, 2);
                var tl = line.Substring(23);
                var dl = tl.Split(";");
                v.Flow = int.Parse(dl[0]);
                tl = dl[1].Replace(" tunnels lead to valve", "").Replace("s", "").Replace(" ","");
                var t = tl.Split(",");
                v.Tunnels = t.ToList();

            }


            WriteResult(16, part1, part2, Result.none);
        }
    }
}







