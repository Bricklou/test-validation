namespace PuissanceQuatre.Common;

public class Grid<TCase> where TCase : AbstractCase
{
    private readonly TCase?[,] _grid;
    public readonly uint Height;
    public readonly uint Width;

    public Grid(uint width, uint height)
    {
        Height = height;
        Width = width;

        _grid = new TCase[width, height];
    }

    public TCase? GetPosition(uint x, uint y)
    {
        if (y >= Height || x >= Width) throw new ArgumentOutOfRangeException();
        return _grid[x, y];
    }

    public void SetPosition(uint x, uint y, TCase? value)
    {
        if (y >= Height || x >= Width) throw new ArgumentOutOfRangeException();
        _grid[x, y] = value;
    }

    public bool IsFull()
    {
        for (var y = 0; y < Height; y++)
        for (var x = 0; x < Width; x++)
            if (_grid[x, y] == null)
                return false;
        return true;
    }
}