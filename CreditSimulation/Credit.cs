namespace SimulationCredits;

public class Credit
{
    private const int MonthPerYear = 12;

    public Credit(int totalAmount, int durationInMonths, double rate)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(totalAmount, 50_000);

        if (durationInMonths is < 9 * MonthPerYear or > 25 * MonthPerYear)
            throw new ArgumentOutOfRangeException(nameof(durationInMonths));

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rate);

        TotalAmount = totalAmount;
        RemainingAmount = TotalAmount;
        
        DurationInMonths = durationInMonths;
        RemainingDurationInMonths = durationInMonths;
        
        Rate = rate;
        MonthlyPayment = ComputeMontlyPayment();
    }

    public double TotalAmount { get; }
    public double RemainingAmount { get; private set; }
    public double PaidAmount => TotalAmount - RemainingAmount;

    public int DurationInMonths { get; }
    public int RemainingDurationInMonths { get; private set; }
    public double Rate { get; }
    
    public double MonthlyPayment { get; }

    public void Pay(double amount, int months = 1)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(amount, RemainingAmount);
        ArgumentOutOfRangeException.ThrowIfNegative(amount);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(months, RemainingDurationInMonths);
        ArgumentOutOfRangeException.ThrowIfNegative(months);

        RemainingAmount -= amount;
        RemainingDurationInMonths -= months;
    }

    public List<DueAmount> ComputeDueAmounts(ICalculator calculator)
    {
        var dueAmounts = new List<DueAmount>();

        for (var i = 0; i < DurationInMonths; i++)
        {
            var dueAmount = ComputeSingleDueAmount(calculator);
            if (dueAmount.PaidAmount <= 0) break;

            dueAmounts.Add(dueAmount);
        }

        return dueAmounts;
    }
    
    private double ComputeMontlyPayment()
    {
        var monthlyRate = Rate / 100 / 12;
        return TotalAmount * (monthlyRate / (1 - Math.Pow(1 + monthlyRate, -DurationInMonths)));
    }

    public DueAmount ComputeSingleDueAmount(ICalculator calculator)
    {
        var paidAmount = calculator.Compute(this);
        var dueAmount = new DueAmount(1, paidAmount, RemainingAmount);

        Pay(dueAmount.PaidAmount < RemainingAmount ? dueAmount.PaidAmount : RemainingAmount);
        return dueAmount;
    }
}