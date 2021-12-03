using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day03 : Helper
    {


        private List<string> Filter(List<string> input, int position, bool oxygen) 
        {
            int count = 0;
            var listOne = new List<string>();
            var listZero = new List<string>();
            if (input.Count == 1)
                return input;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i][position] == '1')
                {
                    count++;
                    listOne.Add(input[i]);
                }
                else
                    listZero.Add(input[i]);
            }

            if (oxygen)
            {
                if (count >= input.Count - count)
                    return listOne;
                else
                    return listZero;
            }
            else 
            {
                if (count >= input.Count - count)
                    return listZero;
                else
                    return listOne;
            }               
        }
        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day03.txt");
            var listOfValues = allText.Split("\r\n").ToList();
            var oxygenList = allText.Split("\r\n").ToList();
            var co2ScrubberList = allText.Split("\r\n").ToList();
            var data = new int[listOfValues[0].Length];
            for (int i = 0; i < listOfValues.Count; i++)
            {
                for (int j = 0; j < listOfValues[i].Length; j++)
                {
                    if (listOfValues[i][j] == '1')
                    {
                        data[j]++;
                    }
                    
                }
            }
            for (int j = 0; j < listOfValues[0].Length; j++)
            {
                if (data[j] > listOfValues.Count / 2)
                    data[j] = 1;
                else 
                    data[j] = 0;
            }

            int gamma = 0;
            int epsilon = 0;         
            for (int j = 0; j < listOfValues[0].Length; j++)
            {
                if (data[j] == 1)
                    gamma += (int)Math.Pow(2, data.Length - j - 1);
                else
                    epsilon += (int)Math.Pow(2, data.Length - j - 1);
            }
            
            part1 = gamma * epsilon;

            for (int i = 0; i < listOfValues[0].Length; i++)
            {
                oxygenList = Filter(oxygenList, i, true);
                co2ScrubberList = Filter(co2ScrubberList, i, false);         
            }
            part2 = Convert.ToInt32(oxygenList.FirstOrDefault(), 2) * Convert.ToInt32(co2ScrubberList.FirstOrDefault(), 2);
            
            WriteResult(3, part1, part2, result.gold);
        }
    }
}




