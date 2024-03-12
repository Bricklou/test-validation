using PuissanceQuatre.Common.Rules;

namespace PuissanceQuatre.Common;

public class AbstractBoardGame<TCase> where TCase : AbstractCase
{
    protected Grid<TCase> _grid;
    protected IRule<TCase>[] Rules;

    public AbstractBoardGame(Grid<TCase> grid, IRule<TCase>[] rules)
    {
        _grid = grid;
        Rules = rules;
    }

    protected bool CheckVictory(TCase symbol, uint x, uint y)
    {
        return Rules.Any(rule => rule.Check(_grid, x, y));
    }
    
    protected bool CheckTie()
    {
        return _grid.IsFull();
    }
}