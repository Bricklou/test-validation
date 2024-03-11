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
}