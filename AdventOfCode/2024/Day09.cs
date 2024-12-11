using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode._2024
{

    class Day09 : Helper
    {

      
        public void Solve()
        {
            long part1 = 0;
            long part2 = 0;
            string input = File.ReadAllText("Input\\2024\\day09.txt");

            List<int> disk = new List<int>();
            int fid = 0;

            List<int> empty = new List<int>();

            for (int i = 0;i < input.Length;i++)
            {
                int x = int.Parse(input[i].ToString());
                if (i % 2 == 0)
                {
                    for (int j = 0; j < x; j++)
                    {
                        disk.Add(fid);
                    }
                    fid++;
                }
                else
                {
                    for (int j = 0; j < x; j++)
                    {
                        disk.Add(-1);
                        empty.Add(disk.Count - 1);
                    }
                }

            }

            foreach (var e in empty)
            {
                var moved = false;
                for (int i = disk.Count-1; i > e && !moved; i--)
                {
                    if (disk[i] >= 0)
                    { 
                        disk[e] = disk[i];
                        disk.RemoveAt(i);
                        moved = true;
                    }
                }
            }


            for (int i = 0; i < disk.Count && disk[i] >=0; i++)
            {
                part1 +=  i * disk[i];  
            }

            // Part 2

            var files = new List<(int pos, int len)>();
            var freespace = new List<(int pos, int size)>();
            int p = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int x = int.Parse(input[i].ToString());
                if (i % 2 == 0)
                {
                    files.Add((p, x));
                    fid++;
                }
                else
                {
                    freespace.Add((p,x));
                }
                p += x;
            }

            for (int i = files.Count-1; i >= 0; i--)
            {
                var moved = false;
                for (int j = 0; j < freespace.Count && !moved; j++)
                {
                    if (freespace[j].pos >= files[i].pos)
                        break;

                    if (files[i].len <= freespace[j].size)
                    {
                        files[i] = (freespace[j].pos, files[i].len);

                        if (files[i].len == freespace[j].size)
                            freespace.RemoveAt(j);
                        else
                        {
                            freespace[j] = (freespace[j].pos + files[i].len, freespace[j].size - files[i].len);
                        }
                        moved = true;
                    }
                }
            }
            

            for (int i = 0; i < files.Count; i++)
            {
                for (int j = files[i].pos; j < files[i].pos + files[i].len; j++)
                {
                    part2 += i * j;

                }
            }



            WriteResult(9, part1, part2, Result.twoStars);

            }
        }
    }


