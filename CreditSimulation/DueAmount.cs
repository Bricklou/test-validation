namespace SimulationCredits;

public class DueAmount
{
    public DueAmount(int month, double paidAmount, double remainingAmount)
    {
        Month = month;
        PaidAmount = paidAmount;
        RemainingAmount = remainingAmount;
    }

    public int Month { get; set; }
    public double PaidAmount { get; set; }
    public double RemainingAmount { get; set; }
}