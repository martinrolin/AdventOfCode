using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AdventOfCode._2023
{
    class Day20 : Helper
    {
        enum ModuleType { FlipFlop, Conjunction, Broadcaster}
        private class Module { 
        
            public Module() {
                from = new Dictionary<string, int>();
                to = new List<string>();
            }
            public ModuleType Type { get; set; }
            public Dictionary<string,int> from { get; set; }
            public List<string> to { get; set; }
            public int State { get; set; }
        }

        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2023\\day20.txt");
            var lv = allText.Split("\r\n").ToList();

            var q = new Queue<(string from, string to,int pulse)>();
            Dictionary<string,Module> modules = new Dictionary<string,Module>();

            

            for (int i = 0; i < lv.Count; i++)
            {
                var name = lv[i].Split(" -> ")[0];
                var type = ModuleType.Broadcaster;
                
                var m = new Module();
                if (name.StartsWith("%"))
                {
                    type = ModuleType.FlipFlop;
                    name = name.Substring(1);
                }
                else if (name.StartsWith("&"))
                {
                    type = ModuleType.Conjunction;
                    name = name.Substring(1);
                }

                //m.Name = name;
                m.Type = type;

                modules.Add(name, m);
            
            }
            for (int i = 0; i < lv.Count; i++)
            {
                var name = lv[i].Split(" -> ")[0];
                if (name.StartsWith("%"))
                    name = name.Substring(1);
                else if (name.StartsWith("&"))
                    name = name.Substring(1);

                var to = lv[i].Split(" -> ")[1].Replace(" ","").Split(",");

                foreach ( var t in to )
                {
                    modules[name].to.Add(t);
                    if (modules.ContainsKey(t))
                        modules[t].from.Add(name,0);

                }


            }

            //foreach (var m in modules)
            //{
            //    Console.WriteLine(m.Key + " " + m.Value.Name);
            //    Console.WriteLine(m.Value.Type);
            //    foreach ( var f in modules[m.Key].from)
            //        Console.WriteLine("   from  " + f.Key + " " + f.Value);
            //    Console.WriteLine();
            //    foreach (var t in modules[m.Key].to)
            //        Console.WriteLine("   to  " + t);

            //    Console.WriteLine();
            //    Console.WriteLine();


            //}
            
            int[] signals = new int[2];
            long press = 0;
            bool found = false;
            for (int i = 0; i < 1000; i++)
            //while(!found)
            {
                press++;
                if(press % 1000000 == 0)
                    Console.WriteLine(press);
                q.Enqueue(("start","broadcaster", 0));
                
                while (!found && q.Count > 0)
                {
                    var p = q.Dequeue();

                    if (p.to == "rx" && p.pulse == 0) { 
                        found = true;
                        break;
                    }

                    if (!modules.ContainsKey(p.to)) {
                        signals[p.pulse]++;
                        continue;
                    }

                    var m = modules[p.to];
                    signals[p.pulse]++;

                    if (m.Type == ModuleType.FlipFlop && p.pulse == 0)
                    {
                        foreach (var t in m.to)
                            q.Enqueue((p.to, t, (1 - m.State)));
                        m.State = 1 - m.State;                
                    }
                    else if (m.Type == ModuleType.Broadcaster)
                    {
                        foreach (var t in m.to)
                            q.Enqueue((p.to, t, p.pulse));                        
                    }
                    else if (m.Type == ModuleType.Conjunction)
                    {
                        m.from[p.from] = p.pulse;
                        int pulse = 1;
                        if (m.from.Where(x => x.Value == 1).Count() == m.from.Count())
                            pulse = 0;
                        
                        foreach (var t in m.to)
                            q.Enqueue((p.to,t, pulse));                        
                    }
                }
            }

            part1 = signals[0] * signals[1];

            WriteResult(20, part1, part2, Result.oneStar);

        }
    }
}





