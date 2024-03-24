namespace SimulationCredits;

public class Credit
{
    private const int MonthPerYear = 12;

    public Credit(int amount, int duration, double rate)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(amount, 50_000);

        if (duration is < 9 * MonthPerYear or > 25 * MonthPerYear)
            throw new ArgumentOutOfRangeException(nameof(duration));

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rate);

        Amount = amount;
        Duration = duration;
        Rate = rate;
    }

    public int Amount { get; }
    public int Duration { get; }
    public double Rate { get; }
}