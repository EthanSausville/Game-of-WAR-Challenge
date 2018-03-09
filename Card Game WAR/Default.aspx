<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Card_Game_WAR.Default" MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
    <link href="Style.css" rel="stylesheet" />

    <title>Play War</title>
</head>
<body class="bg-info">
    <form id="form1" runat="server" class="container bg-light pt-5" style="min-height:100vh;">
        <div class="jumbotron py-2">
            <h1>Play WAR!</h1>
            <p>A game of true randomness, but it's still kinda fun. You can find out how to play here: 
                <a href="https://www.youtube.com/watch?v=G4DhzhDlXFM">Card Games: How to Play War</a>. 
                This version of the game plays until there have been 5 wars or until a player has 10 or less cards, 
                then determines a winner.</p>
            <div class="my-2">
                <asp:Button CssClass="btn btn-danger btn-lg" ID="playGameButton" runat="server" OnClick="playGameButton_Click" Text="Play Game" /> 
            <hr class="border-secondary"/>
            </div>
            <asp:Label ID="winnerLabel" runat="server"></asp:Label>
            <div class="row mt-5">
                <div class="col">
                    <h2>Game Result</h2>
                    <asp:Label ID="resultLabel" runat="server"></asp:Label>
                </div>
                <div class="col">
                    <h2><strong class="text-primary player">Player 1</strong></h2>
                    <asp:Label ID="player1ResultLabel" runat="server"></asp:Label>
                </div>
                <div class="col">
                    <h2><strong class="text-danger player">Player 2</strong></h2>
                    <asp:Label ID="player2ResultLabel" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
