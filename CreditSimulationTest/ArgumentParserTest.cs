using SimulationCredits;

namespace SimulationCreditsTest;

public class ArgumentParserTest
{
    private const int EightYears = 8 * 12;
    private const int NineYears = 9 * 12;
    private const int TwentySixYears = 26 * 12;

    private readonly ArgumentsParser parser = new();

    [Fact]
    public void ParseInputTest_WithoutArguments_ThrowError()
    {
        Assert.Throws<ArgumentException>(() => parser.Parse([]));
    }

    [Fact]
    public void ParseInputTest_WithTooMuchArguments_ThrowError()
    {
        Assert.Throws<ArgumentException>(() => parser.Parse(["arg1", "arg2", "arg3", "arg4"]));
    }

    [Fact]
    public void ParseInputTest_WithTooFewArguments_ThrowError()
    {
        Assert.Throws<ArgumentException>(() => parser.Parse(["arg1", "arg2"]));
    }

    [Fact]
    public void ParseInputTest_WithStringArguments_ThrowError()
    {
        Assert.Throws<ArgumentException>(() => parser.Parse(["arg1", "arg2", "arg3"]));
    }

    [Fact]
    public void ParseInputTest_WithZeroValueArguments()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => parser.Parse(["0", "0", "0,0"]));
    }

    [Fact]
    public void ParseInputTest_WithNegativeValueArguments()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => parser.Parse(["-1", "-1", "-1,0"]));
        Assert.Throws<ArgumentOutOfRangeException>(() => parser.Parse(["-100", "-100", "-100,0"]));
        Assert.Throws<ArgumentOutOfRangeException>(() => parser.Parse(["-15", "-12", "-1054,0"]));
    }

    [Fact]
    public void ParseInputTest_WithInvalidValuesArguments()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => parser.Parse(["49999", NineYears.ToString(), "1,0"]));
        Assert.Throws<ArgumentOutOfRangeException>(() => parser.Parse(["50000", EightYears.ToString(), "1,0"]));
        Assert.Throws<ArgumentOutOfRangeException>(() => parser.Parse(["50000", TwentySixYears.ToString(), "1,0"]));
        Assert.Throws<ArgumentOutOfRangeException>(() => parser.Parse(["50000", TwentySixYears.ToString(), "1,0"]));
    }

    [Fact]
    public void ParseInputTest_WithValidValuesArguments_ReturnsCredit()
    {
        var credit = parser.Parse(["50000", NineYears.ToString(), "1"]);

        Assert.IsType<Credit>(credit);
    }
}