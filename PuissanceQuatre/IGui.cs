namespace MorpionApp;

public abstract class IGui<TEnumType> where TEnumType : struct, Enum
{
    protected readonly Dictionary<TEnumType, string> DisplayValues;
    
    public IGui(Dictionary<TEnumType, string> displayValues)
    {
        DisplayValues = displayValues;
    }
    
    public abstract void ShowGrid(Grid<TEnumType> grid);
    public abstract void ShowMessage(string message);
}