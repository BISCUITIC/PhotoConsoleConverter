using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoConsoleConverter;

internal class ConsoleDrawer
{
    private readonly ConsoleInfo _consoleInfo;

    public ConsoleDrawer(ConsoleInfo consoleInfo) 
    {
        _consoleInfo = consoleInfo;
    }

    public void DrawColorMatrix(IMatrix<Color> matrix)
    {
        for (int i = 0; i < matrix.Height; i++)
            for (int j = 0; j < matrix.Width; j++)
                SetChankConsoleColor(j * _consoleInfo.NormalizationX, 
                                     i * _consoleInfo.NormalizationY, 
                                     matrix[i, j]);
    }

    private void SetChankConsoleColor(int posX, int posY, Color color)
    {
        for(int i = 0; i < _consoleInfo.NormalizationX; i++) {
            for (int j = 0; j < _consoleInfo.NormalizationY; j++)
            {
                Console.SetCursorPosition(posX + i, posY + j);
                SetPixelConsoleColor(color);
            }
        }
    }

    private void SetPixelConsoleColor(Color color)
    {
        Console.Write($"\u001b[48;2;{color.R};{color.G};{color.B}m \u001b[0m");
    }
}
