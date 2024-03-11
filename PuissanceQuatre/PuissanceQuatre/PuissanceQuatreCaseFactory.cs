namespace MorpionApp;

public class PuissanceQuatreCaseFactory
{
    public static PuissanceQuatreCaseX CreateCross()
    {
        return new PuissanceQuatreCaseX();
    }
    
    public static PuissanceQuatreCaseO CreateCircle()
    {
        return new PuissanceQuatreCaseO();
    }
}