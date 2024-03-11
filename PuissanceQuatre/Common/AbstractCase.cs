namespace MorpionApp;

public abstract class AbstractCase
{
    protected readonly string Name;

    protected AbstractCase(string name)
    {
        Name = name;
    }

    public string DisplayName()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is AbstractCase other)
        {
            return other.Name == Name;
        }

        return false;
    }

    protected bool Equals(AbstractCase other)
    {
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}