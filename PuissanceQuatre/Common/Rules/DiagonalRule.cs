namespace PuissanceQuatre.Common.Rules;

public class DiagonalRule<TCase> : AbstractLineRule<TCase> where TCase : AbstractCase
{
    public DiagonalRule(uint length) : base(length)
    {
    }

    public override bool Check(Grid<TCase> grid, uint x, uint y)
    {
        // Check the grid for a diagonal to bottom right
        if (CheckDiagonal(grid, x, y, 1, 1)) return true;


        // Check the grid for a diagonal to top right
        if (CheckDiagonal(grid, x, y, -1, 1)) return true;

        // Check the grid for a diagonal to bottom left
        if (CheckDiagonal(grid, x, y, 1, -1)) return true;

        // Check the grid for a diagonal to top left
        if (CheckDiagonal(grid, x, y, -1, -1)) return true;

        return false;
    }

    private bool CheckDiagonal(Grid<TCase> grid, uint x, uint y, int xDirection, int yDirection)
    {
        uint counter = 0;

        var currentSymbol = grid.GetPosition(x, y);

        if (currentSymbol is null) return false;

        while (counter < Length)
        {
            var relativeX = (int)(x + counter * xDirection);
            var relativeY = (int)(y + counter * yDirection);

            if (relativeX < 0 || relativeY < 0 || relativeX >= grid.Height || relativeY >= grid.Width)
            {
                counter = 0;
                break;
            }

            var offsetSymbol = grid.GetPosition((uint)relativeX, (uint)relativeY);

            if (offsetSymbol is null || !offsetSymbol.Equals(currentSymbol))
            {
                counter = 0;
                break;
            }

            counter++;
        }

        return counter >= Length;
    }
}