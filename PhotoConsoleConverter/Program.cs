using System.Drawing;

namespace PhotoConsoleConverter;

internal class Program
{
    private const int CONSOLE_SIZE_X = 120;
    private const int CONSOLE_SIZE_Y = 30;

    private const int NORMALIZATION_X = 2;
    private const int NORMALIZATION_Y = 1;

    private static void Main(string[] args)
    {
        string filePath = "Data\\Lenin.jpg";

        ConsoleInfo info = new ConsoleInfo(CONSOLE_SIZE_X,
                                           CONSOLE_SIZE_Y,
                                           NORMALIZATION_X,
                                           NORMALIZATION_Y);

        ConsoleDrawer drawer = new ConsoleDrawer(info);
        IMatrix<Color> colorMatrix;

        using (PhotoConverter photoConverter = new PhotoConverter(new Bitmap(filePath), info))
        {
            colorMatrix = photoConverter.GetColorsMatrix();
        }

        drawer.DrawColorMatrix(colorMatrix);

        Console.SetCursorPosition(0, 29);
    }
}
