using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Deck
    {
        public List<Card> deck { get; set; }

        public Deck()
        {
            deck = new List<Card>();

            for (int i = 0; i < 4; i++)
            {
                Suites suites = (Suites)i;

                for (int j = 0; j < 13; j++)
                {
                    Values value = (Values)j;
                    Card newCard = new Card(suites, value);
                    deck.Add(newCard);
                }
            }
        }

        internal List<Card> Shuffel(Deck deckInList)
        {
            List<int> randomList = new List<int>();
            int count = 0;

            while (true)
            {
                Random random = new Random();
                int randomCard = random.Next(52);

                if (!randomList.Exists(x => x.Equals(randomCard)))
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

            var shuffeledDeck = randomList.Select(x => deckInList.deck[x]).ToList();

            return shuffeledDeck;
         }
    }
}
