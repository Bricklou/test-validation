using SimulationCredits;

namespace SimulationCreditsTest;

public class ArgumentParserTest
{
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
}