using System;
using System.Collections.Generic;
using System.Linq;


namespace CardGame
{
    internal class BlackJack
    {
        public int Game { get; set; }

        public BlackJack()
        {
            Game = 1;
        }

        internal (List<Card> playersCard, List<Card> ShuffelCards) DealCards(List<Card> shuffeledCards, int cardToDeal)
        {
            List<Card> playerCards = new List<Card>();

            for (int i = 0; i < cardToDeal ; i++)
            {
                playerCards.Add(shuffeledCards[0]);
                shuffeledCards.Remove(shuffeledCards[0]);
            }

            return (playerCards, shuffeledCards);
        }

        internal static void CheckIfPlayerHasMoney(List<Player> players, int lowestBet)
        {
            foreach (var player in players)
            {
                if(player.PlayerName != "Dealer")
                {
                    if(player.PlayerMoney > lowestBet)
                    {
                        while (true)
                        {
                            Console.Write($"{player.PlayerName} do you want to play again (y or n)?: ");
                            string answer = Console.ReadLine();
                            if (answer.ToLower() == "y")
                            {
                                player.Satisfied = false;
                                break;
                            }
                            else if (answer.ToLower() == "n")
                            {
                                player.Satisfied = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You didn´t anser y for yes or n for no. Please try agin.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{player.PlayerName} you don´t have any money left. You can´t play anymore.");   
                    }
                }
            }
        }

        internal void CalculateDeals(List<Player> players)
        {

            foreach (var player in players)
            {
                int numberOfAce = 0;

                foreach (var card in player.PlayerCards)
                {
                    if(card.Value == Values.Ace)
                    {
                        numberOfAce++;
                    }
                }

                if(numberOfAce == 0)
                {
                    int cardPointsNoAce = player.PlayerCards.Select((x, i) => x.Value == Values.Knight ? x.Number = 10 : x.Value == Values.Quene ? x.Number = 10 : x.Value == Values.King ? x.Number = 10 : x.Value == Values.Ten ? x.Number = 10 : x.Value == Values.Nine ? x.Number = 9 : x.Value == Values.Eight ? x.Number = 8 : x.Value == Values.Seven ? x.Number = 7 : x.Value == Values.Six ? x.Number = 6 : x.Value == Values.Five ? x.Number = 5 : x.Value == Values.Four ? x.Number = 4 : x.Value == Values.Three ? x.Number = 3 : x.Number = 2).Sum();
                    player.CardPoints = cardPointsNoAce;
                }
                else
                {
                    int cardPointsAceEleven = player.PlayerCards.Select((x, i) => x.Value == Values.Ace ? x.Number = 11 : x.Value == Values.Knight ? x.Number = 10 : x.Value == Values.Quene ? x.Number = 10 : x.Value == Values.King ? x.Number = 10 : x.Value == Values.Ten ? x.Number = 10 : x.Value == Values.Nine ? x.Number = 9 : x.Value == Values.Eight ? x.Number = 8 : x.Value == Values.Seven ? x.Number = 7 : x.Value == Values.Six ? x.Number = 6 : x.Value == Values.Five ? x.Number = 5 : x.Value == Values.Four ? x.Number = 4 : x.Value == Values.Three ? x.Number = 3 : x.Number = 2).Sum();
                    int cardPointsAceOne = player.PlayerCards.Select((x, i) => x.Value == Values.Ace ? x.Number = 1 : x.Value == Values.Knight ? x.Number = 10 : x.Value == Values.Quene ? x.Number = 10 : x.Value == Values.King ? x.Number = 10 : x.Value == Values.Ten ? x.Number = 10 : x.Value == Values.Nine ? x.Number = 9 : x.Value == Values.Eight ? x.Number = 8 : x.Value == Values.Seven ? x.Number = 7 : x.Value == Values.Six ? x.Number = 6 : x.Value == Values.Five ? x.Number = 5 : x.Value == Values.Four ? x.Number = 4 : x.Value == Values.Three ? x.Number = 3 : x.Number = 2).Sum();
                    player.CardPoints = cardPointsAceEleven < 22 ? cardPointsAceEleven : cardPointsAceOne;
                }
            }
        }

        internal void PlaceBet(List<Player> players, int lowestBet, int highestBet)
        {
            foreach (var player in players)
            {
                if(player.PlayerName != "Dealer")
                {
                    while (true)
                    {
                        Console.WriteLine("");
                        Console.Write($"{player.PlayerName} please place your bet: ");
                        bool playerBetOK = int.TryParse(Console.ReadLine(), out int playerBet);

                        if(playerBet < lowestBet || playerBet > highestBet)
                            Console.WriteLine($"Bet is not allowed. It must be between {lowestBet}$ and {highestBet}$. Please make a new bet.");
                        else if (playerBet > player.PlayerMoney)
                            Console.WriteLine($"Sorry {player.PlayerName} you only have ${player.PlayerMoney} left. Please make a new bet.");
                        else if (playerBetOK == false)
                            Console.WriteLine("Please enter your bet again.");
                        else
                        {
                            player.playerBet = playerBet;
                            player.PlayerMoney = player.PlayerMoney - playerBet;
                            break;
                        }
                    }
                }
            }
        }

        internal void PayOrTakeMoney(List<Player> players)
        {
            Console.WriteLine();
            for (int i = 0; i < players.Count - 1; i++)
            {
                Player player = players[i];
                if (player.CardPoints > 21)
                {
                    Console.WriteLine($"Sorry you have over 21, you have lost, Dealer wins.");
                    Console.WriteLine($"{player.PlayerName} you lost ${player.playerBet}, you now have ${player.PlayerMoney}.");
                }

                else if (player.CardPoints == 21 || players[players.Count - 1].CardPoints > 21)
                {
                    Console.WriteLine($"{player.PlayerName} you played your cards well!");
                    player.PlayerMoney = player.PlayerMoney + player.playerBet * 2;
                    Console.WriteLine($"{player.PlayerName} you won ${player.playerBet * 2}, you now have ${player.PlayerMoney}.");
                    Console.WriteLine();
                }

                else if (player.CardPoints < 21 && players[players.Count - 1].CardPoints <= player.CardPoints)
                {
                    Console.WriteLine($"{player.PlayerName} you played your cards well!");
                    player.PlayerMoney = player.PlayerMoney + player.playerBet * 2;
                    Console.WriteLine($"{player.PlayerName} you won ${player.playerBet * 2}, you now have ${player.PlayerMoney}.");
                    Console.WriteLine();
                }

                else if (player.CardPoints < players[players.Count - 1].CardPoints && players[players.Count - 1].CardPoints <= 21)
                {
                    Console.WriteLine($"Sorry {player.PlayerName}, {players[players.Count - 1].PlayerName} wins");
                    Console.WriteLine($"{player.PlayerName} you lost ${player.playerBet}, you now have ${player.PlayerMoney}.");
                    Console.WriteLine();
                }
            }
        }

        internal void DealersCards(List<Player> players, List<Card> shuffeledCards)
        {
            foreach (var player in players)
            {
                if(player.PlayerName == "Dealer")
                {
                    while (true)
                    {
                        if(player.CardPoints <= 16)
                        {
                            var (playerCards, newShuffelCards) = DealCards(shuffeledCards, 1);
                            player.PlayerCards.Add(playerCards[0]);
                            shuffeledCards = newShuffelCards;
                            CalculateDeals(players);
                            if (player.CardPoints > 16)
                                break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        internal void GetNextCard(List<Player> players, List<Card> shuffeledCards)
        {
            
            foreach (var player in players)
            {
                if(player.PlayerName != "Dealer")
                {
                    while (true)
                    {
                        string getCard = "";
                        if(player.CardPoints < 21 && player.Satisfied == false)
                        {
                            while (true)
                            {
                                Console.Write($"{player.PlayerName} do you want one more card or do you stay ((p)lay/(s)tay)?: ");
                                getCard = Console.ReadLine();

                                if (getCard.ToLower() == "p")
                                {
                                    var (playerCards, newShuffelCards) = DealCards(shuffeledCards, 1);
                                    player.PlayerCards.Add(playerCards[0]);
                                    shuffeledCards = newShuffelCards;
                                    CalculateDeals(players);
                                    PrintBoard.ShowCardsFirstTime(players);
                                    break;
                                }
                                else if (getCard.ToLower() == "s")
                                {
                                    PrintBoard.ShowCardsFirstTime(players);
                                    player.Satisfied = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter 'p' for one more card or 's' to stay.");
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    } 
                }
            }
        }
    }
}