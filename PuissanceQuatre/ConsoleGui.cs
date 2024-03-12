using PuissanceQuatre.Common;

namespace PuissanceQuatre;

public class ConsoleGui<TCase> : IGui<TCase>
    where TCase : AbstractCase
{
    public override void ShowGrid(Grid<TCase> grid)
    {
        Console.Clear();
        Console.WriteLine();
        for (uint y = 0; y < grid.Height; y++)
        {
            // Draw a first empty grid line with the values
            for (uint x = 0; x < grid.Width; x++)
            {
                var symbol = " ";
                var position = grid.GetPosition(x, y);
                if (position is not null) symbol = position.DisplayName();

                Console.Write($" {symbol}  ");

                if (x < grid.Width - 1) Console.Write("|");
            }

            Console.WriteLine();

            // Draw a second grid line 
            for (uint j = 0; j < grid.Width; j++)
            {
                Console.Write(new string(' ', 4));
                if (j < grid.Width - 1) Console.Write("|");
            }

            Console.WriteLine();
            if (y < grid.Height - 1) Console.WriteLine(new string('-', (int)(grid.Width * 5)));
        }

        Console.WriteLine();
    }

    public override void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public override (uint, uint) AskForPosition(Grid<TCase> grid)
    {
        var (x, y) = (0u, 0u);
        var invalidKey = true;

        while (invalidKey)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.RightArrow:
                    if (x < grid.Width - 1)
                        x += 1;
                    break;

                case ConsoleKey.LeftArrow:
                    if (x > 0)
                        x -= 1;
                    break;

                case ConsoleKey.UpArrow:
                    if (y > 0)
                        y -= 1;
                    break;

                case ConsoleKey.DownArrow:
                    if (y < grid.Height - 1)
                        y += 1;
                    break;

                case ConsoleKey.Enter:
                    if (grid.GetPosition(x, y) is null) invalidKey = false;
                    break;

                default:
                    invalidKey = true;
                    break;
            }

            UpdateCursorPosition(x, y);
        }

        return (x, y);
    }

    private static void UpdateCursorPosition(uint x, uint y)
    {
        Console.SetCursorPosition((int)(x * 5 + 1), (int)(y * 3 + 1));
    }
}