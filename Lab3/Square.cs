using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab3;

public class Square: Figure
{
    private readonly double _a;
    public Square(double a)
    {
        _a = a;
    }

    public override double GetArea()
    {
        return Math.Pow(_a, 2);
    }

    public override Point GetCenter()
    {
        var halfOfSide = (int)(_a / 2);
        return new Point(Position.X + halfOfSide, Position.Y + halfOfSide);
    }

    public override void Draw(Graphics gr)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            throw new PlatformNotSupportedException();
        }
        gr.DrawPolygon(new Pen(Color), new []
        {
            new Point(Position.X, Position.Y),
            new Point(Position.X, (int)(Position.Y + _a)),
            new Point((int)(Position.X + _a), (int)(Position.Y + _a)),
            new Point((int)(Position.X + _a), Position.Y),
        });
        gr.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
    }
}