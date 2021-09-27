using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public enum Card_Suits
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    // WTF IDK FOR WHAT THIS IS BUT LET IT BE   . _ .
    public abstract class DefaultCardDeck
    {
        public readonly Dictionary<string, int> Card_Type;
        public readonly List<string> Card_Special;

        /// <summary>
        /// Makes rule for Durak Deck. For example Ace can be beated by Two etc.
        /// </summary>
        /// <param name="underBeat">int power = Card_Type[underBeat.typeString] //(2-10, J=11, Q=12, K=13, A=14 </param>
        public delegate bool RuleForCardBeating(DefaultCard underBeat, DefaultCard beating, Card_Suits trump);

        /// <param name="rule"> If rule == null - using basic rules for the game </param>
        protected static bool IfCardCanBeat(DefaultCard underBeat, DefaultCard beating, Card_Suits trump, RuleForCardBeating rule)
        {
            return rule(underBeat, beating, trump);
        }
    }

    public class CardDeck36 : DefaultCardDeck
    {
        public readonly static new Dictionary<string, int> Card_Type = new Dictionary<string, int> { { "Six", 6 }, { "Seven", 7 }, { "Eight", 8 }, { "Nine", 9 }, { "Ten", 10 }, { "Jack", 11 }, { "Queen", 12 }, { "King", 13 }, { "Ace", 14 } };

        public new static bool IfCardCanBeat(DefaultCard underBeat, DefaultCard beating, Card_Suits trump, RuleForCardBeating rule)
        {
            if(rule == null)
            {
                if ((underBeat.suit != trump && beating.suit != trump) || (underBeat.suit == trump && beating.suit == trump))
                {
                    if (Card_Type[underBeat.typeString] < Card_Type[beating.typeString])
                        return true;
                    else
                        return false;
                }
                else if (underBeat.suit != trump && beating.suit == trump)
                    return true;
                else
                    return false;
            }
            else
            {
                return rule(underBeat, beating, trump);
            }
        }

    }

    public class CardDeck52 : CardDeck36
    {
        public readonly static new Dictionary<string, int> Card_Type = new Dictionary<string, int> { { "Two", 2 }, { "Three", 3 }, { "Four", 4 }, { "Five", 5 }, { "Six", 6 }, { "Seven", 7 }, { "Eight", 8 }, { "Nine", 9 }, { "Ten", 10 }, { "Jack", 11 }, { "Queen", 12 }, { "King", 13 }, { "Ace", 14 } };
    }

    public class CardDeck54 : CardDeck52
    {
        public new readonly List<string> Card_Special = new List<string> { "JokerRed", "JokerBlack" };
        //TODO: Realise this shit
    }

    abstract public class DefaultCard
    {
        public readonly Card_Suits suit;
        public readonly int typeInt;
        public readonly string typeString;
    }

    public class Card36 : DefaultCard
    {
        public readonly Card_Suits suit;
        public readonly int typeInt;
        public readonly string typeString;

        public Card36(Card_Suits suit, string type) 
        {
            if (!CardDeck36.Card_Type.ContainsKey(type)) { Console.WriteLine("Error: Card36 doesn't have this type of card. Use CardDeck36.CardDeck36"); return; }
            this.typeString = type;
            this.typeInt = CardDeck36.Card_Type[type];
        }
    }

    public class Card52 : DefaultCard
    {
        public readonly Card_Suits suit;
        public readonly int typeInt;
        public readonly string typeString;

        public Card52(Card_Suits suit, string type)
        {
            if (!CardDeck52.Card_Type.ContainsKey(type)) { Console.WriteLine("Error: Card36 doesn't have this type of card. Use CardDeck36.CardDeck36"); return; }
            this.typeString = type;
            this.typeInt = CardDeck36.Card_Type[type];
        }
    }
}
