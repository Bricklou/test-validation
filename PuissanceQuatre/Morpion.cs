using System.ComponentModel;

namespace MorpionApp;

public enum MorpionEnum
{
    PlayerX,
    PlayerO
}

public class Morpion
{
    public Grid<MorpionEnum> grille;
    public bool quiterJeu;
    public bool tourDuJoueur = true;

    public void BoucleJeu()
    {
        while (!quiterJeu)
        {
            grille = new Grid<MorpionEnum>(3, 3);

            while (!quiterJeu)
            {
                if (tourDuJoueur)
                {
                    tourJoueur();
                    if (verifVictoire(MorpionEnum.PlayerX))
                    {
                        finPartie("Le joueur 1 à gagné !");
                        break;
                    }
                }
                else
                {
                    tourJoueur2();
                    if (verifVictoire(MorpionEnum.PlayerO))
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
                    if (column >= 2)
                        column = 0;
                    else
                        column = column + 1;
                    break;

                case ConsoleKey.LeftArrow:
                    if (column <= 0)
                        column = 2;
                    else
                        column = column - 1;
                    break;

                case ConsoleKey.UpArrow:
                    if (row <= 0)
                        row = 2;
                    else
                        row = row - 1;
                    break;

                case ConsoleKey.DownArrow:
                    if (row >= 2)
                        row = 0;
                    else
                        row = row + 1;
                    break;
                case ConsoleKey.Enter:
                    if (grille.GetPosition(row, column) is null)
                    {
                        grille.SetPosition(row, column, MorpionEnum.PlayerX);
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
                    if (column >= 2)
                        column = 0;
                    else
                        column = column + 1;
                    break;

                case ConsoleKey.LeftArrow:
                    if (column <= 0)
                        column = 2;
                    else
                        column = column - 1;
                    break;

                case ConsoleKey.UpArrow:
                    if (row <= 0)
                        row = 2;
                    else
                        row = row - 1;
                    break;

                case ConsoleKey.DownArrow:
                    if (row >= 2)
                        row = 0;
                    else
                        row = row + 1;
                    break;
                case ConsoleKey.Enter:
                    if (grille.GetPosition(row, column) is null)
                    {
                        grille.SetPosition(row, column, MorpionEnum.PlayerO);
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
        for (uint i = 0; i < grille.Height; i++)
        {
            // Draw a first empty grid line with the values
            for (uint j = 0; j < grille.Width; j++)
            {
                var symbol = " ";
                var position = grille.GetPosition(i, j);
                if (position is not null)
                {
                    symbol = position == MorpionEnum.PlayerX ? "X" : "O";
                }
                
                Console.Write($" {symbol}  ");

                if (j < grille.Width - 1)
                {
                    Console.Write("|");
                }
            }

            Console.WriteLine();

            // Draw a second grid line 
            for (uint j = 0; j < grille.Width; j++)
            {
                Console.Write(new string(' ', 4));
                if (j < grille.Width - 1)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            if (i < grille.Height - 1)
            {
                Console.WriteLine(new string('-', (int)(grille.Width * 5)));
            }
        }
        Console.WriteLine();
    }

    public bool verifVictoire(MorpionEnum v)
    {
        return grille.GetPosition(0, 0) == v && grille.GetPosition(1, 0) == v && grille.GetPosition(2, 0) == v ||
               grille.GetPosition(0, 1) == v && grille.GetPosition(1, 1) == v && grille.GetPosition(2, 1) == v ||
               grille.GetPosition(0, 2) == v && grille.GetPosition(1, 2) == v && grille.GetPosition(2, 2) == v ||
               grille.GetPosition(0, 0) == v && grille.GetPosition(1, 1) == v && grille.GetPosition(2, 2) == v ||
               grille.GetPosition(1, 0) == v && grille.GetPosition(1, 1) == v && grille.GetPosition(1, 2) == v ||
               grille.GetPosition(2, 0) == v && grille.GetPosition(2, 1) == v && grille.GetPosition(2, 2) == v ||
               grille.GetPosition(0, 0) == v && grille.GetPosition(1, 1) == v && grille.GetPosition(2, 2) == v ||
               grille.GetPosition(2, 0) == v && grille.GetPosition(1, 1) == v && grille.GetPosition(0, 2) == v;
    }

    public bool verifEgalite()
    {
        return grille.GetPosition(0, 0) == null && grille.GetPosition(1, 0) == null && grille.GetPosition(2, 0) == null &&
               grille.GetPosition(0, 1) == null && grille.GetPosition(1, 1) == null && grille.GetPosition(2, 1) == null &&
               grille.GetPosition(0, 2) == null && grille.GetPosition(1, 2) == null && grille.GetPosition(2, 2) == null;
    }


    public void finPartie(string msg)
    {
        Console.Clear();
        affichePlateau();
        Console.WriteLine(msg);
    }
}