namespace SimulationCredits;

public class Credit
{
    public int Amount { get; }
    public int Duration { get; }
    public double Rate { get; }

    public Credit(int amount, int duration, double rate)
    {
        if (amount <= 50_000 || duration < 0 || duration > 25 || rate <= 0)
        {
            throw new ArgumentOutOfRangeException("Arguments are out of range");
        }

        Amount = amount;
        Duration = duration;
        Rate = rate;
    }
}