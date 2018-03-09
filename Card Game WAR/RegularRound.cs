using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Card_Game_WAR
{
    public class RegularRound
    {
        public static void Fight(CardDeck player1Deck, CardDeck player2Deck)
        {
            // Define needed variables
            List<Card> _cards = new List<Card>();
            _cards.Add(player1Deck.Deck.ElementAt(0));
            _cards.Add(player2Deck.Deck.ElementAt(0));

            // Add cards from round to bottom of winners deck
            if (_cards.ElementAt(0).Rank > _cards.ElementAt(1).Rank)
                CardDeck.MoveCards(player1Deck, player2Deck, _cards);
            else
                CardDeck.MoveCards(player2Deck, player1Deck, _cards);
        }

        public static string PrintRound(CardDeck player1Deck, CardDeck player2Deck)
        {
            List<Card> _cards = new List<Card>() {
                player1Deck.Deck.ElementAt(0),
                player2Deck.Deck.ElementAt(0) };

            return string.Format(
                "<div class=\"bg-secondary rounded my-3 p-2 text-light text-center\">" +
                "<p>{0} -- vs -- {1}</p><h5><strong class=\"{2} player\">{3}" +
                "</strong> wins the round</h5></div>",
                _cards.ElementAt(0).PrintCardName(), 
                _cards.ElementAt(1).PrintCardName(), 
                RegularRound.PrintRoundWinnerCSSClass(_cards),
                RegularRound.PrintRoundWinner(_cards));
        }

        public static string PrintRoundWinner(List<Card> cards)
        {
            string _winner = "";
            if (cards.ElementAt(0).Rank > cards.ElementAt(1).Rank)
                _winner = "Player 1";
            else if (cards.ElementAt(0).Rank < cards.ElementAt(1).Rank)
                _winner = "Player 2";

            return _winner;
        }

        public static string PrintRoundWinnerCSSClass(List<Card> cards)
        {
            string _winnerCSSClass = "";
            if (cards.ElementAt(0).Rank > cards.ElementAt(1).Rank)
                _winnerCSSClass = "text-primary";
            else if (cards.ElementAt(0).Rank < cards.ElementAt(1).Rank)
                _winnerCSSClass = "text-danger";

            return _winnerCSSClass;
        }
    }
}