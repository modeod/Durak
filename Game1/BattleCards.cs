using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    class BattleCards
    {
        private int maxCardsNum;
        private Dictionary<Card, Card> battleYard;
        private Card_Suits trump;
        public int MaxCardsNum { get { return maxCardsNum; } }
        public Dictionary<Card, Card> BattleYard { get { return battleYard; } }

        public BattleCards(int maxCardsNum, Card_Suits trump)
        {
            this.maxCardsNum = maxCardsNum;
            this.trump = trump;
            battleYard = new Dictionary<Card, Card>();
        }

        public bool PutCardToBeat(Card card) //returns true if can put card
        {
            if (battleYard.Count == maxCardsNum) { Console.WriteLine("Error BattleCards.PutCardToBeat: Max amount of Cards"); return false; }
            battleYard.Add(card, null);
            return true;
        }

        public bool BeatCard(Card underBeat, Card beating) //returns true if can beat card
        {
            if (!battleYard.ContainsKey(underBeat)) { Console.WriteLine("Error BattleCards.BeatCard: Have no this card to beat"); return false; }

            if (IfCardCanBeat(underBeat, beating, trump))
            {
                battleYard[underBeat] = beating;
                return true;
            }
            else return false;


        }
        public bool BeatCard(int number, Card beating) //returns true if can beat card
        {
            if (number > battleYard.Count || number <= 0 ) { Console.WriteLine("Error BattleCards.BeatCard: Have no this card to beat"); return false; }
            
            if (IfCardCanBeat(battleYard.ElementAt(number).Key, beating, trump))
            {
                battleYard[battleYard.ElementAt(number).Key] = beating;
                return true;
            }
            else return false;
            
        }

        public void ClearBattle()
        {
            battleYard = new Dictionary<Card, Card>();
        }

        public void GiveUp(Player player)
        {
            foreach(Card card in battleYard.Keys.ToArray())
            {
                player.Cards.Add(card);
            }

            foreach(Card card in battleYard.Values.ToArray())
            {
                player.Cards.Add(card);
            }

            ClearBattle();
        }
        
        public static bool IfCardCanBeat(Card underBeat, Card beating, Card_Suits trump)
        {
            if ((underBeat.Suit != trump && beating.Suit != trump) || (underBeat.Suit == trump && beating.Suit == trump))
            {
                return ifBigger(underBeat.Type, beating.Type);
            }
            else if (underBeat.Suit != trump && beating.Suit == trump)
                return true;
            else
                return false;

            bool ifBigger(Card_Type under, Card_Type beat)
            {
                if ((int)under < (int)beat) return true;
                else return false;
            }
        }
    }
}
