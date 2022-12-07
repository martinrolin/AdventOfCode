using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2022
{
    class Day07 : Helper
    {
        private long part1 = 0;
        private List<Folder> folders = new List<Folder>();
        private class File
        {
            public string Name { get; set; }
            public long Size { get; set; }
            public File(string Name, long Size)
            {
                this.Name = Name;
                this.Size = Size;
            }
        }

        private class Folder
        {
            public string Name { get; set; }
            public List<Folder> Folders { get; set; }
            public List<File> Files { get; set; }
            public long Size { get; set; }
            public Folder Parent { get; set; }

            public Folder(string Name, Folder Parent)
            {
                this.Name = Name;
                this.Folders = new List<Folder>();
                this.Files = new List<File>();
                this.Size = 0;
                this.Parent= Parent;
            }

        }

        private long CalculateSum(Folder folder)
        {
            long sum = 0;
            folders.Add(folder);
            foreach (var f in folder.Folders)
            {
                sum += CalculateSum(f);
            }
            foreach (var file in folder.Files)  
            {
                sum += file.Size;
            }

            folder.Size = sum;
            return sum;

        }

        private void PrintFolder(Folder folder, int depth) {
            for (int i = 0; i < depth; i++)
            {
                Console.Write("  ");
            }
            Console.WriteLine("- " + folder.Name + " (dir) " + folder.Size);
            foreach (var f in folder.Folders)
            {
                PrintFolder(f, depth + 1);
            }
            foreach (var f in folder.Files)
            {
                for (int i = 0; i < depth + 1; i++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine("- " + f.Name + " (file) " + f.Size.ToString());
            }
            
        }

        private void Part1(Folder folder)
        {
            if (folder.Size < 100000)
                part1 += folder.Size;
            foreach (var f in folder.Folders)
            {
               Part1(f);
            }
        }

        public void Solve()
        {
            
            long part2 = 0;
            string allText = System.IO.File.ReadAllText("Input\\2022\\day07.txt");
            var lines = allText.Split("\r\n").ToList();

            var root = new Folder("/",null);

            var currentFolder = root;
            int i = 0;
            while (i < lines.Count)
            {
                if (lines[i].StartsWith("$ cd"))
                {
                    string f = lines[i].Replace("$ cd ", "");
                    if (f == "/")
                        currentFolder = root;
                    else if (f == "..")
                        currentFolder = currentFolder.Parent;
                    else {
                        currentFolder = currentFolder.Folders.Where(x => x.Name == f).FirstOrDefault();                        
                    }
                }
                else if (!lines[i].StartsWith("$ ls")) 
                {
                    var data = lines[i].Split(" ");
                    if (lines[i].StartsWith("dir"))
                    {
                        if (currentFolder.Folders.Where(x => x.Name == data[1]).Count() == 0)
                            currentFolder.Folders.Add(new Folder(data[1], currentFolder));
                    }
                    else
                    {
                        if (currentFolder.Files.Where(x => x.Name == data[1]).Count() == 0)
                            currentFolder.Files.Add(new File(data[1], int.Parse(data[0])));
                    }
                }
                i++;

            }
            CalculateSum(root);
            //PrintFolder(root,0);
            Part1(root);

            long toFree = 30000000-(70000000 - root.Size);
           
            part2 = long.MaxValue;
            foreach (var f in folders)
            {
                if (f.Size >= toFree)
                    part2 = Math.Min(part2, f.Size);
            }

            WriteResult(7, part1, part2, Result.gold);
        }
    }
}




