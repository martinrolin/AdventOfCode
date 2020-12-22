using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day22 : Helper
    {
        private List<Queue<int>> playersStartSetup = new List<Queue<int>>();
        private long part2 = 0;        

        public void Solve()
        {
            long part1 = 0;
            string allText = File.ReadAllText("Input\\2020\\day22.txt");
            var lines = allText.Split("\r\n").ToList();
            foreach (var line in lines)
            {
                if (line.Length > 0 && line[0] == 'P')
                {
                    playersStartSetup.Add(new Queue<int>());
                }
                else if (line != "")
                {
                    playersStartSetup.Last().Enqueue(Int32.Parse(line));
                }
            }

            part1 = PlayCombat(new Queue<int>(playersStartSetup[0]), new Queue<int>(playersStartSetup[1]));            
            PlayRecursionCombat(1, new Queue<int>(playersStartSetup[0]), new Queue<int>(playersStartSetup[1]));
          
            WriteResult(22, part1, part2, result.gold);
        }

        private int PlayRecursionCombat(int game, Queue<int> player1, Queue<int> player2)
        {
            HashSet<string> states = new HashSet<string>();
            while (true)
            {
                string state = string.Join(",", player1) + "|" + string.Join(",", player2);
                if (states.Contains(state))
                    return 1;

                states.Add(state);

                var player1Card = player1.Dequeue();
                var player2Card = player2.Dequeue();

                int winner;

                if (player1.Count >= player1Card && player2.Count >= player2Card)
                {
                    Queue<int> player1Next = new Queue<int>(player1.Reverse());
                    int n1 = player1Next.Count();
                    for (int i = 0; i < n1 - player1Card; i++)
                        player1Next.Dequeue();
                    player1Next = new Queue<int>(player1Next.Reverse());

                    Queue<int> player2Next = new Queue<int>(player2.Reverse());
                    int n2 = player2Next.Count();
                    for (int i = 0; i < n2 - player2Card; i++)
                        player2Next.Dequeue();
                    player2Next = new Queue<int>(player2Next.Reverse());

                    winner = PlayRecursionCombat(game + 1, player1Next, player2Next);
                }
                else {
                    winner = player1Card > player2Card ? 1 : 2;
                }
                
                if (winner == 1)
                {
                    player1.Enqueue(player1Card);
                    player1.Enqueue(player2Card);
                }
                else 
                {
                    player2.Enqueue(player2Card);
                    player2.Enqueue(player1Card);
                }

                if (player1.Count == 0)
                {
                    if (game == 1)
                        part2 = CountScore(player2);
                    return 2;
                }
                else if (player2.Count == 0)
                {
                    if (game == 1)
                        part2 = CountScore(player1);

                    return 1;
                }
            }
        }

        private long PlayCombat(Queue<int> player1, Queue<int> player2)
        {
            while (player1.Count > 0 && player2.Count > 0)
            {
                
                if (player1.Peek() == player2.Peek()) {
                    player1.Enqueue(player1.Dequeue());
                    player2.Enqueue(player2.Dequeue());
                }
                else if (player1.Peek() > player2.Peek())
                { 
                    player1.Enqueue(player1.Dequeue());
                    player1.Enqueue(player2.Dequeue());
                }
                else if (player2.Peek() > player1.Peek())
                {
                    player2.Enqueue(player2.Dequeue());
                    player2.Enqueue(player1.Dequeue());
                }
                
            }
            if (player1.Count > 0)
                return CountScore(player1);
            else
                return CountScore(player2);
        }

        private long CountScore(Queue<int> winner)
        {
            long score = 0;            
            while (winner.Count() > 0)
            {
                score += winner.Count * winner.Dequeue();
            }

            return score;
        }
    }
}
