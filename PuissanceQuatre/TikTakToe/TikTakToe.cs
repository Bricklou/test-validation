using PuissanceQuatre.Common;

namespace PuissanceQuatre.TikTakToe;

public class TikTakToe
{
    private readonly ConsoleGui<AbstractTikTakToeCase> _gui = new();
    private bool _exitGame;
    private Grid<AbstractTikTakToeCase> _grid;
    private bool _playerTurn = true;

    public void GameLoop()
    {
        while (!_exitGame)
        {
            _grid = new Grid<AbstractTikTakToeCase>(3, 3);

            while (!_exitGame)
            {
                AbstractTikTakToeCase symbol =
                    _playerTurn ? TikTakToeCaseFactory.CreateCaseX() : TikTakToeCaseFactory.CreateCaseO();
                PlayerTurn(symbol);
                if (CheckVictory(symbol))
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

    private void PlayerTurn(AbstractTikTakToeCase symbol)
    {
        var moved = false;

        while (!_exitGame && !moved)
        {
            _gui.ShowGrid(_grid);
            _gui.ShowMessage("Choisir une case valide et appuyez sur [Entrer]");

            var (row, column) = _gui.AskForPosition(_grid);

            // TODO: implement the escape key to quit the game
            _grid.SetPosition(row, column, symbol);
            moved = true;
            _exitGame = false;
        }
    }

    private bool CheckVictory(AbstractTikTakToeCase v)
    {
        return (v.Equals(_grid.GetPosition(0, 0)) && v.Equals(_grid.GetPosition(1, 0)) &&
                v.Equals(_grid.GetPosition(2, 0))) ||
               (v.Equals(_grid.GetPosition(0, 1)) && v.Equals(_grid.GetPosition(1, 1)) &&
                v.Equals(_grid.GetPosition(2, 1))) ||
               (v.Equals(_grid.GetPosition(0, 2)) && v.Equals(_grid.GetPosition(1, 2)) &&
                v.Equals(_grid.GetPosition(2, 2))) ||
               (v.Equals(_grid.GetPosition(0, 0)) && v.Equals(_grid.GetPosition(1, 1)) &&
                v.Equals(_grid.GetPosition(2, 2))) ||
               (v.Equals(_grid.GetPosition(1, 0)) && v.Equals(_grid.GetPosition(1, 1)) &&
                v.Equals(_grid.GetPosition(1, 2))) ||
               (v.Equals(_grid.GetPosition(2, 0)) && v.Equals(_grid.GetPosition(2, 1)) &&
                v.Equals(_grid.GetPosition(2, 2))) ||
               (v.Equals(_grid.GetPosition(0, 0)) && v.Equals(_grid.GetPosition(1, 1)) &&
                v.Equals(_grid.GetPosition(2, 2))) ||
               (v.Equals(_grid.GetPosition(2, 0)) && v.Equals(_grid.GetPosition(1, 1)) &&
                v.Equals(_grid.GetPosition(0, 2)));
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