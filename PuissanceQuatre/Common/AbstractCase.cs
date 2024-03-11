namespace MorpionApp;

public abstract class AbstractCase
{
    protected string Name;

    protected AbstractCase(string name)
    {
        Name = name;
    }

    public string DisplayName()
    {
        return Name;
    }
}