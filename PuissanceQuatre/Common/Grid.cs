namespace MorpionApp;

public class Grid<TCase> where TCase : AbstractCase
{
    private readonly TCase?[][] _grid;
    public readonly uint Height;
    public readonly uint Width;

    public Grid(uint height, uint width)
    {
        Height = height;
        Width = width;

        _grid = new TCase[height][];
        for (var i = 0; i < height; i++)
        {
            _grid[i] = new TCase[width];
            for (var j = 0; j < width; j++) _grid[i][j] = null!;
        }
    }

    public TCase? GetPosition(uint x, uint y)
    {
        if (x >= Height || y >= Width) throw new ArgumentOutOfRangeException();
        return _grid[x][y];
    }

    public void SetPosition(uint x, uint y, TCase? value)
    {
        if (x >= Height || y >= Width) throw new ArgumentOutOfRangeException();
        _grid[x][y] = value;
    }
}