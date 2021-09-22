using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Table
    {
        //First - who moves, Second - who is under move
        List<Player> Players = new List<Player>();

        public BattleCards battle;
        public Deck deck;

        private Card_Suits trump; // Козырь
        public Card_Suits Trump { get { return trump; } }

        double Move = 0;

        public Table(List<Player> players)
        {
            deck = new Deck();
        }
    }
}
