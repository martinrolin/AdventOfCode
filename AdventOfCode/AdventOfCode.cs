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
            Console.WriteLine(Environment.NewLine + "[2022]");
            Console.ForegroundColor = ConsoleColor.White;
            new _2022.Day14().Solve();
            new _2022.Day13().Solve();
            new _2022.Day12().Solve();
            new _2022.Day11().Solve();
            new _2022.Day10().Solve();
            new _2022.Day09().Solve();
            new _2022.Day08().Solve();
            new _2022.Day07().Solve();
            new _2022.Day06().Solve(); 
            new _2022.Day05().Solve(); 
            new _2022.Day04().Solve();
            new _2022.Day03().Solve();
            new _2022.Day02().Solve();
            new _2022.Day01().Solve();

            new _2015.Day05().Solve();
            

            Console.ReadLine();
            return;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "[2021]");
            Console.ForegroundColor = ConsoleColor.White;
            
            new _2021.Day17().Solve();
            new _2021.Day16().Solve();
            new _2021.Day15().Solve();
            new _2021.Day14().Solve();
            new _2021.Day13().Solve();
            new _2021.Day12().Solve();
            new _2021.Day11().Solve();
            new _2021.Day10().Solve();
            new _2021.Day09().Solve();
            new _2021.Day08().Solve();
            new _2021.Day07().Solve();
            new _2021.Day06().Solve();
            new _2021.Day05().Solve();
            new _2021.Day04().Solve();
            new _2021.Day03().Solve();
            new _2021.Day02().Solve();
            new _2021.Day01().Solve();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "[2020]");
            Console.ForegroundColor = ConsoleColor.White;
            new _2020.Day25().Solve();
            new _2020.Day24().Solve();
            new _2020.Day23().Solve();
            new _2020.Day22().Solve();
            new _2020.Day21().Solve();
            new _2020.Day20().Solve();
            new _2020.Day19().Solve();
            new _2020.Day18().Solve();
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
            new _2015.Day04().Solve();
            new _2015.Day03().Solve();
            new _2015.Day02().Solve();
            new _2015.Day01().Solve();

            Console.ReadLine();

        }

      
    }
}
