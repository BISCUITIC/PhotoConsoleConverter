namespace PhotoConsoleConverter;

internal struct ConsoleInfo
{
    private readonly int _sizeX = 120;
    private readonly int _sizeY = 30;

    private readonly int _normalizationX = 2;
    private readonly int _normalizationY = 1;

    public int SizeX => _sizeX;
    public int SizeY => _sizeY;

    public int NormalizationX => _normalizationX;
    public int NormalizationY => _normalizationY;

    public ConsoleInfo()
    {

    }

    public ConsoleInfo(int sizeX = 120, int sizeY = 30, int normalizationX = 2, int normalizationY = 1)
    {
        _sizeX = sizeX;
        _sizeY = sizeY;
        _normalizationX = normalizationX;
        _normalizationY = normalizationY;
    }
}
