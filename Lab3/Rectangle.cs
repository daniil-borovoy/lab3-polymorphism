using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab3;

public class Rectangle : Figure
{
    private readonly double _width;

    private readonly double _height;

    public Rectangle(double width, double height)
    {
        _width = width;
        _height = height;
    }

    public override double GetArea()
    {
        return _width * _height;
    }

    public override Point GetCenter()
    {
        return new Point((int)(Position.X + _width / 2), (int)(Position.Y + _height / 2));
    }

    public override void Draw(Graphics gr)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            throw new PlatformNotSupportedException();
        }
        gr.DrawRectangle(new Pen(Color), Position.X, Position.Y, (int)(_width), (int)(_height));
        gr.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
    }
}