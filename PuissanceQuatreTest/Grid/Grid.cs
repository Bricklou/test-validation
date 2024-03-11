using PuissanceQuatre.Common;

namespace PuissanceQuatreTest.Grid;

public class GridTest
{
    [Fact]
    public void GetPosition_WithValidCoordinates_ReturnsNull()
    {
        var grid = new Grid<AbstractCustomCase>(5, 5);
        var position = grid.GetPosition(2, 2);
        Assert.Null(position);
    }

    [Fact]
    public void GetPosition_WithInvalidCoordinates_ThrowsException()
    {
        var grid = new Grid<AbstractCustomCase>(5, 5);
        var position = grid.GetPosition(4, 4);
        Assert.Null(position);
    }

    [Fact]
    public void SetPosition_WithValidCoordinates_SetsValue()
    {
        var grid = new Grid<AbstractCustomCase>(5, 5);
        grid.SetPosition(2, 2, new CustomCaseO());
        var position = grid.GetPosition(2, 2);
        Assert.NotNull(position);
        Assert.IsType<CustomCaseO>(position);
    }

    [Fact]
    public void SetPosition_WithInvalidCoordinates_ThrowsException()
    {
        var grid = new Grid<AbstractCustomCase>(5, 5);
        Assert.Throws<ArgumentOutOfRangeException>(() => grid.SetPosition(6, 6, new CustomCaseO()));
    }

    [Fact]
    public void SetPosition_WithNullCoordinates_ReturnsNull()
    {
        var grid = new Grid<AbstractCustomCase>(5, 5);
        grid.SetPosition(0, 0, null);
        var position = grid.GetPosition(0, 0);
        Assert.Null(position);
    }
}