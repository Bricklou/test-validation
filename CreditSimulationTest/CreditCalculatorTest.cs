using SimulationCredits;

namespace SimulationCreditsTest;

public class CreditCalculatorTest
{
    private const int FifteenYears = 15 * 12;

    [Fact]
    public void CreditCalculator_Should_Calculate_Credit()
    {
        var credit = new Credit(200_000, FifteenYears, 2);
        var calculator = new CreditCalculator();

        var monthlyPayment = calculator.Calculate(credit);

        // Assert
        Assert.Equal(1287.01, monthlyPayment);
    }
}