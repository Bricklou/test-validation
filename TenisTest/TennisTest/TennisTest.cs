using Tenis;

namespace TenisTest;

public class TennisTest
{
    [Theory]
    [InlineData(0, 0, "Love-All")]
    [InlineData(1, 0, "Fifteen-Love")]
    [InlineData(2, 0, "Thirty-Love")]
    [InlineData(3, 0, "Forty-Love")]
    [InlineData(4, 0, "Win for player A")]
    [InlineData(0, 1, "Love-Fifteen")]
    [InlineData(0, 2, "Love-Thirty")]
    [InlineData(0, 3, "Love-Forty")]
    [InlineData(0, 4, "Win for player B")]
    [InlineData(1, 1, "Fifteen-All")]
    [InlineData(2, 2, "Thirty-All")]
    [InlineData(3, 3, "Deuce")]
    [InlineData(4, 2, "Win for player A")]
    [InlineData(2, 4, "Win for player B")]
    [InlineData(4, 3, "Advantage player A")]
    [InlineData(3, 4, "Advantage player B")]
    [InlineData(8, 8, "Deuce")]
    [InlineData(3, 9, "Win for player B")]
    [InlineData(9, 8, "Advantage player A")]
    public void ComputeScore(uint scorePlayerA, uint scorePlayerB, string expectedText)
    {
        var tennis = new Tennis();
        Assert.Equal(expectedText, tennis.ComputeScores(scorePlayerA, scorePlayerB));
    }
}