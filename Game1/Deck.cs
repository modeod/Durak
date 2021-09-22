using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    class Deck
    {
        private List<Card> cards = new List<Card>();
        public List<Card> Cards
        {
            get
            { return cards; }
        }

        public Deck()
        {
            for(int i = (int)Enum.GetValues(typeof(Card_Type)).Cast<Card_Type>().First(); i <= (int)Enum.GetValues(typeof(Card_Type)).Cast<Card_Type>().Last(); i++)
            {
                for(int k = (int)Enum.GetValues(typeof(Card_Suits)).Cast<Card_Suits>().First(); k <= (int)Enum.GetValues(typeof(Card_Suits)).Cast<Card_Suits>().Last(); i++)
                {
                    cards.Add(new Card((Card_Suits)i, (Card_Type)k));
                }
            }

            cards.Shuffle();
        }

        public void GiveCardFromDeck(Player player, int num)
        {
            if(num <= 0) { Console.WriteLine("Error GiveCardFromDeck: Negative number"); return; }
            if(cards.Count == 0) { return; }
            for(int i = 1; i <= num; i++)
            {
                player.Cards.Add(cards.First());
                cards.Remove(cards.First());
            }
        }
        public void GiveCardFromDeck(Player player)
        {
            if (cards.Count == 0) { return; }
            player.Cards.Add(cards.First());
            cards.Remove(cards.First());
        }
    }
}
