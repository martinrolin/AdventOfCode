using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021
{  
    class Day04 : Helper
    {
        

        private class Tile
        {
            public int value { get; set; }
            public bool marked { get; set; }

            public Tile(int value)
            {
                this.value = value;
                this.marked = false;
            }
        }

        private void PrintBoard(Tile[,] board)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i,j].marked)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(board[i, j].value.ToString().PadLeft(3));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private bool HasBingo(Tile[,] board) 
        {
            for (int i = 0; i < 5; i++)
            {
                bool rowBingo = true;
                bool columnBingo = true;
                for (int j = 0; j < 5; j++)
                {
                    rowBingo = rowBingo && board[i, j].marked;
                    columnBingo = columnBingo && board[j, i].marked;
                }
                if (rowBingo || columnBingo)
                    return true;
            }
            return false;
        }

        private void Mark(List<Tile[,]> boards, int number)
        {
            foreach (var board in boards)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (board[i, j].value == number)
                            board[i, j].marked = true;
                    }
                }
            }
        }

        private int SumOfUnmarkedNumbers(Tile[,] board)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!board[i, j].marked)
                        sum += board[i, j].value;
                }                
            }
            return sum;
        }

        public void Solve()
        {
            int part1 = 0;
            int part2 = 0;
            string allText = File.ReadAllText("Input\\2021\\day04.txt");
            var listOfValues = allText.Split("\r\n").ToList();

            var listOfNumbers = Array.ConvertAll(listOfValues[0].Split(","), s => int.Parse(s));
            var listOfBoards = new List<Tile[,]>();


            for (int i = 2; i < listOfValues.Count; i+=6)
            {
                Tile[,] board = new Tile[5, 5];
                for (int j = 0; j < 5; j++)
                {
                    var row = listOfValues[i + j].Trim(' ').Replace("  ", " ").Split(" ");
                    for (int k = 0; k < 5; k++)
                    {
                        board[j, k] = new Tile(Int32.Parse(row[k]));
                    }
                   
                }
                listOfBoards.Add(board);
                
            }
            List<int> winningBoards = new List<int>();

            foreach (var number in listOfNumbers)
            {
                Mark(listOfBoards, number);
                for (int i=0;i<listOfBoards.Count;i++)
                {
                    var board = listOfBoards[i];
                    if (HasBingo(board) && part1 == 0)
                    {
                        part1 = number * SumOfUnmarkedNumbers(board);
                        if (!winningBoards.Contains(i))
                            winningBoards.Add(i);

                    }
                    else if (HasBingo(board)) 
                    {
                        if (!winningBoards.Contains(i))
                            winningBoards.Add(i);
                        if (listOfBoards.Count == winningBoards.Count && part2 == 0)
                            part2 = number * SumOfUnmarkedNumbers(board);
                    }
                }                
            
            }
            WriteResult(4, part1, part2, Result.twoStars);
        }
    }
}




