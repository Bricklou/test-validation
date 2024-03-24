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
}