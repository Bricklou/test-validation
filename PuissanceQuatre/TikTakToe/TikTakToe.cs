using PuissanceQuatre.Common;
using PuissanceQuatre.Common.Rules;

namespace PuissanceQuatre.TikTakToe;

public class TikTakToe : AbstractBoardGame<AbstractTikTakToeCase>
{
    private const uint TikTakToeWinLength = 3;
    
    private readonly ConsoleGui<AbstractTikTakToeCase> _gui = new();
    private bool _exitGame;
    private bool _playerTurn = true;
    
    public TikTakToe(): base(TikTakToeCaseFactory.CreateTikTakToeGrid(), [
        new DiagonalRule<AbstractTikTakToeCase>(TikTakToeWinLength),
        new HorizontalRule<AbstractTikTakToeCase>(TikTakToeWinLength),
        new VerticalRule<AbstractTikTakToeCase>(TikTakToeWinLength)
    ]) {}
    
    public void GameLoop()
    {
        while (!_exitGame)
        {
            _grid = new Grid<AbstractTikTakToeCase>(3, 3);

            while (!_exitGame)
            {
                AbstractTikTakToeCase symbol =
                    _playerTurn ? TikTakToeCaseFactory.CreateCaseX() : TikTakToeCaseFactory.CreateCaseO();
                var (row, column) = PlayerTurn(symbol);

                if (CheckVictory(symbol, row, column))
                {
                    var name = _playerTurn ? "1" : "2";
                    EndGame($"Le joueur {name} à gagné !");
                    break;
                }

                _playerTurn = !_playerTurn;
                if (CheckTie())
                {
                    EndGame("Aucun vainqueur, la partie se termine sur une égalité.");
                    break;
                }
            }

            if (!_exitGame)
            {
                _gui.ShowMessage("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                var invalidKey = true;
                
                // TODO: This code should be handled inside the ConsoleGui class since it is GUI related (especially Console related)
                while (invalidKey)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            _exitGame = true;
                            Console.Clear();
                            invalidKey = false;
                            break;
                        case ConsoleKey.Enter:
                            invalidKey = false;
                            break;
                        default:
                            invalidKey = true;
                            break;
                    }
                }
            }
        }
    }

    private (uint, uint) PlayerTurn(AbstractTikTakToeCase symbol)
    {
        var (x, y) = (0u, 0u);
        var moved = false;

        while (!_exitGame && !moved)
        {
            _gui.ShowGrid(_grid);
            _gui.ShowMessage("Choisir une case valide et appuyez sur [Entrer]");

            // TODO: Shouldn't the "AskForPosition" be declared in a Player class? In order to have different logic depending on if
            // the player is a human or an AI
            (x, y) = _gui.AskForPosition(_grid);

            // TODO: implement the escape key to quit the game
            _grid.SetPosition(x, y, symbol);
            moved = true;
            _exitGame = false;
        }
        
        return (x, y);
    }

    private bool CheckTie()
    {
        return _grid.GetPosition(0, 0) == null && _grid.GetPosition(1, 0) == null && _grid.GetPosition(2, 0) == null &&
               _grid.GetPosition(0, 1) == null && _grid.GetPosition(1, 1) == null && _grid.GetPosition(2, 1) == null &&
               _grid.GetPosition(0, 2) == null && _grid.GetPosition(1, 2) == null && _grid.GetPosition(2, 2) == null;
    }


    private void EndGame(string msg)
    {
        _gui.ShowGrid(_grid);
        _gui.ShowMessage(msg);
    }
}