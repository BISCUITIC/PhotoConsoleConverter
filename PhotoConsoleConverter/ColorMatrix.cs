using System.Drawing;

namespace PhotoConsoleConverter;

internal class ColorMatrix : IMatrix<Color>
{
    private int _width;
    private int _height;
    private Color[,] _data;

    public Color this[int y, int x] { get => _data[y, x]; set => _data[y, x] = value; }
    public int Width => _width;
    public int Height => _height;

    public ColorMatrix(int width, int height)
    {
        _width = width;
        _height = height;
        _data = new Color[height, width];
    }
}
