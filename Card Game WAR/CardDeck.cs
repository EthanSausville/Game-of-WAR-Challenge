using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Card_Game_WAR
{
    [Serializable()]
    public class CardDeck
    {
        public List<Card> Deck { get; set; }
        private static Random randomCard = new Random();

        // Moves a list of cards from one deck to another
        public static void MoveCards(CardDeck winner, CardDeck loser,List<Card> cards)
        {
            for (int i = 0; i < (cards.Count() / 2); i++)
            {
                winner.Deck.RemoveAt(i);
                loser.Deck.RemoveAt(i);
            }

            winner.Deck.AddRange(cards);
        }

        // Deals entire deck from the first input deck into the other input decks
        public static void DealDeck(CardDeck dealFrom, params CardDeck[] dealTo)
        {
            while (dealFrom.Deck.Count() >= dealTo.Length)
            {
                for (int i = 0; i < dealTo.Length; i++)
                    CardDeck.DealRandomCard(dealFrom, dealTo[i]);
            }
        }

        // Deals a single random card from one deck to another
        public static void DealRandomCard(CardDeck dealFrom, CardDeck dealTo)
        {
            int _card = randomCard.Next(dealFrom.Deck.Count);
            dealTo.Deck.Add(dealFrom.Deck.ElementAt(_card));
            dealFrom.Deck.RemoveAt(_card);
        }

        // Prints out all cards in any given deck
        public static string PrintDeck(CardDeck deck)
        {
            string result = "";
            foreach (Card card in deck.Deck)
                result += card.PrintCardName() + "<br />";

            return result;
        }

        // Initilize a basic deck of cards
        public CardDeck(bool isFullDeck)
        {
            if (isFullDeck) { Deck = new List<Card>() {
                    new Card{ FaceValue = "2", Rank = 1, Suite = "Hearts"},
                    new Card{ FaceValue = "3", Rank = 2, Suite = "Hearts"},
                    new Card{ FaceValue = "4", Rank = 3, Suite = "Hearts"},
                    new Card{ FaceValue = "5", Rank = 4, Suite = "Hearts"},
                    new Card{ FaceValue = "6", Rank = 5, Suite = "Hearts"},
                    new Card{ FaceValue = "7", Rank = 6, Suite = "Hearts"},
                    new Card{ FaceValue = "8", Rank = 7, Suite = "Hearts"},
                    new Card{ FaceValue = "9", Rank = 8, Suite = "Hearts"},
                    new Card{ FaceValue = "10", Rank = 9, Suite = "Hearts"},
                    new Card{ FaceValue = "Jack", Rank = 10, Suite = "Hearts"},
                    new Card{ FaceValue = "Queen", Rank = 11, Suite = "Hearts"},
                    new Card{ FaceValue = "King", Rank = 12, Suite = "Hearts"},
                    new Card{ FaceValue = "Ace", Rank = 13, Suite = "Hearts" },

                    new Card{ FaceValue = "2", Rank = 1, Suite = "Diamonds"},
                    new Card{ FaceValue = "3", Rank = 2, Suite = "Diamonds"},
                    new Card{ FaceValue = "4", Rank = 3, Suite = "Diamonds"},
                    new Card{ FaceValue = "5", Rank = 4, Suite = "Diamonds"},
                    new Card{ FaceValue = "6", Rank = 5, Suite = "Diamonds"},
                    new Card{ FaceValue = "7", Rank = 6, Suite = "Diamonds"},
                    new Card{ FaceValue = "8", Rank = 7, Suite = "Diamonds"},
                    new Card{ FaceValue = "9", Rank = 8, Suite = "Diamonds"},
                    new Card{ FaceValue = "10", Rank = 9, Suite = "Diamonds"},
                    new Card{ FaceValue = "Jack", Rank = 10, Suite = "Diamonds"},
                    new Card{ FaceValue = "Queen", Rank = 11, Suite = "Diamonds"},
                    new Card{ FaceValue = "King", Rank = 12, Suite = "Diamonds"},
                    new Card{ FaceValue = "Ace", Rank = 13, Suite = "Diamonds" },

                    new Card{ FaceValue = "2", Rank = 1, Suite = "Clubs"},
                    new Card{ FaceValue = "3", Rank = 2, Suite = "Clubs"},
                    new Card{ FaceValue = "4", Rank = 3, Suite = "Clubs"},
                    new Card{ FaceValue = "5", Rank = 4, Suite = "Clubs"},
                    new Card{ FaceValue = "6", Rank = 5, Suite = "Clubs"},
                    new Card{ FaceValue = "7", Rank = 6, Suite = "Clubs"},
                    new Card{ FaceValue = "8", Rank = 7, Suite = "Clubs"},
                    new Card{ FaceValue = "9", Rank = 8, Suite = "Clubs"},
                    new Card{ FaceValue = "10", Rank = 9, Suite = "Clubs"},
                    new Card{ FaceValue = "Jack", Rank = 10, Suite = "Clubs"},
                    new Card{ FaceValue = "Queen", Rank = 11, Suite = "Clubs"},
                    new Card{ FaceValue = "King", Rank = 12, Suite = "Clubs"},
                    new Card{ FaceValue = "Ace", Rank = 13, Suite = "Clubs" },

                    new Card{ FaceValue = "2", Rank = 1, Suite = "Spades"},
                    new Card{ FaceValue = "3", Rank = 2, Suite = "Spades"},
                    new Card{ FaceValue = "4", Rank = 3, Suite = "Spades"},
                    new Card{ FaceValue = "5", Rank = 4, Suite = "Spades"},
                    new Card{ FaceValue = "6", Rank = 5, Suite = "Spades"},
                    new Card{ FaceValue = "7", Rank = 6, Suite = "Spades"},
                    new Card{ FaceValue = "8", Rank = 7, Suite = "Spades"},
                    new Card{ FaceValue = "9", Rank = 8, Suite = "Spades"},
                    new Card{ FaceValue = "10", Rank = 9, Suite = "Spades"},
                    new Card{ FaceValue = "Jack", Rank = 10, Suite = "Spades"},
                    new Card{ FaceValue = "Queen", Rank = 11, Suite = "Spades"},
                    new Card{ FaceValue = "King", Rank = 12, Suite = "Spades"},
                    new Card{ FaceValue = "Ace", Rank = 13, Suite = "Spades" } }; }
            else Deck = new List<Card>();
        }
    }
}