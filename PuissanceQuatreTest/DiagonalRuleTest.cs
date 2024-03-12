using PuissanceQuatre.Common;
using PuissanceQuatre.Common.Rules;

namespace PuissanceQuatreTest;

public class DiagonalRuleTest
{
    [Fact]
    public void Check_ReturnsTrue_WhenBottomRightDiagonalLineExists()
    {
        // Arrange
        var grid = new Grid<AbstractCustomCase>(5, 5);
        var rule = new DiagonalRule<AbstractCustomCase>(3);

        // Assume AbstractCustomCase has a constructor that takes a symbol
        for (uint i = 0; i < 3; i++) grid.SetPosition(i, i, new CustomCaseX());

        // Act
        var result = rule.Check(grid, 0, 0);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Check_ReturnsTrue_WhenTopRightDiagonalLineExists()
    {
        // Arrange
        var grid = new Grid<AbstractCustomCase>(5, 5);
        var rule = new DiagonalRule<AbstractCustomCase>(3);

        // Assume AbstractCustomCase has a constructor that takes a symbol
        for (uint i = 0; i < 3; i++) grid.SetPosition(i, 4 - i, new CustomCaseX());

        // Act
        var result = rule.Check(grid, 0, 4);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Check_ReturnsTrue_WhenBottomLeftDiagonalLineExists()
    {
        // Arrange
        var grid = new Grid<AbstractCustomCase>(5, 5);
        var rule = new DiagonalRule<AbstractCustomCase>(3);

        // Assume AbstractCustomCase has a constructor that takes a symbol
        for (uint i = 0; i < 3; i++) grid.SetPosition(4 - i, i, new CustomCaseX());

        // Act
        var result = rule.Check(grid, 4, 0);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Check_ReturnsTrue_WhenTopLeftDiagonalLineExists()
    {
        // Arrange
        var grid = new Grid<AbstractCustomCase>(5, 5);
        var rule = new DiagonalRule<AbstractCustomCase>(3);

        // Assume AbstractCustomCase has a constructor that takes a symbol
        for (uint i = 0; i < 3; i++) grid.SetPosition(4 - i, 4 - i, new CustomCaseX());

        // Act
        var result = rule.Check(grid, 4, 4);

        // Assert
        Assert.True(result);
    }
}