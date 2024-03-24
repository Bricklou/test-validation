namespace SimulationCredits;

public class ArgumentsParser
{
    public void Parse(string[] args)
    {
        if (args.Length != 3)
        {
            throw new ArgumentException("Arguments parser accept only 3 parameters");
        }


        if (
            !int.TryParse(args[0], out var amount) ||
            !int.TryParse(args[1], out var duration) ||
            !double.TryParse(args[2], out var rate)
        )
        {
            throw new ArgumentException("Argument parser accept only numbers");
        }
    }
}