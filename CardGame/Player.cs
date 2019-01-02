using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Player
    {
        private string v;

        public string PlayerName { get; set; }
        public int PlayerMoney { get; set; }
        public int playerBet { get; set; }
        public List<Card> PlayerCards  { get; set; }
        public int CardPoints { get; set; }
        public bool Satisfied { get; set; }

        public Player(string name, int totalMoney)
        {
            PlayerName = name;
            PlayerMoney = totalMoney;
            Satisfied = false;
        }

        public Player(string dealer)
        {
            PlayerName = dealer;
        }
    }
}
