namespace SimulationCredits;

public class Credit
{
    private const int MonthPerYear = 12;

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

    public double TotalAmount { get; }
    public double PaidAmount { get; private set; }
    public double RemainingAmount => TotalAmount - PaidAmount;

    public int Duration { get; }
    public int RemainingDuration { get; private set; }
    public double Rate { get; }

    public void Pay(double amount, int months = 1)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(amount, RemainingAmount);
        ArgumentOutOfRangeException.ThrowIfNegative(amount);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(months, RemainingDuration);
        ArgumentOutOfRangeException.ThrowIfNegative(months);

        PaidAmount += amount;
        RemainingDuration -= months;
    }

    public List<DueAmount> ComputeDueAmounts(ICalculator calculator)
    {
        var dueAmounts = new List<DueAmount>();

        for (var i = 0; i < Duration; i++)
        {
            var paidAmount = calculator.Calculate(this);
            var dueAmount = new DueAmount(i + 1, paidAmount, RemainingAmount);
            dueAmounts.Add(dueAmount);

            if (dueAmount.PaidAmount <= 0) break;
            Pay(dueAmount.PaidAmount < RemainingAmount ? dueAmount.PaidAmount : RemainingAmount);
        }

        return dueAmounts;
    }
}