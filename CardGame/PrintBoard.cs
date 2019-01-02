using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class PrintBoard
    {
        internal static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.White;
    
            Console.WriteLine();
            Console.WriteLine("       BBBB    L              A           CCCCC  K             J        A           CCCCC  K     ");
            Console.WriteLine("       B   B   L             A A        CC       K   K         J       A A        CC       K   K ");
            Console.WriteLine("       B   B   L            A   A      C         K  K          J      A   A      C         K  K  ");
            Console.WriteLine("       BBBBB   L           AAAAAAA     C         KKK           J     AAAAAAA     C         KKK   ");
            Console.WriteLine("       B    B  L          A       A    C         K  K          J    A       A    C         K  K  ");
            Console.WriteLine("       B    B  L         A         A    CC       K   K    J   J    A         A    CC       K   K ");
            Console.WriteLine("       BBBBB   LLLLLLL  A           A     CCCCC  K    K    JJJ    A           A     CCCCC  K    K");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        internal static void AskForBets()
        {
            Console.Clear();
            Intro();
            Console.WriteLine("$$$$$ Players please enter your bets. $$$$$");
            Console.WriteLine("-------------------------------------------");
        }

        internal static void ShowCardsFirstTime(List<Player> players)
        {
            Console.Clear();
            Intro();
            foreach (var player in players)
            {
                if(player.PlayerName != "Dealer")
                {
                    Console.Write($"{player.PlayerName} has bet ${player.playerBet}, {player.PlayerName} cards are: ");
                    for (int i = 0; i < player.PlayerCards.Count; i++)
                    {
                        if(player.PlayerCards[i].Suite == Suites.Diamond || player.PlayerCards[i].Suite == Suites.Hearts)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }

                        Console.Write($"{player.PlayerCards[i].Symbol} ");
                        Console.Write($"{player.PlayerCards[i].Value} ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.WriteLine($"{player.PlayerName} card is {player.PlayerCards[0].Symbol} {player.PlayerCards[0].Value}");
                }
                Console.WriteLine();
            }
        }

        internal static void ShowAllPlayersCards(List<Player> players)
        {
            Console.Clear();
            Intro();
            foreach (var player in players)
            {
                Console.WriteLine($"{player.PlayerName} cards: ");
                for (int i = 0; i < player.PlayerCards.Count; i++)
                {
                    if (player.PlayerCards[i].Suite == Suites.Diamond || player.PlayerCards[i].Suite == Suites.Hearts)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($"{player.PlayerCards[i].Symbol} ");
                    Console.Write($"{player.PlayerCards[i].Value} ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write($"{player.CardPoints}");
                Console.WriteLine();
            }
        }
    }
}
