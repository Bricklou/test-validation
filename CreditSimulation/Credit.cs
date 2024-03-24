namespace SimulationCredits;

public class Credit
{
    private const int MonthPerYear = 12;
    public int TotalAmount { get; }
    public double PaidAmount { get; private set; } = 0;
    public double RemainingAmount => TotalAmount - PaidAmount;

    public int Duration { get; }
    public int RemainingDuration { get; private set; }
    public double Rate { get; }

    public Credit(int totalAmount, int duration, double rate)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(totalAmount, 50_000);

        if (duration is < 9 * MonthPerYear or > 25 * MonthPerYear)
            throw new ArgumentOutOfRangeException(nameof(duration));

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rate);

        TotalAmount = totalAmount;
        Duration = duration;
        RemainingDuration = duration;
        Rate = rate;
    }
    
    public void Pay(double amount, int months = 1)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(amount, RemainingAmount);
        
        PaidAmount += amount;
        RemainingDuration -= months;
    }
}