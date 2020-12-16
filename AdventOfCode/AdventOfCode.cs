using AdventOfCode.Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class AdventOfCode
    {

        static void Main(string[] args)
        {

            Console.WindowHeight = 40;            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[Advent of code]" + Environment.NewLine );

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "[2020]");
            Console.ForegroundColor = ConsoleColor.White;
            new _2020.Day17().Solve();
            new _2020.Day16().Solve();
            new _2020.Day15().Solve();
            new _2020.Day14().Solve();            
            new _2020.Day13().Solve();
            new _2020.Day12().Solve();           
            new _2020.Day11().Solve();
            new _2020.Day10().Solve();
            new _2020.Day9().Solve();
            new _2020.Day8().Solve();
            new _2020.Day7().Solve();
            new _2020.Day6().Solve();
            new _2020.Day5().Solve();
            new _2020.Day4().Solve();
            new _2020.Day3().Solve();
            new _2020.Day2().Solve();
            new _2020.Day1().Solve();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "[2019]");
            Console.ForegroundColor = ConsoleColor.White;
            new _2019.Day1().Solve();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "[2015]");
            Console.ForegroundColor = ConsoleColor.White;
            new _2015.Day1().Solve();

            Console.ReadLine();

        }

      
    }
}
