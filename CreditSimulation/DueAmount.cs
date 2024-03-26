namespace SimulationCredits;

public class DueAmount
{
    public int Month { get; set; }
    public double Amount { get; set; }

    public DueAmount(int month, double amount)
    {
        Month = month;
        Amount = amount;
    }
    
}