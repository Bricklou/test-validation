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
}