namespace MorpionApp;

public abstract class AbstractPuissanceQuatreCase : AbstractCase
{
    protected AbstractPuissanceQuatreCase(string name) : base(name)
    {
    }
}

public class PuissanceQuatreCaseX : AbstractPuissanceQuatreCase
{
    public PuissanceQuatreCaseX() : base("X")
    {
    }
}

public class PuissanceQuatreCaseO : AbstractPuissanceQuatreCase
{
    public PuissanceQuatreCaseO() : base("O")
    {
    }
}