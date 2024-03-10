using System.ComponentModel;

namespace MorpionApp;

public enum MorpionEnum
{
    PlayerX,
    PlayerO
}

public class Morpion
{
    public Grid<MorpionEnum> grid;
    public ConsoleGui<MorpionEnum> gui = new(
        new Dictionary<MorpionEnum, string>()
        {
            { MorpionEnum.PlayerO , "O"},
            { MorpionEnum.PlayerX , "X" }
        }
    );
    public bool quiterJeu;
    public bool tourDuJoueur = true;

    public void BoucleJeu()
    {
        while (!quiterJeu)
        {
            grid = new Grid<MorpionEnum>(3, 3);

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
                gui.ShowMessage("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                var invalidKey = true;
                while (invalidKey)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            quiterJeu = true;
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

    public void tourJoueur()
    {
        var (row, column) = (0u, 0u);
        var moved = false;

        while (!quiterJeu && !moved)
        {
            gui.ShowGrid(grid);
            gui.ShowMessage("Choisir une case valide et appuyez sur [Entrer]");
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
                    if (grid.GetPosition(row, column) is null)
                    {
                        grid.SetPosition(row, column, MorpionEnum.PlayerX);
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
            gui.ShowGrid(grid);
            gui.ShowMessage("Choisir une case valide et appuyez sur [Entrer]");
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
                    if (grid.GetPosition(row, column) is null)
                    {
                        grid.SetPosition(row, column, MorpionEnum.PlayerO);
                        moved = true;
                        quiterJeu = false;
                    }

                    break;
            }
        }
    }

    public bool verifVictoire(MorpionEnum v)
    {
        return grid.GetPosition(0, 0) == v && grid.GetPosition(1, 0) == v && grid.GetPosition(2, 0) == v ||
               grid.GetPosition(0, 1) == v && grid.GetPosition(1, 1) == v && grid.GetPosition(2, 1) == v ||
               grid.GetPosition(0, 2) == v && grid.GetPosition(1, 2) == v && grid.GetPosition(2, 2) == v ||
               grid.GetPosition(0, 0) == v && grid.GetPosition(1, 1) == v && grid.GetPosition(2, 2) == v ||
               grid.GetPosition(1, 0) == v && grid.GetPosition(1, 1) == v && grid.GetPosition(1, 2) == v ||
               grid.GetPosition(2, 0) == v && grid.GetPosition(2, 1) == v && grid.GetPosition(2, 2) == v ||
               grid.GetPosition(0, 0) == v && grid.GetPosition(1, 1) == v && grid.GetPosition(2, 2) == v ||
               grid.GetPosition(2, 0) == v && grid.GetPosition(1, 1) == v && grid.GetPosition(0, 2) == v;
    }

    public bool verifEgalite()
    {
        return grid.GetPosition(0, 0) == null && grid.GetPosition(1, 0) == null && grid.GetPosition(2, 0) == null &&
               grid.GetPosition(0, 1) == null && grid.GetPosition(1, 1) == null && grid.GetPosition(2, 1) == null &&
               grid.GetPosition(0, 2) == null && grid.GetPosition(1, 2) == null && grid.GetPosition(2, 2) == null;
    }


    public void finPartie(string msg)
    {
        gui.ShowGrid(grid);
        gui.ShowMessage(msg);
    }
}