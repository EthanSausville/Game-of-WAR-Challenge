using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Card_Game_WAR
{
    public partial class Default : System.Web.UI.Page
    {
        CardDeck freshDeck = new CardDeck(true);
        CardDeck player1Deck = new CardDeck(false);
        CardDeck player2Deck = new CardDeck(false);
        int wars = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CardDeck.DealDeck(freshDeck, player1Deck, player2Deck);
                ViewState["Wars"] = 0;
                StoreDecks();
            }
        }

        protected void playGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
            while (wars < 5 && (player1Deck.Deck.Count() > 10 && player2Deck.Deck.Count() > 10))
            {
                PlaySingleRound();
                PrintWinner();
            }
        }

        // Logic for a single round
        public void PlaySingleRound()
        {
            wars = (int)ViewState["Wars"];
            if (player1Deck.Deck.Count() >= 10 || player2Deck.Deck.Count() >= 10)
            {
                if (player1Deck.Deck.ElementAt(0).Rank == player2Deck.Deck.ElementAt(0).Rank)
                {
                    // Actions for a round of war
                    resultLabel.Text += WarRound.PrintWar(player1Deck, player2Deck);
                    WarRound.War(player1Deck, player2Deck);
                    ViewState["Wars"] = ++wars;
                    StoreDecks();
                }
                else
                {
                    // Actions for a normal round
                    resultLabel.Text += RegularRound.PrintRound(player1Deck, player2Deck);
                    RegularRound.Fight(player1Deck, player2Deck);
                    StoreDecks();
                }
            }
            else
                PrintWinner();
        }

        // Logic to reset for a new game
        public void NewGame()
        {
            ViewState["Wars"] = 0;
            resultLabel.Text = "";

            CardDeck.DealDeck(freshDeck, player1Deck, player2Deck);
            player1ResultLabel.Text = CardDeck.PrintDeck(player1Deck);
            player2ResultLabel.Text = CardDeck.PrintDeck(player2Deck);
        }

        // Prints winner to jumbtron
        public void PrintWinner()
        {
            string result = "";
            string resultCSSClass = "";

            CallDecks();
            if (player1Deck.Deck.Count() > player2Deck.Deck.Count()) {
                result = "Player 1 WINS";
                resultCSSClass = "bg-primary"; }
            else if (player1Deck.Deck.Count() < player2Deck.Deck.Count()) {
                result = "Player 2 WINS";
                resultCSSClass = "bg-danger"; }
            else {
                result = "It was a draw...";
                resultCSSClass = "bg-secondary";}
            winnerLabel.Text = string.Format("<div class=\"jumbotron text-center {0}\"><h2>{1}</h2></div>", 
                resultCSSClass, result);
        }

        // Stores variables in ViewState
        public void StoreDecks()
        {
            ViewState["Player1Deck"] = player1Deck;
            ViewState["Player2Deck"] = player2Deck;
            ViewState["FreshDeck"] = freshDeck;
        }

        // Calls variables from ViewState
        public void CallDecks()
        {
            player1Deck = (CardDeck)ViewState["Player1Deck"];
            player2Deck = (CardDeck)ViewState["Player2Deck"];
            freshDeck = (CardDeck)ViewState["FreshDeck"];
        }
    }
}