using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Table
    {
        List<Player> players = new List<Player>();
        public List<Player> Players { get { return players; } }
        // who moves = Player[whoMoves], who is under move = Player[whoMoves] + 1
        int whoMoves;
        public int WhoMoves { get { return whoMoves; } }
        

        private BattleCards battle;
        public BattleCards Battle { get { return battle; } }
        private Deck deck;
        public Deck Deck { get { return deck; } }
        private Card_Suits trump; // Козырь
        public Card_Suits Trump { get { return trump; } }

        double Move = 0; //TODO: Check for max moves

        public Table(List<Player> players, int maxBattleCardsNum)
        {
            whoMoves = 0;
            deck = new Deck();
            this.players = players;
            trump = (Card_Suits)(new Random().Next(0, 4));
            battle = new BattleCards(maxBattleCardsNum, trump);
        }
    }
}
