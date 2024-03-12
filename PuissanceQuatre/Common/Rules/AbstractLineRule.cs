namespace PuissanceQuatre.Common.Rules;

public abstract class AbstractLineRule<TCase> : IRule<TCase> where TCase : AbstractCase
{
    protected uint Length;

    public AbstractLineRule(uint length)
    {
        Length = length;
    }

    public abstract bool Check(Grid<TCase> grid, uint x, uint y);
}