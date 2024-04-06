using SimulationCredits;

namespace SimulationCreditsTest;

public class CreditComputerTest
{
    private const int FifteenYears = 15 * 12;
    private const int MonthPerYear = 12;

    [Fact]
    public void CreditCalculator_Should_Calculate_Credit()
    {
        var credit = new Credit(200_000, FifteenYears, 2);
        var calculator = new CreditComputer();

        var monthlyPayment = calculator.Compute(credit);

        // Assert
        Assert.Equal(953.68, monthlyPayment, 2);
    }

    [Fact]
    public void CreditTest_ComputeDueAmounts()
    {
        var credit = new Credit(200000, 15 * MonthPerYear, 0.85);
        var calculator = new CreditComputer();
        var dueAmounts = credit.ComputeDueAmounts(calculator);

        Assert.Equal(15 * MonthPerYear, dueAmounts.Count);
        Assert.Equal(200000, credit.PaidAmount);
        Assert.Equal(0, credit.RemainingAmount);
        Assert.Equal(0, credit.RemainingDurationInMonths);
    }
    
    
    [Fact]
    public void CreditTest_ShouldComputeSingleDueAmount()
    {
        var credit = new Credit(200_000, 15 * MonthPerYear, 2);
        var calculator = new CreditComputer();
        var dueAmounts =  credit.ComputeSingleDueAmount(calculator);
        
        Assert.Equal(953.68, dueAmounts.PaidAmount, 2);
    }
}