using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class CardDeck
    {
        public Cards[] PlayDeck { get; set; }

        public CardDeck()
        {
            PlayDeck = new Cards[52];

            for (int i = 1; i <= 52; i++)
            {
                PlayDeck[i-1]=(Cards)i;
            }   
        }

        internal List<Cards> Shuffel(CardDeck deck)
        {
            List<int> randomList = new List<int>();
            int count = 0;

             while (true)
            {
                Random random = new Random();
                int randomCard = random.Next(52);

                if(!randomList.Exists(x => x.Equals(randomCard)))
                {
                    randomList.Add(randomCard);
                }
                else
                {
                    count++;
                }

                if (randomList.Count == 52)
                    break;
                
            }

            var shuffeledDeck = randomList.Select(x => deck.PlayDeck[x]).ToList();

            return shuffeledDeck;
        }
    }
}
