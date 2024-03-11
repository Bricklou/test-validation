namespace MorpionApp;

public class MorpionCaseFactory
{
    public static MorpionCaseX CreateCaseX()
    {
        return new MorpionCaseX();
    }

    public static MorpionCaseO CreateCaseO()
    {
        return new MorpionCaseO();
    }
}