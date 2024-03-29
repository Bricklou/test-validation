namespace SimulationCredits;

public class CreditCalculator : ICalculator
{
    public double Calculate(Credit credit)
    {
        var monthlyRate = credit.Rate / 100 / 12;
        var monthlyPayment =
            credit.TotalAmount * (monthlyRate / (1 - Math.Pow(1 + monthlyRate, -credit.Duration)));
        return monthlyPayment;
    }
}