using PuissanceQuatre.Common;

namespace PuissanceQuatre.Power4;

public class Power4CaseFactory
{
    public static Power4CaseX CreateCross()
    {
        return new Power4CaseX();
    }

    public static Power4CaseO CreateCircle()
    {
        return new Power4CaseO();
    }

    public static Grid<AbstractPower4Case> CreatePower4Grid()
    {
        return new Grid<AbstractPower4Case>(7, 4);
    }
}