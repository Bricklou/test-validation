namespace MorpionApp;

public class ConsoleGui<TEnumType> : IGui<TEnumType>
    where TEnumType : struct, Enum
{
    public ConsoleGui(Dictionary<TEnumType, string> displayValues) : base(displayValues)
    {
    }

    public override void ShowGrid(Grid<TEnumType> grid)
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
                if (position is not null)
                {
                    symbol = DisplayValues[position.Value];
                }
                
                Console.Write($" {symbol}  ");

                if (j < grid.Width - 1)
                {
                    Console.Write("|");
                }
            }

            Console.WriteLine();

            // Draw a second grid line 
            for (uint j = 0; j < grid.Width; j++)
            {
                Console.Write(new string(' ', 4));
                if (j < grid.Width - 1)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            if (i < grid.Height - 1)
            {
                Console.WriteLine(new string('-', (int)(grid.Width * 5)));
            }
        }
        Console.WriteLine();
    }

    public override void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}