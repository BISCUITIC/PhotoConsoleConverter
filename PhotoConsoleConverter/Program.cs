using System.Collections.Specialized;
using System.Drawing;
using System.IO;

namespace PhotoConsoleConverter;



internal class Program
{
    private const int CONSOLE_SIZE_X = 120;
    private const int CONSOLE_SIZE_Y = 30;

    private const int NORMALIZATION_X = 2;
    private const int NORMALIZATION_Y = 1;

    private static void Main(string[] args)
    {        
        string filePath = "Lenin.jpg";

        ConsoleInfo info = new ConsoleInfo(sizeY: 30);
        ConsoleDrawer drawer = new ConsoleDrawer(info);

        using (PhotoConverter photoConverter = new PhotoConverter(new Bitmap(filePath), info))
        {
            IMatrix<Color> colorMatrix = photoConverter.GetColorsMatrix();

            drawer.DrawColorMatrix(colorMatrix);
        }

        Console.SetCursorPosition(0, 29);
    }

    
}
