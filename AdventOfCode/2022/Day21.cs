using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2022
{
    class Day21 : Helper
    {

     

        private double Eval(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            return Convert.ToDouble(table.Compute(expression, ""));
        }


        private long Part1(string input)
        {

            var monkeys = new Dictionary<string, double>();
            var lines = input.Split("\r\n").ToList();
            var q = new Queue<(string, string)>();
            foreach (var line in lines)
            {
                var name = line.Split(": ")[0];
                var op = line.Split(": ")[1];

                q.Enqueue((name, op));

            }

            var test = Eval("18171683.0*1209221");

            while (q.Count > 0)
            {

                var monkey = q.Dequeue();
                var op = monkey.Item2.Split(" ");
                if (op.Length == 1)
                {
                    monkeys.Add(monkey.Item1, double.Parse(op[0]));
                }
                else
                {
                    if (monkeys.ContainsKey(op[0]) && monkeys.ContainsKey(op[2]))
                    {
                        var t = monkeys[op[0]] + ".0" + op[1] + monkeys[op[2]] + ".0";
                        var v = Eval(t);
                        monkeys.Add(monkey.Item1, Eval(monkeys[op[0]] + ".0" + op[1] + monkeys[op[2]] + ".0"));
                    }
                    else
                    {
                        q.Enqueue(monkey);
                    }
                }

            }

            return (long)monkeys["root"];
        }

        public struct Monkey
        {
            public double value;
            public string left, right, op;
        }
        public Dictionary<string, Monkey> data = new Dictionary<string, Monkey>();

        public void parse(List<string> input)
        {
            foreach (var s in input)
            {
                var s1 = s.Split(": ");
                var s2 = s1[1].Split(' ');
                if (s2.Length == 1) data.Add(s1[0], new Monkey { value = double.Parse(s2[0]), op = "V" });
                else data.Add(s1[0], new Monkey { left = s2[0], right = s2[2], op = s2[1] });
            }
        }

        public (double, double) compute(string key, List<string>? order = null)
        {
            if (order != null) order.Add(key);
            if (key == "humn") return (1, 0);
            if (data[key].op[0] == 'V') return (0, data[key].value);
            var (lh, lv) = compute(data[key].left, order);
            var (rh, rv) = compute(data[key].right, order);
            switch (data[key].op[0])
            {
                case '+': return (lh + rh, lv + rv);
                case '-': return (lh - rh, lv - rv);
                case '*': return (lv * rh + lh * rv, lv * rv);
                case '/': return (lh / rv, lv / rv);
                default: break;
            }
            return (0, 0);
        }

      
        public string part2()
        {
            var (lh, lv) = compute(data["root"].left);
            var (rh, rv) = compute(data["root"].right);
            var ret = (lh != 0) ? ((rv - lv) / lh) : ((lv - rv) / rh);
            return Math.Round(ret).ToString();
        }





        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string input = System.IO.File.ReadAllText("Input\\2022\\day21.txt");

            part1 = Part1(input);

         

            var lines = input.Split("\r\n").ToList();
            parse(lines);
            var (lh, lv) = compute(data["root"].left);
            var (rh, rv) = compute(data["root"].right);
            var ret = (lh != 0) ? ((rv - lv) / lh) : ((lv - rv) / rh);
            var x =  Math.Round(ret).ToString();



            WriteResult(21, part1, part2, Result.oneStar);
        }
    }
}







