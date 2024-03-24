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

        if (amount <= 50_000 || duration < 0 || duration > 25 || rate <= 0)
        {
            throw new ArgumentOutOfRangeException("Arguments are out of range");
        }
    }
}