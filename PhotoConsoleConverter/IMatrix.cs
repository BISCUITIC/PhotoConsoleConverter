using System.Drawing;

namespace PhotoConsoleConverter;

internal interface IMatrix<T>
{
    int Width { get; }
    int Height { get; }
    
    T this[int y, int x] { get;}
}
