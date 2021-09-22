using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Table
    {
        //First - who moves, Second - who is under move
        List<Player> Players = new List<Player>();

        private BattleCards battle;
        public BattleCards Battle { get { return battle; } }

        private Deck deck;
        public Deck Deck { get { return deck; } }

        private Card_Suits trump; // Козырь
        public Card_Suits Trump { get { return trump; } }

        double Move = 0;

        public Table(List<Player> players, int maxBattleCardsNum)
        {
            deck = new Deck();
            trump = (Card_Suits)(new Random().Next(0, 4));
            battle = new BattleCards(maxBattleCardsNum, trump);
        }
    }
}
