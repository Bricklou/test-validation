namespace SimulationCredits;

public class CreditComputer : ICalculator
{
    public double Compute(Credit credit)
    {
        var monthlyRate = credit.Rate / 100 / 12;
        var monthlyInterest = credit.RemainingAmount * monthlyRate;

        var monthlyCapital = credit.MonthlyPayment - monthlyInterest;
        return monthlyCapital;
    }
}