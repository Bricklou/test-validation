using PuissanceQuatre.Common;
using PuissanceQuatre.Common.Rules;

namespace PuissanceQuatre.Power4;

public class Power4 : AbstractBoardGame<AbstractPower4Case>
{
    private const uint Power4WinLength = 4;

    private readonly ConsoleGui<AbstractPower4Case> _gui = new();
    private bool _exitGame;
    private bool _playerTurn = true;

    public Power4() : base(Power4CaseFactory.CreatePower4Grid(), [
        new DiagonalRule<AbstractPower4Case>(Power4WinLength),
        new HorizontalRule<AbstractPower4Case>(Power4WinLength),
        new VerticalRule<AbstractPower4Case>(Power4WinLength)
    ])
    {
    }

    public void GameLoop()
    {
        while (!_exitGame)
        {
            _grid = new Grid<AbstractPower4Case>(7, 4);

            while (!_exitGame)
            {
                AbstractPower4Case symbol =
                    _playerTurn ? Power4CaseFactory.CreateCross() : Power4CaseFactory.CreateCircle();
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

    private (uint, uint) PlayerTurn(AbstractPower4Case symbol)
    {
        var (x, y) = (0u, 0u);
        var moved = false;

        while (!_exitGame && !moved)
        {
            _gui.ShowGrid(_grid);
            _gui.ShowMessage("Choisir une case valide et appuyez sur [Entrer]");

            (x, y) = _gui.AskForPosition(_grid);

            // Make the case fall to the bottom of the grid (if possible) until the first occupied case or the last row
            while (y < _grid.Height - 1 && _grid.GetPosition(x, y + 1) is null) y++;

            _grid.SetPosition(x, y, symbol);
            moved = true;
            _exitGame = false;
        }

        return (x, y);
    }

    private void EndGame(string msg)
    {
        _gui.ShowGrid(_grid);
        _gui.ShowMessage(msg);
    }
}