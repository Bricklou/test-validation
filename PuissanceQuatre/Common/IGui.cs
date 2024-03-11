namespace MorpionApp;

public abstract class IGui<TCase> where TCase : AbstractCase
{
    public abstract void ShowGrid(Grid<TCase> grid);
    public abstract void ShowMessage(string message);
}