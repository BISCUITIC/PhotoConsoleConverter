using System.Drawing;

namespace PhotoConsoleConverter;

internal class PhotoConverter : IDisposable
{
    private readonly Bitmap _bitmap;
    private readonly int _bitmapWidth;
    private readonly int _bitmapHeight;

    private readonly ConsoleInfo _consoleInfo;

    private int _maxImageResolutionX;
    private int _maxImageResolutionY;

    private int _chunkSize = 1;
    private int _imagWidth;
    private int _imagHeight;

    public PhotoConverter(Bitmap bitmap, ConsoleInfo consoleInfo)
    {
        _bitmap = bitmap ?? throw new ArgumentNullException(nameof(bitmap));
        _bitmap = bitmap;
        _bitmapWidth = _bitmap.Width;
        _bitmapHeight = _bitmap.Height;

        _consoleInfo = consoleInfo;

        _maxImageResolutionX = _consoleInfo.SizeX / _consoleInfo.NormalizationX;
        _maxImageResolutionY = _consoleInfo.SizeY / _consoleInfo.NormalizationY;
    }

    public IMatrix<Color> GetColorsMatrix()
    {
        _chunkSize = Math.Max(
            (int)Math.Ceiling((double)_bitmapWidth / _maxImageResolutionX),
            (int)Math.Ceiling((double)_bitmapHeight / _maxImageResolutionY)
        );

        _imagWidth = _bitmapWidth / _chunkSize;
        _imagHeight = _bitmapHeight / _chunkSize;

        ColorMatrix colorsMatrix = new ColorMatrix(_imagWidth, _imagHeight);

        for (int i = 0; i < _imagHeight; i++)
            for (int j = 0; j < _imagWidth; j++)
                colorsMatrix[i, j] = GetChunkAvarageColor(j * _chunkSize, i * _chunkSize);

        return colorsMatrix;
    }

    private Color GetChunkAvarageColor(int posX, int posY)
    {
        int avgR = 0;
        int avgB = 0;
        int avgG = 0;

        for (int chunk_x = 0; chunk_x < _chunkSize; chunk_x++)
            for (int chunk_y = 0; chunk_y < _chunkSize; chunk_y++)
            {
                Color pixel = _bitmap.GetPixel(posX + chunk_x, posY + chunk_y);
                avgR += pixel.R;
                avgB += pixel.B;
                avgG += pixel.G;
            }

        avgR /= _chunkSize * _chunkSize;
        avgB /= _chunkSize * _chunkSize;
        avgG /= _chunkSize * _chunkSize;

        return Color.FromArgb(avgR, avgB, avgG);
    }

    public void Dispose()
    {
        _bitmap?.Dispose();
    }
}
