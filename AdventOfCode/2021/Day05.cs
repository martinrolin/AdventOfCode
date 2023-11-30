using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{
    class Day05 : Helper
    {
        private class Point 
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        private class Vector
        {
            public Point start { get; set; }
            public Point end { get; set; }
            public int dx { get; set; }
            public int dy { get; set; }
        }

        private void PrintMap(int[,] map)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.Write(map[x, y].ToString().PadLeft(3));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private int FindOverlaps(List<Vector> vectors, bool includeDiagonal) 
        {
            int overlaps = 0;
            int[,] map = new int[1000, 1000];

            foreach (var vector in vectors)
            {
                if (!includeDiagonal && vector.dx != 0 && vector.dy != 0)
                    continue;

                Point point = new Point();
                point.x = vector.start.x;
                point.y = vector.start.y;
                map[point.x, point.y]++;
                do
                {
                    
                    point.x += vector.dx;
                    point.y += vector.dy;
                    map[point.x, point.y]++;
                }
                while (point.x != vector.end.x || point.y != vector.end.y);

            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (map[i, j] > 1)
                        overlaps++;
                }
            }

            //PrintMap(map);

            return overlaps;
        }


        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day05.txt");
            var lines = allText.Split("\r\n").ToList();

            var vectors = new List<Vector>();
            for (int i = 0; i < lines.Count; i++)
            {
                var data = lines[i].Split(" -> ");
                var vector = new Vector();
                vector.start = new Point();
                vector.start.x = Int32.Parse(data[0].Split(",")[0]);
                vector.start.y = Int32.Parse(data[0].Split(",")[1]);
                vector.end = new Point();
                vector.end.x = Int32.Parse(data[1].Split(",")[0]);
                vector.end.y = Int32.Parse(data[1].Split(",")[1]);
                vector.dx = vector.end.x > vector.start.x ? 1 : vector.end.x < vector.start.x ? -1 : 0;
                vector.dy = vector.end.y > vector.start.y ? 1 : vector.end.y < vector.start.y ? -1 : 0;

                vectors.Add(vector);
            }

            part1 = FindOverlaps(vectors, false);
            part2 = FindOverlaps(vectors, true);


            WriteResult(5, part1, part2, Result.twoStars);
        }
    }
}




