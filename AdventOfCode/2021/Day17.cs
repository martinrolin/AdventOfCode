using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
	class Day17 : Helper
	{

        private (bool,int) FireProbe(int initialDx, int initialDy, int minX, int maxX, int minY, int MaxY)
        {
            int x = 0, y = 0;
            int dx = initialDx;
            int dy = initialDy;
            int highest = 0;

            while (x <= maxX && y >= MaxY)
            {
                x += dx;
                if (dx > 0)
                    --dx;
                y += dy--;

                if (y > highest)
                    highest = y;

                if (x >= minX && x <= maxX && y <= minY && y >= MaxY)
                    return (true, highest);
            }

            return (false,0);
        }

        private int MinStartX(int leftBound)
        {
            int n = 0;
            for (; n * (n + 1) < 2 * leftBound; n++)
                ;
            return n;
        }

        public void Solve()
		{
			int part1 = 0;
			long part2 = 0;
			string allText = File.ReadAllText("Input\\2021\\day17.txt");
            allText = allText.Replace("target area: x=", "").Replace(", y=", "..");



          

        var data = Array.ConvertAll(allText.Split(".."), s => Int32.Parse(s));


            int minX = data[0];
            int maxX = data[1];
            int minY = data[3];
            int maxY = data[2];

            int startX = MinStartX(minX);
            //startX = 0;
            for (int x = startX; x <= maxX; x++)
            {
                for (int y = maxY; y < -maxY; y++)
                //for (int y = -10000; y < 10000; y++)
                {
                    bool hit;
                    int height;
                    (hit, height) = FireProbe(x, y, minX, maxX, minY, maxY);
                    if (hit)
                    {
                        if (height > part1)
                            part1 = height;
                        ++part2;
                    }
                }
            }


            WriteResult(17, part1, part2, Result.twoStars);
        }
    }
}












