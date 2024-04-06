using SimulationCredits;

namespace SimulationCreditsTest;

public class CreditTest
{
    private const int MonthPerYear = 12;

    [Fact]
    public void CreditTest_WithZeroValueArguments()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Credit(0, 0, 0));
    }

    [Fact]
    public void CreditTest_WithNegativeValueArguments()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Credit(-1, -1, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Credit(-100, -100, -100));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Credit(-15, -12, -1054));
    }

    [Fact]
    public void CreditTest_WithInvalidValuesArguments()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Credit(49999, 9 * MonthPerYear, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Credit(50000, 8 * MonthPerYear, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Credit(50000, 26 * MonthPerYear, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Credit(50000, 26 * MonthPerYear, 1));
    }

    [Fact]
    public void CreditTest_WithValidValuesArguments()
    {
        var credit = new Credit(50000, 9 * MonthPerYear, 1);
        Assert.Equal(50000, credit.TotalAmount);
        Assert.Equal(0, credit.PaidAmount);
        Assert.Equal(50000, credit.RemainingAmount);
        Assert.Equal(9 * MonthPerYear, credit.DurationInMonths);
        Assert.Equal(1, credit.Rate);
    }

    [Fact]
    public void CreditTest_PayFunctionCalled_WithOneMonth()
    {
        var credit = new Credit(50000, 9 * MonthPerYear, 1);
        credit.Pay(10000);

        Assert.Equal(50000, credit.TotalAmount);
        Assert.Equal(10000, credit.PaidAmount);
        Assert.Equal(40000, credit.RemainingAmount);
        Assert.Equal(9 * MonthPerYear - 1, credit.RemainingDurationInMonths);
    }

    [Fact]
    public void CreditTest_WhenPayMoreThanRemainingAmount_ThrowError()
    {
        var credit = new Credit(50000, 9 * MonthPerYear, 1);
        credit.Pay(10000);
        Assert.Throws<ArgumentOutOfRangeException>(() => credit.Pay(50000));
    }

    [Fact]
    public void CreditTest_WhenMoreMonthsThanRemainingDuration_ThrowError()
    {
        var credit = new Credit(50000, 9 * MonthPerYear, 1);
        Assert.Throws<ArgumentOutOfRangeException>(() => credit.Pay(10000, 10 * MonthPerYear));
    }

    [Fact]
    public void CreditTest_WhenNegativeAmount_ThrowError()
    {
        var credit = new Credit(50000, 9 * MonthPerYear, 1);
        Assert.Throws<ArgumentOutOfRangeException>(() => credit.Pay(-10000));
    }

    [Fact]
    public void CreditTest_WhenNegativeMonths_ThrowError()
    {
        var credit = new Credit(50000, 9 * MonthPerYear, 1);
        Assert.Throws<ArgumentOutOfRangeException>(() => credit.Pay(10000, -1));
    }
}