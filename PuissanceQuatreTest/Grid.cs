using MorpionApp;

namespace PuissanceQuatreTest;

internal enum CustomEnum
{
    Player1,
    Player2
}

public class GridTest
{
    [Fact]
    public void GetPosition_WithValidCoordinates_ReturnsNull()
    {
        var grid = new Grid<CustomEnum>(5, 5);
        var position = grid.GetPosition(2, 2);
        Assert.Null(position);
    }

    [Fact]
    public void GetPosition_WithInvalidCoordinates_ThrowsException()
    {
        var grid = new Grid<CustomEnum>(5, 5);
        var position = grid.GetPosition(4, 4);
        Assert.Null(position);
    }

    [Fact]
    public void SetPosition_WithValidCoordinates_SetsValue()
    {
        var grid = new Grid<CustomEnum>(5, 5);
        grid.SetPosition(2, 2, CustomEnum.Player1);
        var position = grid.GetPosition(2, 2);
        Assert.Equal(CustomEnum.Player1, position);
    }

    [Fact]
    public void SetPosition_WithInvalidCoordinates_ThrowsException()
    {
        var grid = new Grid<CustomEnum>(5, 5);
        Assert.Throws<ArgumentOutOfRangeException>(() => grid.SetPosition(6, 6, CustomEnum.Player1));
    }

    [Fact]
    public void SetPosition_WithNullCoordinates_ReturnsNull()
    {
        var grid = new Grid<CustomEnum>(5, 5);
        grid.SetPosition(0, 0, null);
        var position = grid.GetPosition(0, 0);
        Assert.Null(position);
    }
}