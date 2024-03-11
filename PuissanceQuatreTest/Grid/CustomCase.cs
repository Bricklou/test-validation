using PuissanceQuatre.Common;

namespace PuissanceQuatreTest.Grid;

public abstract class AbstractCustomCase : AbstractCase
{
    protected AbstractCustomCase(string name) : base(name)
    {
    }
}

public class CustomCaseX : AbstractCustomCase
{
    public CustomCaseX() : base("X")
    {
    }
}

public class CustomCaseO : AbstractCustomCase
{
    public CustomCaseO() : base("O")
    {
    }
}