using PuissanceQuatre.Common;
using PuissanceQuatre.Common.Rules;
using PuissanceQuatreTest;

public class VerticalRuleTest
{
    [Fact]
    public void Check_ReturnsTrue_WhenVerticalLineExists()
    {
        // Arrange
        var grid = new Grid<AbstractCase>(5, 5);
        var rule = new VerticalRule<AbstractCase>(3);

        // Assume AbstractCase has a constructor that takes a symbol
        for (uint i = 0; i < 3; i++) grid.SetPosition(0, i, new CustomCaseX());

        // Act
        var result = rule.Check(grid, 0, 0);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Check_ReturnsTrue_WhenReverseVerticalLineExists()
    {
        // Arrange
        var grid = new Grid<AbstractCase>(5, 5);
        var rule = new VerticalRule<AbstractCase>(3);

        // Assume AbstractCase has a constructor that takes a symbol
        for (uint i = 0; i < 3; i++) grid.SetPosition(0, 4 - i, new CustomCaseX());

        // Act
        var result = rule.Check(grid, 0, 4);

        // Assert
        Assert.True(result);
    }
}