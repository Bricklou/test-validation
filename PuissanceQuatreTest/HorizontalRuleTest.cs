using PuissanceQuatre.Common;
using Xunit;
using PuissanceQuatre.Common.Rules;
using PuissanceQuatreTest;

public class HorizontalRuleTest
{
    [Fact]
    public void Check_ReturnsTrue_WhenHorizontalLineExists()
    {
        // Arrange
        var grid = new Grid<AbstractCase>(5, 5);
        var rule = new HorizontalRule<AbstractCase>(3);

        // Assume AbstractCase has a constructor that takes a symbol
        for (uint i = 0; i < 3; i++)
        {
            grid.SetPosition(i, 0, new CustomCaseX());
        }

        // Act
        var result = rule.Check(grid, 0, 0);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Check_ReturnsTrue_WhenReverseHorizontalLineExists()
    {
        // Arrange
        var grid = new Grid<AbstractCase>(5, 5);
        var rule = new HorizontalRule<AbstractCase>(3);

        // Assume AbstractCase has a constructor that takes a symbol
        for (uint i = 0; i < 3; i++)
        {
            grid.SetPosition(4 - i, 0, new CustomCaseX());
        }

        // Act
        var result = rule.Check(grid, 4, 0);

        // Assert
        Assert.True(result);
    }
}