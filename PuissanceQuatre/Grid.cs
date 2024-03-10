namespace MorpionApp;

public class Grid<TEnumType> where TEnumType : struct, Enum
{
    public readonly uint Height;
    public readonly uint Width;
    private readonly TEnumType?[][] _grid;

    public Grid(uint height, uint width)
    {
        Height = height;
        Width = width;

        _grid = new TEnumType?[height][];
        for (var i = 0; i < height; i++)
        {
            _grid[i] = new TEnumType?[width];
            for (var j = 0; j < width; j++) _grid[i][j] = null;
        }
    }

    public TEnumType? GetPosition(uint x, uint y)
    {
        if (x >= Height || y >= Width) throw new ArgumentOutOfRangeException();
        return _grid[x][y];
    }

    public void SetPosition(uint x, uint y, TEnumType? value)
    {
        if (x >= Height || y >= Width) throw new ArgumentOutOfRangeException();
        _grid[x][y] = value;
    }
}