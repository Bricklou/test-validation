using PuissanceQuatre.Common;

namespace PuissanceQuatre.TikTakToe;

public class TikTakToeCaseFactory
{
    public static TikTakToeCaseX CreateCaseX()
    {
        return new TikTakToeCaseX();
    }

    public static TikTakToeCaseO CreateCaseO()
    {
        return new TikTakToeCaseO();
    }

    public static Grid<AbstractTikTakToeCase> CreateTikTakToeGrid()
    {
        return new Grid<AbstractTikTakToeCase>(3, 3);
    }
}