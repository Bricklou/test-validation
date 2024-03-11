using PuissanceQuatre.Common;

namespace PuissanceQuatre.Power4;

public abstract class AbstractPower4Case : AbstractCase
{
    protected AbstractPower4Case(string name) : base(name)
    {
    }
}

public class Power4CaseX : AbstractPower4Case
{
    public Power4CaseX() : base("X")
    {
    }
}

public class Power4CaseO : AbstractPower4Case
{
    public Power4CaseO() : base("O")
    {
    }
}