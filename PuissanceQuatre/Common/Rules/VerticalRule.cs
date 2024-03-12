namespace PuissanceQuatre.Common.Rules;

public class VerticalRule<TCase> : AbstractLineRule<TCase> where TCase : AbstractCase
{
    public VerticalRule(uint length) : base(length)
    {
    }

    public override bool Check(Grid<TCase> grid, uint x, uint y)
    {
        // Check for a win in the vertical direction
        if (CheckColumn(grid, x, y)) return true;

        // Check for a win in the reverse vertical direction
        if (CheckColumn(grid, x, y, true)) return true;

        return false;
    }

    private bool CheckColumn(Grid<TCase> grid, uint x, uint y, bool reverse = false)
    {
        var currentSymbol = grid.GetPosition(x, y);
        if (y >= grid.Height || currentSymbol is null) return false;

        var counter = 0;

        while (counter < Length)
        {
            var relativeY = (int)(y + counter * (reverse ? -1 : 1));
            if (relativeY < 0 || relativeY >= grid.Height) break;

            var offsetSymbol = grid.GetPosition(x, (uint)relativeY);
            if (offsetSymbol is null || !offsetSymbol.Equals(currentSymbol)) break;

            counter++;
        }

        return counter >= Length;
    }
}