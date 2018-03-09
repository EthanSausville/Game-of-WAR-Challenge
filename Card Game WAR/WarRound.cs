using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Card_Game_WAR
{
    public class WarRound
    {
        public static void War(CardDeck player1Deck, CardDeck player2Deck)
        {
            // Determine how many wars, ie Double, Triple, etc...
            int wars = WarRound.HowManyCards(player1Deck, player2Deck);

            // Define cards to print
            List<Card> _cards = new List<Card>();
            for (int i = 0; i < (wars * 4 + 1); i++)
            {
                _cards.Add(player1Deck.Deck.ElementAt(i));
                _cards.Add(player2Deck.Deck.ElementAt(i));
            }

            // Add cards from round to bottom of winners deck
            if (_cards.ElementAt(8 * wars).Rank > _cards.ElementAt(8 * wars + 1).Rank)
                CardDeck.MoveCards(player1Deck, player2Deck, _cards);
            else if (_cards.ElementAt(8 * wars).Rank < _cards.ElementAt(8 * wars + 1).Rank)
                CardDeck.MoveCards(player2Deck, player1Deck, _cards);
        }

        public static string PrintWar(CardDeck player1Deck, CardDeck player2Deck)
        {
            // Determine how many wars, ie Double, Triple, etc...
            int wars = WarRound.HowManyCards(player1Deck, player2Deck);

            // Define cards to print
            List<Card> _cards = new List<Card>();
            for (int i = 0; i < (wars * 4 + 1); i++)
            {
                _cards.Add(player1Deck.Deck.ElementAt(i));
                _cards.Add(player2Deck.Deck.ElementAt(i));
            }

            // Resulting string with HTML imbedded
            return string.Format(
                "<div class=\"bg-warning rounded my-3 p-2 text-light text-center\">{0}" +
                "<h5><strong class=\"{1} player\">{2}</strong> wins the WAR</h5></div>",
                WarRound.PrintWarCards(_cards),
                WarRound.PrintRoundWinnerCSSClass(_cards, wars),
                WarRound.PrintRoundWinner(_cards, wars));
        }

        public static int HowManyCards(CardDeck player1Deck, CardDeck player2Deck)
        {
            // Checks for Double or Triple War
            int wars = 1;
            while (player1Deck.Deck.ElementAt(wars * 4 - 1) == player2Deck.Deck.ElementAt(wars * 4 - 1))
                wars++;

            return wars;
        }

        public static string PrintWarCards(List<Card> cards)
        {
            string _warCards = "";
            for (int i = 0; i < cards.Count();)
            {
                if (i % 8 == 0 || i == 0)
                    _warCards += string.Format("<p class=\"text-dark\"><strong>{0} -- vs -- {1}</strong></p>",
                        cards.ElementAt(i).PrintCardName(),
                        cards.ElementAt(i + 1).PrintCardName());
                else
                    _warCards += string.Format("<p>{0} -- vs -- {1}</p>",
                        cards.ElementAt(i).PrintCardName(),
                        cards.ElementAt(i + 1).PrintCardName());
                i += 2;
            }
            return _warCards;
        }

        public static string PrintRoundWinner(List<Card> cards, int wars)
        {
            string _winner = "";
            if (cards.ElementAt(8 * wars).Rank > cards.ElementAt(8 * wars + 1).Rank)
                _winner = "Player 1";
            else if (cards.ElementAt(8 * wars).Rank < cards.ElementAt(8 * wars + 1).Rank)
                _winner = "Player 2";

            return _winner;
        }

        public static string PrintRoundWinnerCSSClass(List<Card> cards, int wars)
        {
            string _winnerCSSClass = "";
            if (cards.ElementAt(8 * wars).Rank > cards.ElementAt(8 * wars + 1).Rank)
                _winnerCSSClass = "text-primary";
            else if (cards.ElementAt(8 * wars).Rank < cards.ElementAt(8 * wars + 1).Rank)
                _winnerCSSClass = "text-danger";

            return _winnerCSSClass;
        }
    }
}