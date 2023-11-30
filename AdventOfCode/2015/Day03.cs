using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2015
{
    class Day03 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("Input\\2015\\day03.txt");
            
            Dictionary<(int, int),bool> houses = new Dictionary<(int, int), bool>();

            houses[(0, 0)] = true;


            int x = 0;
            int y = 0;

            for (int i = 0; i < allText.Length; i++)
            {
                if (allText[i] == '^')
                    y++;
                if (allText[i] == 'v')
                    y--;
                if (allText[i] == '<')
                    x--;
                if (allText[i] == '>')
                    x++;
                houses[(x, y)] = true;
            }

            part1 = houses.Where(x => x.Value == true).Count();


            houses = new Dictionary<(int, int), bool>();

            houses[(0, 0)] = true;


            x = 0;
            y = 0;
            int rx = 0;
            int ry = 0;

            for (int i = 0; i < allText.Length; i+=2)
            {
                if (allText[i] == '^')
                    y++;
                if (allText[i] == 'v')
                    y--;
                if (allText[i] == '<')
                    x--;
                if (allText[i] == '>')
                    x++;
                if (allText[i + 1] == '^')
                    ry++;
                if (allText[i + 1] == 'v')
                    ry--;
                if (allText[i + 1] == '<')
                    rx--;
                if (allText[i + 1] == '>')
                    rx++;
                houses[(x, y)] = true;
                houses[(rx, ry)] = true;
            }

            part2 = houses.Where(x => x.Value == true).Count();


            WriteResult(3, part1, part2, Result.twoStars);

        }

    }
}




