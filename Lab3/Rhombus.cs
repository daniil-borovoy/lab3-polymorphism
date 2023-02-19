using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab3;

public class Rhombus : Figure
{
    private readonly double _d1;

    private readonly double _d2;

    public Rhombus(double d1, double d2)
    {
        _d1 = d1;
        _d2 = d2;
    }

    public override double GetArea()
    {
        return (_d1 * _d2) / 2;
    }

    public override Point GetCenter()
    {
        return new Point((int)(Position.X + _d1 / 2), Position.Y);
    }

    public override void Draw(Graphics gr)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            throw new PlatformNotSupportedException();
        }
        gr.DrawPolygon(new Pen(Color), new[]
        {
            new Point(Position.X, Position.Y),
            new Point((int)(Position.X + _d1 / 2), (int)(Position.Y + (_d2 / 2))),
            new Point((int)(Position.X + _d1), Position.Y),
            new Point((int)(Position.X + _d1 / 2), (int)(Position.Y - (_d2 / 2))),
        });
        gr.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
    }
}