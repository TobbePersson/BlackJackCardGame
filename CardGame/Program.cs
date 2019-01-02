using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Title = "Balck Jack";

            PrintBoard.Intro();

            var (players, lowestBet, highestBet) = GetPlayers();

            while (true)
            {
                try
                {
                    List<Card> shuffeledDeckList = StartGame();

                    PlayGame(shuffeledDeckList, players, lowestBet, highestBet);

                    BlackJack.CheckIfPlayerHasMoney(players, lowestBet);

                    if (players.Where(x => x.Satisfied == false).Count() < 2)
                        break;
                }
                catch(ArgumentException exp)
                {
                    Console.WriteLine($"Ooops... Something went wrong.");
                }
                catch
                {
                    Console.WriteLine("Something went wrong, Please try again.");
                }
            }

            EndGame();  
        }

        private static (List<Player> players, int lowestBet, int highestBet) GetPlayers()
        {
            int numberOfPlayers;
            List<Player> players = new List<Player>();
            int lowestBet = 0;
            int highestBet = 0;
            int totalMoney = 0;

            Console.WriteLine("Game setup");
            Console.WriteLine("----------");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Enter total amount of money: ");
                bool totalMoneyOK = int.TryParse(Console.ReadLine(), out totalMoney);
                if(totalMoneyOK == false)
                    Console.WriteLine("Please enter a real number for total amount of money.");
                else
                    break;
            }

            while (true)
            {
                Console.Write("Enter lowest bet: ");
                bool lowestOK = int.TryParse(Console.ReadLine(), out lowestBet);
                if (lowestOK == false)
                    Console.WriteLine("Please enter a real number for lowest bet.");
                else
                    break;
            }

            while (true)
            {
                Console.Write("Enter highest bet: ");
                bool highestOK = int.TryParse(Console.ReadLine(), out highestBet);
                if (highestOK == false)
                    Console.WriteLine("Please enter a real number for highest bet.");
                else
                    break;
            }

            while (true)
            {
                Console.Write("Enter number of players: ");
                bool numberOfPlayersOK = int.TryParse(Console.ReadLine(), out numberOfPlayers);
                if (numberOfPlayersOK == false)
                    Console.WriteLine("Please enter a real number for number of players.");
                else
                    break;
            }
            
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write($"Enter name of player {i + 1}: ");
                string name = Console.ReadLine();
                players.Add(new Player(name, totalMoney));
            }

            players.Add(new Player("Dealer"));

            return (players, lowestBet, highestBet);
        }

        private static List<Card> StartGame()
        {

            Deck deckInList = new Deck();

            var shuffeledDeckList = deckInList.Shuffel(deckInList);

            return shuffeledDeckList;
  
        }

        private static void PlayGame(List<Card> shuffeledDeck, List<Player> players, int lowestBet, int highestBet)
        {
            BlackJack game = new BlackJack();

            PrintBoard.AskForBets();

            game.PlaceBet(players, lowestBet, highestBet);

            foreach (var player in players)
            {
                var (playersCard, ShuffelCards) = game.DealCards(shuffeledDeck, 2);
                player.PlayerCards = playersCard;
                shuffeledDeck = ShuffelCards;
            }

            PrintBoard.ShowCardsFirstTime(players);

            game.CalculateDeals(players);
            
            game.GetNextCard(players, shuffeledDeck);

            game.CalculateDeals(players);

            game.DealersCards(players, shuffeledDeck);

            PrintBoard.ShowAllPlayersCards(players);

            game.PayOrTakeMoney(players);

        }

        private static void EndGame()
        {
            
        }
    }
}
