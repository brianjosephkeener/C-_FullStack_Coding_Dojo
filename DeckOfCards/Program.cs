using System;
using System.Collections.Generic

namespace DeckOfCards
{
    class Card
{
    private string stringVal;
    private int val;
    private string suit;
    public static string[] Suits = new string[] {"Clubs", "Hearts", "Diamonds", "Spades"};
    public Card(string card, int value)
    {
        if (value == 11)
        {
            stringVal = "Jack";
        }
        if (value == 1)
        {
            stringVal = "Ace";
        }
        if (value == 13)
        {
            stringVal = "King";
        }
        if (value == 12)
        {
            stringVal = "Ace";
        }
        else 
        {
            stringVal = value.ToString();
        }
        suit = card;
        val = value;
    }
}

class Deck
    {
        private List<Card> cards = new List<Card>();
        public Deck()
        {
            Reset();
        }

        public List<Card> Reset()
        {
            cards.Clear();
            for(int i = 0; i < 4; i++)
            {
                int j = 1;
                while(j < 14)
                {
                    cards.Add(new Card(Card.Suits[i], j));
                    j++;
                }
            }
            return cards;
        }

        public List<Card> Cards
        {
            get { return this.cards; }
        }

        public void ShowDeck()
        {
            foreach (Card c in cards)
            {
                c.SayCard();
            }
        }

        public Card Deal()
        {
            Card theCard = cards[0];
            cards.RemoveAt(0);
            return theCard;
        }

        public void Shuffle()
        {
            List<Card> cards2shuffle = this.cards;
            List<Card> shuffled = new List<Card>();
            Random randy = new Random();
            while(cards2shuffle.Count > 0)
            {
                int idx = randy.Next(0, cards2shuffle.Count);
                shuffled.Add(cards2shuffle[idx]);
                cards2shuffle.RemoveAt(idx);
            }
            this.cards = shuffled;
        }
    }
    class Player
    {
        private string name;
        private List<Card> hand;
        public Player(string name)
        {
            this.name = name;
            hand = new List<Card>();
        }

        public string Name
        {
            get { return name; }
        }

        public Card Draw(Deck d)
        {
            Card theCard = d.Deal();
            hand.Add(theCard);
            return theCard;
        }

        public Card Discard(int idx)
        {
            Card theCard;
            if(idx < hand.Count)
            {
                theCard = hand[idx];
                hand.RemoveAt(idx);
                return theCard;
            }
            else { return null; }
        }

    }
}
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
