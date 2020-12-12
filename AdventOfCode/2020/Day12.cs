using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day12 : Helper
    {
        private enum Direction
        {
            east,
            south,
            west,
            north
        }

        private int x = 0;
        private int y = 0;
        private int waypointX = 10;
        private int waypointY = 1;
        private Direction direction = Direction.east;
        public void Solve()
        {
            int part1 = 0;
            long part2 = 0;
            string allText = File.ReadAllText("input\\2020_day12.txt");
            var lines = allText.Split("\r\n").ToList();

            // Part 1
           
            foreach (var line in lines)
            {
                if (line[0] == 'N') {
                    y += Int32.Parse(line.Substring(1));
                } 
                else if (line[0] == 'S')
                {
                    y -= Int32.Parse(line.Substring(1));
                } 
                else if (line[0] == 'E')
                {
                    x += Int32.Parse(line.Substring(1));
                } 
                else if (line[0] == 'W')
                {
                    x -= Int32.Parse(line.Substring(1));
                } 
                else if (line[0] == 'F') {
                    Move(Int32.Parse(line.Substring(1)));
                }
                else if (line[0] == 'L')
                {
                    direction -= Int32.Parse(line.Substring(1)) / 90;

                    if (direction < 0)
                        direction += 4;
                    else if (direction > Direction.north)
                        direction -= 4;                                           
                }
                else if (line[0] == 'R')
                {
                    direction += Int32.Parse(line.Substring(1)) / 90;

                    if (direction < 0)
                        direction += 4;
                    else if (direction > Direction.north)
                        direction -= 4;
                }                
            }







































            part1 = Math.Abs(x) + Math.Abs(y);

            // Part 2
            x = 0;
            y = 0;

            foreach (var line in lines)
            {
                if (line[0] == 'N')
                {
                    waypointY += Int32.Parse(line.Substring(1));
                }
                else if (line[0] == 'S')
                {
                    waypointY -= Int32.Parse(line.Substring(1));
                }
                else if (line[0] == 'E')
                {
                    waypointX += Int32.Parse(line.Substring(1));
                }
                else if (line[0] == 'W')
                {
                    waypointX -= Int32.Parse(line.Substring(1));
                }
                else if (line[0] == 'F')
                {
                    MoveTowardsWaypoint(Int32.Parse(line.Substring(1)));
                }
                else if (line[0] == 'L')
                {
                    for (int i = 0; i < Int32.Parse(line.Substring(1)) / 90; i++) 
                    {
                        RotateWayPoint(true);
                    }
                }
                else if (line[0] == 'R')
                {
                    for (int i = 0; i < Int32.Parse(line.Substring(1)) / 90; i++)
                    {
                        RotateWayPoint(false);
                    }
                }
            }
            part2 = Math.Abs(x) + Math.Abs(y);


            WriteResult(12, part1, part2, result.silver);
        }

        private void RotateWayPoint(bool left) {
            if (left)
            {
                var PreviousWaypointY = waypointY;

                waypointY = waypointX;
                waypointX = -PreviousWaypointY;
            }   
            else {
                var PreviousWaypointX = waypointX;

                waypointX = waypointY;
                waypointY = -PreviousWaypointX;
            }
        }

        private void Move(int length) {
            if (direction == Direction.east) {
                x += length;
            } else if (direction == Direction.south)
            {
                y -= length;
            } else if (direction == Direction.west)
            {
                x -= length;
            } else if (direction == Direction.north)
            {
                y += length;
            }
        }

        private void MoveTowardsWaypoint(int length)
        {
            x += waypointX * length;
            y += waypointY * length;
        }
    }
}
