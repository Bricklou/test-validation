namespace MorpionApp;

public class PuissanceQuatre
{
    public Grid<AbstractPuissanceQuatreCase> grille;
    public bool quiterJeu;
    public bool tourDuJoueur = true;

    public void BoucleJeu()
    {
        while (!quiterJeu)
        {
            grille = new Grid<AbstractPuissanceQuatreCase>(4, 7);

            while (!quiterJeu)
            {
                if (tourDuJoueur)
                {
                    tourJoueur();
                    if (verifVictoire(PuissanceQuatreCaseFactory.CreateCross()))
                    {
                        finPartie("Le joueur 1 à gagné !");
                        break;
                    }
                }
                else
                {
                    tourJoueur2();
                    if (verifVictoire(PuissanceQuatreCaseFactory.CreateCircle()))
                    {
                        finPartie("Le joueur 2 à gagné !");
                        break;
                    }
                }

                tourDuJoueur = !tourDuJoueur;
                if (verifEgalite())
                {
                    finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                    break;
                }
            }

            if (!quiterJeu)
            {
                Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                GetKey:
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Console.Clear();
                        break;
                    default:
                        goto GetKey;
                }
            }
        }
    }

    public void tourJoueur()
    {
        var (row, column) = (0u, 0u);
        var moved = false;

        while (!quiterJeu && !moved)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine();
            Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
            Console.SetCursorPosition((int)(column * 6 + 1), (int)(row * 4 + 1));

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:
                    quiterJeu = true;
                    Console.Clear();
                    break;

                case ConsoleKey.RightArrow:
                    if (column >= 6)
                        column = 0;
                    else
                        column = column + 1;
                    break;

                case ConsoleKey.LeftArrow:
                    if (column <= 0)
                        column = 6;
                    else
                        column = column - 1;
                    break;

                case ConsoleKey.Enter:
                    while (row <= 3)
                    {
                        row = row + 1;
                        if (row >= 3) break;
                    }

                    var position = grille.GetPosition(row, column);
                    while (position is not null)
                    {
                        if (row == 0) break;

                        row = row - 1;
                        position = grille.GetPosition(row, column);
                    }

                    if (position is null)
                    {
                        grille.SetPosition(row, column, PuissanceQuatreCaseFactory.CreateCross());
                        moved = true;
                        quiterJeu = false;
                    }

                    break;
            }
        }
    }

    public void tourJoueur2()
    {
        var (row, column) = (0u, 0u);
        var moved = false;

        while (!quiterJeu && !moved)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine();
            Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
            Console.SetCursorPosition((int)(column * 6 + 1), (int)(row * 4 + 1));

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:
                    quiterJeu = true;
                    Console.Clear();
                    break;

                case ConsoleKey.RightArrow:
                    if (column >= 6)
                        column = 0;
                    else
                        column = column + 1;
                    break;

                case ConsoleKey.LeftArrow:
                    if (column <= 0)
                        column = 6;
                    else
                        column = column - 1;
                    break;

                //case ConsoleKey.UpArrow:
                //    if (row <= 0)
                //    {
                //        row = 3;
                //    }
                //    else
                //    {
                //        row = row - 1;
                //    }
                //    break;

                //case ConsoleKey.DownArrow:
                //    if (row >= 3)
                //    {
                //        row = 0;
                //    }
                //    else
                //    {
                //        row = row + 1;
                //    }
                //    break;
                case ConsoleKey.Enter:
                    while (row <= 3)
                    {
                        row = row + 1;
                        if (row >= 3) break;
                    }

                    var position = grille.GetPosition(row, column);
                    while (position is not null)
                    {
                        if (row == 0) break;

                        row = row - 1;
                        position = grille.GetPosition(row, column);
                    }

                    if (position is null)
                    {
                        grille.SetPosition(row, column, PuissanceQuatreCaseFactory.CreateCircle());
                        moved = true;
                        quiterJeu = false;
                    }

                    break;
            }
        }
    }

    public void affichePlateau()
    {
        Console.WriteLine();

        for (var i = 0; i < grille.Height; i++)
        {
            for (var j = 0; j < grille.Width; j++)
            {
                var symbol = " ";
                var position = grille.GetPosition((uint)i, (uint)j);
                if (position is not null) symbol = position.DisplayName();

                Console.Write($"  {symbol}  ");

                if (j < grille.Width - 1) Console.Write("|");
            }

            Console.WriteLine();
            if (i < grille.Height - 1) Console.WriteLine("-----+-----+-----+-----+-----+-----+-----");
        }
    }

    public bool verifVictoire(AbstractPuissanceQuatreCase c)
    {
        return (grille.GetPosition(0, 0) == c && grille.GetPosition(1, 0) == c && grille.GetPosition(2, 0) == c &&
                grille.GetPosition(3, 0) == c) ||
               (grille.GetPosition(0, 1) == c && grille.GetPosition(1, 1) == c && grille.GetPosition(2, 1) == c &&
                grille.GetPosition(3, 1) == c) ||
               (grille.GetPosition(0, 2) == c && grille.GetPosition(1, 2) == c && grille.GetPosition(2, 2) == c &&
                grille.GetPosition(3, 2) == c) ||
               (grille.GetPosition(0, 3) == c && grille.GetPosition(1, 3) == c && grille.GetPosition(2, 3) == c &&
                grille.GetPosition(3, 3) == c) ||
               (grille.GetPosition(0, 4) == c && grille.GetPosition(1, 4) == c && grille.GetPosition(2, 4) == c &&
                grille.GetPosition(3, 4) == c) ||
               (grille.GetPosition(0, 5) == c && grille.GetPosition(1, 5) == c && grille.GetPosition(2, 5) == c &&
                grille.GetPosition(3, 5) == c) ||
               (grille.GetPosition(0, 6) == c && grille.GetPosition(1, 6) == c && grille.GetPosition(2, 6) == c &&
                grille.GetPosition(3, 6) == c) ||
               (grille.GetPosition(0, 0) == c && grille.GetPosition(0, 1) == c && grille.GetPosition(0, 2) == c &&
                grille.GetPosition(0, 3) == c) ||
               (grille.GetPosition(0, 1) == c && grille.GetPosition(0, 2) == c && grille.GetPosition(0, 3) == c &&
                grille.GetPosition(0, 4) == c) ||
               (grille.GetPosition(0, 2) == c && grille.GetPosition(0, 3) == c && grille.GetPosition(0, 3) == c &&
                grille.GetPosition(0, 5) == c) ||
               (grille.GetPosition(0, 3) == c && grille.GetPosition(0, 4) == c && grille.GetPosition(0, 5) == c &&
                grille.GetPosition(0, 6) == c) ||
               (grille.GetPosition(1, 0) == c && grille.GetPosition(1, 1) == c && grille.GetPosition(1, 2) == c &&
                grille.GetPosition(1, 3) == c) ||
               (grille.GetPosition(1, 1) == c && grille.GetPosition(1, 2) == c && grille.GetPosition(1, 3) == c &&
                grille.GetPosition(1, 4) == c) ||
               (grille.GetPosition(1, 2) == c && grille.GetPosition(1, 3) == c && grille.GetPosition(1, 4) == c &&
                grille.GetPosition(1, 5) == c) ||
               (grille.GetPosition(1, 4) == c && grille.GetPosition(1, 4) == c && grille.GetPosition(1, 5) == c &&
                grille.GetPosition(1, 6) == c) ||
               (grille.GetPosition(2, 0) == c && grille.GetPosition(2, 1) == c && grille.GetPosition(2, 2) == c &&
                grille.GetPosition(2, 3) == c) ||
               (grille.GetPosition(2, 1) == c && grille.GetPosition(2, 2) == c && grille.GetPosition(2, 3) == c &&
                grille.GetPosition(2, 4) == c) ||
               (grille.GetPosition(2, 2) == c && grille.GetPosition(2, 3) == c && grille.GetPosition(2, 3) == c &&
                grille.GetPosition(2, 5) == c) ||
               (grille.GetPosition(2, 3) == c && grille.GetPosition(2, 4) == c && grille.GetPosition(2, 5) == c &&
                grille.GetPosition(2, 6) == c) ||
               (grille.GetPosition(3, 0) == c && grille.GetPosition(3, 1) == c && grille.GetPosition(3, 2) == c &&
                grille.GetPosition(3, 3) == c) ||
               (grille.GetPosition(3, 1) == c && grille.GetPosition(3, 2) == c && grille.GetPosition(3, 3) == c &&
                grille.GetPosition(3, 4) == c) ||
               (grille.GetPosition(3, 2) == c && grille.GetPosition(3, 3) == c && grille.GetPosition(3, 4) == c &&
                grille.GetPosition(3, 5) == c) ||
               (grille.GetPosition(3, 3) == c && grille.GetPosition(3, 4) == c && grille.GetPosition(3, 5) == c &&
                grille.GetPosition(3, 6) == c) ||
               (grille.GetPosition(0, 0) == c && grille.GetPosition(1, 1) == c && grille.GetPosition(2, 2) == c &&
                grille.GetPosition(3, 3) == c) ||
               (grille.GetPosition(0, 1) == c && grille.GetPosition(1, 2) == c && grille.GetPosition(2, 3) == c &&
                grille.GetPosition(3, 4) == c) ||
               (grille.GetPosition(0, 2) == c && grille.GetPosition(1, 3) == c && grille.GetPosition(2, 4) == c &&
                grille.GetPosition(3, 5) == c) ||
               (grille.GetPosition(0, 3) == c && grille.GetPosition(1, 4) == c && grille.GetPosition(2, 5) == c &&
                grille.GetPosition(3, 6) == c) ||
               (grille.GetPosition(0, 3) == c && grille.GetPosition(1, 2) == c && grille.GetPosition(2, 1) == c &&
                grille.GetPosition(3, 0) == c) ||
               (grille.GetPosition(0, 4) == c && grille.GetPosition(1, 4) == c && grille.GetPosition(2, 2) == c &&
                grille.GetPosition(3, 1) == c) ||
               (grille.GetPosition(0, 5) == c && grille.GetPosition(1, 3) == c && grille.GetPosition(2, 3) == c &&
                grille.GetPosition(3, 2) == c) ||
               (grille.GetPosition(0, 6) == c && grille.GetPosition(1, 5) == c && grille.GetPosition(2, 4) == c &&
                grille.GetPosition(3, 3) == c);
    }

    public bool verifEgalite()
    {
        return grille.GetPosition(0, 0) != null && grille.GetPosition(0, 1) != null &&
               grille.GetPosition(0, 2) != null && grille.GetPosition(0, 3) != null &&
               grille.GetPosition(0, 4) != null && grille.GetPosition(0, 5) != null &&
               grille.GetPosition(0, 6) != null &&
               grille.GetPosition(1, 0) != null && grille.GetPosition(1, 1) != null &&
               grille.GetPosition(1, 2) != null && grille.GetPosition(1, 3) != null &&
               grille.GetPosition(1, 4) != null && grille.GetPosition(1, 5) != null &&
               grille.GetPosition(1, 6) != null &&
               grille.GetPosition(2, 0) != null && grille.GetPosition(2, 1) != null &&
               grille.GetPosition(1, 2) != null && grille.GetPosition(2, 3) != null &&
               grille.GetPosition(2, 4) != null && grille.GetPosition(2, 5) != null &&
               grille.GetPosition(2, 6) != null &&
               grille.GetPosition(3, 0) != null && grille.GetPosition(3, 1) != null &&
               grille.GetPosition(3, 2) != null && grille.GetPosition(3, 3) != null &&
               grille.GetPosition(3, 4) != null && grille.GetPosition(3, 5) != null && grille.GetPosition(3, 5) != null;
    }


    public void finPartie(string msg)
    {
        Console.Clear();
        affichePlateau();
        Console.WriteLine(msg);
    }
}