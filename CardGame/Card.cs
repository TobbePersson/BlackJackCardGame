using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Card
    {
        public Suites Suite { get; set; }
        public Values Value { get; set; }
        public int Number { get; set; }
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public bool ShowCard { get; set; }

        public Card(Suites suites, Values values)
        {
            Suite = suites;
            Value = values;

            switch (suites)
            {
                case Suites.Hearts:
                    Symbol = "♥";
                    Color = ConsoleColor.Red;
                    break;
                case Suites.Diamond:
                    Symbol = "♦";
                    Color = ConsoleColor.Red;
                    break;
                case Suites.Clubs:
                    Symbol = "♣";
                    Color = ConsoleColor.White;
                    break;
                case Suites.Spades:
                    Symbol = "♠";
                    Color = ConsoleColor.White;
                    break;
                default:
                    break;
            }
        }
    }
}
