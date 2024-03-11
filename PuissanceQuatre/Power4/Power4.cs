using PuissanceQuatre.Common;

namespace PuissanceQuatre.Power4;

public class Power4
{
    private readonly ConsoleGui<AbstractPower4Case> _gui = new();
    private bool _exitGame;
    private Grid<AbstractPower4Case> _grid;
    private bool _playerTurn = true;

    public void GameLoop()
    {
        while (!_exitGame)
        {
            _grid = new Grid<AbstractPower4Case>(4, 7);

            while (!_exitGame)
            {
                AbstractPower4Case symbol =
                    _playerTurn ? Power4CaseFactory.CreateCross() : Power4CaseFactory.CreateCircle();
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
                Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                var invalidKey = true;

                while (invalidKey)
                    switch (Console.ReadKey(true).Key)
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

    private void PlayerTurn(AbstractPower4Case symbol)
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

    private bool CheckVictory(AbstractPower4Case c)
    {
        return (_grid.GetPosition(0, 0) == c && _grid.GetPosition(1, 0) == c && _grid.GetPosition(2, 0) == c &&
                _grid.GetPosition(3, 0) == c) ||
               (_grid.GetPosition(0, 1) == c && _grid.GetPosition(1, 1) == c && _grid.GetPosition(2, 1) == c &&
                _grid.GetPosition(3, 1) == c) ||
               (_grid.GetPosition(0, 2) == c && _grid.GetPosition(1, 2) == c && _grid.GetPosition(2, 2) == c &&
                _grid.GetPosition(3, 2) == c) ||
               (_grid.GetPosition(0, 3) == c && _grid.GetPosition(1, 3) == c && _grid.GetPosition(2, 3) == c &&
                _grid.GetPosition(3, 3) == c) ||
               (_grid.GetPosition(0, 4) == c && _grid.GetPosition(1, 4) == c && _grid.GetPosition(2, 4) == c &&
                _grid.GetPosition(3, 4) == c) ||
               (_grid.GetPosition(0, 5) == c && _grid.GetPosition(1, 5) == c && _grid.GetPosition(2, 5) == c &&
                _grid.GetPosition(3, 5) == c) ||
               (_grid.GetPosition(0, 6) == c && _grid.GetPosition(1, 6) == c && _grid.GetPosition(2, 6) == c &&
                _grid.GetPosition(3, 6) == c) ||
               (_grid.GetPosition(0, 0) == c && _grid.GetPosition(0, 1) == c && _grid.GetPosition(0, 2) == c &&
                _grid.GetPosition(0, 3) == c) ||
               (_grid.GetPosition(0, 1) == c && _grid.GetPosition(0, 2) == c && _grid.GetPosition(0, 3) == c &&
                _grid.GetPosition(0, 4) == c) ||
               (_grid.GetPosition(0, 2) == c && _grid.GetPosition(0, 3) == c && _grid.GetPosition(0, 3) == c &&
                _grid.GetPosition(0, 5) == c) ||
               (_grid.GetPosition(0, 3) == c && _grid.GetPosition(0, 4) == c && _grid.GetPosition(0, 5) == c &&
                _grid.GetPosition(0, 6) == c) ||
               (_grid.GetPosition(1, 0) == c && _grid.GetPosition(1, 1) == c && _grid.GetPosition(1, 2) == c &&
                _grid.GetPosition(1, 3) == c) ||
               (_grid.GetPosition(1, 1) == c && _grid.GetPosition(1, 2) == c && _grid.GetPosition(1, 3) == c &&
                _grid.GetPosition(1, 4) == c) ||
               (_grid.GetPosition(1, 2) == c && _grid.GetPosition(1, 3) == c && _grid.GetPosition(1, 4) == c &&
                _grid.GetPosition(1, 5) == c) ||
               (_grid.GetPosition(1, 4) == c && _grid.GetPosition(1, 4) == c && _grid.GetPosition(1, 5) == c &&
                _grid.GetPosition(1, 6) == c) ||
               (_grid.GetPosition(2, 0) == c && _grid.GetPosition(2, 1) == c && _grid.GetPosition(2, 2) == c &&
                _grid.GetPosition(2, 3) == c) ||
               (_grid.GetPosition(2, 1) == c && _grid.GetPosition(2, 2) == c && _grid.GetPosition(2, 3) == c &&
                _grid.GetPosition(2, 4) == c) ||
               (_grid.GetPosition(2, 2) == c && _grid.GetPosition(2, 3) == c && _grid.GetPosition(2, 3) == c &&
                _grid.GetPosition(2, 5) == c) ||
               (_grid.GetPosition(2, 3) == c && _grid.GetPosition(2, 4) == c && _grid.GetPosition(2, 5) == c &&
                _grid.GetPosition(2, 6) == c) ||
               (_grid.GetPosition(3, 0) == c && _grid.GetPosition(3, 1) == c && _grid.GetPosition(3, 2) == c &&
                _grid.GetPosition(3, 3) == c) ||
               (_grid.GetPosition(3, 1) == c && _grid.GetPosition(3, 2) == c && _grid.GetPosition(3, 3) == c &&
                _grid.GetPosition(3, 4) == c) ||
               (_grid.GetPosition(3, 2) == c && _grid.GetPosition(3, 3) == c && _grid.GetPosition(3, 4) == c &&
                _grid.GetPosition(3, 5) == c) ||
               (_grid.GetPosition(3, 3) == c && _grid.GetPosition(3, 4) == c && _grid.GetPosition(3, 5) == c &&
                _grid.GetPosition(3, 6) == c) ||
               (_grid.GetPosition(0, 0) == c && _grid.GetPosition(1, 1) == c && _grid.GetPosition(2, 2) == c &&
                _grid.GetPosition(3, 3) == c) ||
               (_grid.GetPosition(0, 1) == c && _grid.GetPosition(1, 2) == c && _grid.GetPosition(2, 3) == c &&
                _grid.GetPosition(3, 4) == c) ||
               (_grid.GetPosition(0, 2) == c && _grid.GetPosition(1, 3) == c && _grid.GetPosition(2, 4) == c &&
                _grid.GetPosition(3, 5) == c) ||
               (_grid.GetPosition(0, 3) == c && _grid.GetPosition(1, 4) == c && _grid.GetPosition(2, 5) == c &&
                _grid.GetPosition(3, 6) == c) ||
               (_grid.GetPosition(0, 3) == c && _grid.GetPosition(1, 2) == c && _grid.GetPosition(2, 1) == c &&
                _grid.GetPosition(3, 0) == c) ||
               (_grid.GetPosition(0, 4) == c && _grid.GetPosition(1, 4) == c && _grid.GetPosition(2, 2) == c &&
                _grid.GetPosition(3, 1) == c) ||
               (_grid.GetPosition(0, 5) == c && _grid.GetPosition(1, 3) == c && _grid.GetPosition(2, 3) == c &&
                _grid.GetPosition(3, 2) == c) ||
               (_grid.GetPosition(0, 6) == c && _grid.GetPosition(1, 5) == c && _grid.GetPosition(2, 4) == c &&
                _grid.GetPosition(3, 3) == c);
    }

    private bool CheckTie()
    {
        return _grid.GetPosition(0, 0) != null && _grid.GetPosition(0, 1) != null &&
               _grid.GetPosition(0, 2) != null && _grid.GetPosition(0, 3) != null &&
               _grid.GetPosition(0, 4) != null && _grid.GetPosition(0, 5) != null &&
               _grid.GetPosition(0, 6) != null &&
               _grid.GetPosition(1, 0) != null && _grid.GetPosition(1, 1) != null &&
               _grid.GetPosition(1, 2) != null && _grid.GetPosition(1, 3) != null &&
               _grid.GetPosition(1, 4) != null && _grid.GetPosition(1, 5) != null &&
               _grid.GetPosition(1, 6) != null &&
               _grid.GetPosition(2, 0) != null && _grid.GetPosition(2, 1) != null &&
               _grid.GetPosition(1, 2) != null && _grid.GetPosition(2, 3) != null &&
               _grid.GetPosition(2, 4) != null && _grid.GetPosition(2, 5) != null &&
               _grid.GetPosition(2, 6) != null &&
               _grid.GetPosition(3, 0) != null && _grid.GetPosition(3, 1) != null &&
               _grid.GetPosition(3, 2) != null && _grid.GetPosition(3, 3) != null &&
               _grid.GetPosition(3, 4) != null && _grid.GetPosition(3, 5) != null && _grid.GetPosition(3, 5) != null;
    }


    private void EndGame(string msg)
    {
        _gui.ShowGrid(_grid);
        _gui.ShowMessage(msg);
    }
}