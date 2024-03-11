namespace MorpionApp;

public class PuissanceQuatre
{
    private Grid<AbstractPuissanceQuatreCase> _grid;
    private readonly ConsoleGui<AbstractPuissanceQuatreCase> _gui = new();
    private bool _quiterJeu;
    private bool _tourDuJoueur = true;

    public void BoucleJeu()
    {
        while (!_quiterJeu)
        {
            _grid = new Grid<AbstractPuissanceQuatreCase>(4, 7);

            while (!_quiterJeu)
            {
                AbstractPuissanceQuatreCase symbol = _tourDuJoueur ? PuissanceQuatreCaseFactory.CreateCross() : PuissanceQuatreCaseFactory.CreateCircle();
                TourJoueur(symbol);

                if (VerifVictoire(symbol))
                {
                    var name = _tourDuJoueur ? "1" : "2";
                    FinPartie($"Le joueur {name} à gagné !");
                    break;
                }

                _tourDuJoueur = !_tourDuJoueur;
                if (VerifEgalite())
                {
                    FinPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                    break;
                }
            }

            if (!_quiterJeu)
            {
                Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                GetKey:
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        _quiterJeu = true;
                        Console.Clear();
                        break;
                    default:
                        goto GetKey;
                }
            }
        }
    }

    private void TourJoueur(AbstractPuissanceQuatreCase symbol)
    {
        var moved = false;

        while (!_quiterJeu && !moved)
        {
            _gui.ShowGrid(_grid);
            _gui.ShowMessage("Choisir une case valide et appuyez sur [Entrer]");

            var (row, column) = _gui.AskForPosition(_grid);

            // TODO: implement the escape key to quit the game
            _grid.SetPosition(row, column, symbol);
            moved = true;
            _quiterJeu = false;
        }
    }
    private bool VerifVictoire(AbstractPuissanceQuatreCase c)
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

    private bool VerifEgalite()
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


    private void FinPartie(string msg)
    {
     _gui.ShowGrid(_grid);
     _gui.ShowMessage(msg);
    }
}