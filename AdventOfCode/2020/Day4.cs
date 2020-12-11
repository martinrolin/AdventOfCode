using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2020
{
    class Day4 : Helper
    {
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("input\\2020_day4.txt");
            var listOfValues = allText.Split("\r\n\r\n").ToList();

            int NumberOfValidPassports = 0;
            foreach (string element in listOfValues)
            {
                var e2 = element.Replace("\r\n", " ").Replace("  ", " "); ;
                var l = e2.Split(" ");

                Dictionary<string, bool> myDict = new Dictionary<string, bool>();

                myDict.Add("byr", false);
                myDict.Add("iyr", false);
                myDict.Add("eyr", false);
                myDict.Add("hgt", false);
                myDict.Add("hcl", false);
                myDict.Add("ecl", false);
                myDict.Add("pid", false);
                myDict.Add("cid", false);


                foreach (string part in l)
                {
                    var p = part.Split(":");
                    myDict[p[0]] = true;
                }
                int alla = 0;
                foreach (string k in myDict.Keys)
                {
                    if (myDict[k] == true)
                        alla++;
                }
                if (alla == 8 || (alla == 7 && myDict["cid"] == false))
                {
                    NumberOfValidPassports++;
                }

            }
            part1 = NumberOfValidPassports;

            NumberOfValidPassports = 0;
            foreach (string element in listOfValues)
            {
                var e2 = element.Replace("\r\n", " ").Replace("  ", " "); ;
                var l = e2.Split(" ");

                Dictionary<string, bool> myDict = new Dictionary<string, bool>();

                myDict.Add("byr", false);
                myDict.Add("iyr", false);
                myDict.Add("eyr", false);
                myDict.Add("hgt", false);
                myDict.Add("hcl", false);
                myDict.Add("ecl", false);
                myDict.Add("pid", false);
                myDict.Add("cid", false);


                foreach (string part in l)
                {
                    var p = part.Split(":");
                    if (ValidatePassport(p[0], p[1]))
                        myDict[p[0]] = true;
                }
                int alla = 0;
                foreach (string k in myDict.Keys)
                {
                    if (myDict[k] == true)
                        alla++;
                }
                if (alla == 8 || (alla == 7 && myDict["cid"] == false))
                {
                    NumberOfValidPassports++;
                }

            }
            part2 = NumberOfValidPassports;
            WriteResult(4, part1, part2, result.gold);
        }

        private bool ValidatePassport(string key, string value)
        {
            var rval = false;
            if (key == "byr")
            {
                int y = Int32.Parse(value);
                if (y >= 1920 && y <= 2002)
                {
                    rval = true;
                }
            }
            else if (key == "iyr")
            {
                int y = Int32.Parse(value);
                if (y >= 2010 && y <= 2020)
                {
                    rval = true;
                }
            }
            else if (key == "eyr")
            {
                int y = Int32.Parse(value);
                if (y >= 2020 && y <= 2030)
                {
                    rval = true;
                }
            }
            else if (key == "hgt")
            {
                if (value.Contains("cm"))
                {
                    string s = value.Replace("cm", "");
                    int y = Int32.Parse(s);
                    if (y >= 150 && y <= 193)
                    {
                        rval = true;
                    }
                }
                else if (value.Contains("in"))
                {
                    string s = value.Replace("in", "");
                    int y = Int32.Parse(s);
                    if (y >= 59 && y <= 76)
                    {
                        rval = true;
                    }
                }

            }
            else if (key == "hcl")
            {
                if (value.Length == 7 && value[0] == '#')
                {
                    string x = value.Replace("#", "");
                    Regex reg = new Regex(("^[a-f0-9]+$"));
                    if (x.Length == 6 && reg.Match(x).Success)
                        rval = true;
                }
            }
            else if (key == "pid")
            {
                Regex reg = new Regex((@"[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]"));

                if (value.Length == 9 && reg.Match(value).Success)
                    rval = true;

            }
            else if (key == "ecl")
            {
                if (value == "amb" || value == "blu" || value == "brn" || value == "gry" || value == "grn" || value == "hzl" || value == "oth")
                {
                    rval = true;
                }

            }
            return rval;
        }

    }
}
