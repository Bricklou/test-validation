using PuissanceQuatre.Common;

namespace PuissanceQuatre.TikTakToe;

public abstract class AbstractTikTakToeCase : AbstractCase
{
    protected AbstractTikTakToeCase(string name) : base(name)
    {
    }
}

public class TikTakToeCaseX : AbstractTikTakToeCase
{
    public TikTakToeCaseX() : base("X")
    {
    }
}

public class TikTakToeCaseO : AbstractTikTakToeCase
{
    public TikTakToeCaseO() : base("O")
    {
    }
}