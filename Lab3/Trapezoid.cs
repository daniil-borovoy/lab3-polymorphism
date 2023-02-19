using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab3;

public class Trapezoid : Figure
{
    private readonly double _bottomSide;

    private readonly double _topSide;

    private readonly double _h;

    public Trapezoid(double bottomSide, double topSide, double height)
    {
        _bottomSide = bottomSide;
        _topSide = topSide;
        _h = height;
    }

    public override double GetArea()
    {
        return 0.5 * (_bottomSide + _topSide) * _h;
    }

    public override Point GetCenter()
    {
        return new Point((int)(Position.X + (_bottomSide / 2)), (int)(Position.Y + (_h / 2)));
    }

    public override void Draw(Graphics gr)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            throw new PlatformNotSupportedException();
        }
        var bottomLeftPoint = new Point(Position.X, Position.Y);
        var bottomRightPoint = new Point((int)(Position.X + _bottomSide), Position.Y);
        var topLeftPoint = new Point((int)(Position.X + ((_bottomSide - _topSide) / 2)), (int)(Position.Y + _h));
        var topRightPoint = new Point((int)(Position.X + _topSide + ((_bottomSide - _topSide) / 2 )), (int)(Position.Y + _h));
        gr.DrawPolygon(new Pen(Color), new[]
        {
            topLeftPoint,
            topRightPoint,
            bottomRightPoint,
            bottomLeftPoint,
        });
        gr.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
    }
}