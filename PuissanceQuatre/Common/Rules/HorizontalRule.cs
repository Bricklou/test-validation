namespace PuissanceQuatre.Common.Rules;

public class HorizontalRule<TCase> : AbstractLineRule<TCase> where TCase : AbstractCase
{
    public HorizontalRule(uint length) : base(length)
    {
    }

    public override bool Check(Grid<TCase> grid, uint x, uint y)
    {
        // Check for a win in the horizontal direction
        if (CheckLine(grid, x, y)) return true;

        // Check for a win in the reverse horizontal direction
        if (CheckLine(grid, x, y, true)) return true;

        return false;
    }

    private bool CheckLine(Grid<TCase> grid, uint x, uint y, bool reverse = false)
    {
        var currentSymbol = grid.GetPosition(x, y);
        if (x >= grid.Width || currentSymbol is null) return false;

        var counter = 0;

        while (counter < Length)
        {
            var relativeX = (int)(x + counter * (reverse ? -1 : 1));
            if (relativeX < 0 || relativeX >= grid.Width) break;

            var offsetSymbol = grid.GetPosition((uint)relativeX, y);
            if (offsetSymbol is null || !offsetSymbol.Equals(currentSymbol)) break;

            counter++;
        }

        return counter >= Length;
    }
}