namespace MorpionApp;

public abstract class AbstractMorpionCase : AbstractCase
{
    protected AbstractMorpionCase(string name) : base(name)
    {
    }
}

public class MorpionCaseX : AbstractMorpionCase
{
    public MorpionCaseX() : base("X")
    {
    }
}

public class MorpionCaseO : AbstractMorpionCase
{
    public MorpionCaseO() : base("O")
    {
    }
}