using SimulationCredits;

namespace SimulationCreditsTest;

public class CreditCalculatorTest
{
    private const int FifteenYears = 15 * 12;
    private const int MonthPerYear = 12;

    [Fact]
    public void CreditCalculator_Should_Calculate_Credit()
    {
        var credit = new Credit(200_000, FifteenYears, 2);
        var calculator = new CreditCalculator();

        var monthlyPayment = calculator.Calculate(credit);

        // Assert
        Assert.Equal(1287.02, monthlyPayment, 2);
    }

    [Fact]
    public void CreditTest_ComputeDueAmounts()
    {
        var credit = new Credit(200000, 15 * MonthPerYear, 0.85);
        var calculator = new CreditCalculator();
        var dueAmounts = credit.ComputeDueAmounts(calculator);

        Assert.Equal(15 * MonthPerYear, dueAmounts.Count);
        Assert.Equal(200000, credit.PaidAmount);
        Assert.Equal(0, credit.RemainingAmount);
        Assert.Equal(0, credit.RemainingDuration);
    }
    
    
    [Fact]
    public void CreditTest_ShouldComputeSingleDueAmount()
    {
        var credit = new Credit(200_000, 15 * MonthPerYear, 2);
        var calculator = new CreditCalculator();
        var dueAmounts =  credit.ComputeSingleDueAmount(calculator);
        
        Assert.Equal(1287.02, dueAmounts.PaidAmount, 2);
    }
}