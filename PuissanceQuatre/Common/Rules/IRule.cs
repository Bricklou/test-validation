namespace PuissanceQuatre.Common.Rules;

public interface IRule<TCase> where TCase : AbstractCase
{
    public bool Check(Grid<TCase> grid, uint x, uint y);
}