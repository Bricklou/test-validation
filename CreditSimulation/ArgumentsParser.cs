namespace SimulationCredits;

public class ArgumentsParser
{
    public void Parse(string[] args)
    {
        if (args.Length != 3)
        {
            throw new ArgumentException("Arguments parser accept only 3 parameters");
        }
    }
}