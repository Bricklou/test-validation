using PuissanceQuatre.Common;

namespace PuissanceQuatre;

public class ConsoleGui<TCase> : IGui<TCase>
    where TCase : AbstractCase
{
    public override void ShowGrid(Grid<TCase> grid)
    {
        Console.Clear();
        Console.WriteLine();
        for (uint i = 0; i < grid.Height; i++)
        {
            // Draw a first empty grid line with the values
            for (uint j = 0; j < grid.Width; j++)
            {
                var symbol = " ";
                var position = grid.GetPosition(i, j);
                if (position is not null) symbol = position.DisplayName();

                Console.Write($" {symbol}  ");

                if (j < grid.Width - 1) Console.Write("|");
            }

            Console.WriteLine();

            // Draw a second grid line 
            for (uint j = 0; j < grid.Width; j++)
            {
                Console.Write(new string(' ', 4));
                if (j < grid.Width - 1) Console.Write("|");
            }

            Console.WriteLine();
            if (i < grid.Height - 1) Console.WriteLine(new string('-', (int)(grid.Width * 5)));
        }

        Console.WriteLine();
    }

    public override void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public override (uint, uint) AskForPosition(Grid<TCase> grid)
    {
        var (row, column) = (0u, 0u);
        var invalidKey = true;

        while (invalidKey)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.RightArrow:
                    if (column < grid.Width - 1)
                        column += 1;
                    break;

                case ConsoleKey.LeftArrow:
                    if (column > 0)
                        column -= 1;
                    break;

                case ConsoleKey.UpArrow:
                    if (row > 0)
                        row -= 1;
                    break;

                case ConsoleKey.DownArrow:
                    if (row < grid.Height - 1)
                        row += 1;
                    break;

                case ConsoleKey.Enter:
                    if (grid.GetPosition(row, column) is null) invalidKey = false;
                    break;

                default:
                    invalidKey = true;
                    break;
            }

            UpdateCursorPosition(row, column);
        }

        return (row, column);
    }

    private static void UpdateCursorPosition(uint row, uint column)
    {
        Console.SetCursorPosition((int)(column * 5 + 1), (int)(row * 3 + 1));
    }
}