using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab3;

public class Triangle : Figure
{
    private readonly double _a;

    private readonly double _b;

    private readonly double _c;

    public Triangle(double a, double b, double c)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    public override double GetArea()
    {
        var p = (_a + _b + _c) / 2;
        return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
    }

    public override Point GetCenter()
    {
        double p = (_a + _b + _c) / 2.0; // полупериметр
        double S = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c)); // площадь треугольника

        // координаты вершин
        double ax = 0.0;
        double ay = 0.0;
        double bx = 0.0 + _c;
        double by = 0.0;
        double cx = 0.0 + (_b * Math.Cos(Math.Asin(S * 2 / (_b * _c))) * -1);
        double cy = 0.0 + (_b * Math.Sin(Math.Asin(S * 2 / (_b * _c))));

        // координаты центра
        double cx1 = (ax + bx + cx) / 3.0;
        double cy1 = (ay + by + cy) / 3.0;

        return new Point((int)(Position.X + cx1), (int)(Position.Y + cy1));
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
            new Point((int)(Position.X + _a), Position.Y),
            new Point(Position.X, (int)(Position.Y + _b)),
        });
        gr.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
    }
}