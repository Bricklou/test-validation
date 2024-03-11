namespace MorpionApp;

public class Morpion
{
    private Grid<AbstractMorpionCase> _grid;
    private readonly ConsoleGui<AbstractMorpionCase> _gui = new();
    private bool _quiterJeu;
    private bool _tourDuJoueur = true;

    public void BoucleJeu()
    {
        while (!_quiterJeu)
        {
            _grid = new Grid<AbstractMorpionCase>(3, 3);

            while (!_quiterJeu)
            {
                AbstractMorpionCase symbol = _tourDuJoueur ? MorpionCaseFactory.CreateCaseX() : MorpionCaseFactory.CreateCaseO();
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
                _gui.ShowMessage("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                var invalidKey = true;
                while (invalidKey)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            _quiterJeu = true;
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

    private void TourJoueur(AbstractMorpionCase symbol)
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

    private bool VerifVictoire(AbstractMorpionCase v)
    {
        return (v.Equals(_grid.GetPosition(0, 0)) && v.Equals(_grid.GetPosition(1, 0)) && v.Equals(_grid.GetPosition(2, 0))) ||
               (v.Equals(_grid.GetPosition(0, 1)) && v.Equals(_grid.GetPosition(1, 1)) && v.Equals(_grid.GetPosition(2, 1))) ||
               (v.Equals(_grid.GetPosition(0, 2)) && v.Equals(_grid.GetPosition(1, 2)) && v.Equals(_grid.GetPosition(2, 2))) ||
               (v.Equals(_grid.GetPosition(0, 0)) && v.Equals(_grid.GetPosition(1, 1)) && v.Equals(_grid.GetPosition(2, 2))) ||
               (v.Equals(_grid.GetPosition(1, 0)) && v.Equals(_grid.GetPosition(1, 1)) && v.Equals(_grid.GetPosition(1, 2))) ||
               (v.Equals(_grid.GetPosition(2, 0)) && v.Equals(_grid.GetPosition(2, 1)) && v.Equals(_grid.GetPosition(2, 2))) ||
               (v.Equals(_grid.GetPosition(0, 0)) && v.Equals(_grid.GetPosition(1, 1)) && v.Equals(_grid.GetPosition(2, 2))) ||
               (v.Equals(_grid.GetPosition(2, 0)) && v.Equals(_grid.GetPosition(1, 1)) && v.Equals(_grid.GetPosition(0, 2)));
    }

    private bool VerifEgalite()
    {
        return _grid.GetPosition(0, 0) == null && _grid.GetPosition(1, 0) == null && _grid.GetPosition(2, 0) == null &&
               _grid.GetPosition(0, 1) == null && _grid.GetPosition(1, 1) == null && _grid.GetPosition(2, 1) == null &&
               _grid.GetPosition(0, 2) == null && _grid.GetPosition(1, 2) == null && _grid.GetPosition(2, 2) == null;
    }


    public void FinPartie(string msg)
    {
        _gui.ShowGrid(_grid);
        _gui.ShowMessage(msg);
    }
}