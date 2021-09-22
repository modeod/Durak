using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    enum Card_Type { Six = 6, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

    enum Card_Suits
    {
            Hearts,
            Clubs,
            Diamonds,
            Spades
    }
    
    class Card
    {
        private Card_Suits suit;
        public Card_Suits Suit { get { return suit; } }

        private Card_Type type;
        public Card_Type Type { get { return type; } }

        public Card(Card_Suits suit, Card_Type type)
        {
            this.suit = suit;
            this.type = type;
        }
    }
}
