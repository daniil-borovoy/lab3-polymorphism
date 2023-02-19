using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab3;

public class RegularDecagon : Figure
{
    private readonly double _a;

    public RegularDecagon(double a)
    {
        _a = a;
    }

    public override double GetArea()
    {
        return (double)5 / 2 * Math.Pow(_a, 2) * Math.Sqrt(5 + 2 * Math.Sqrt(5));
    }

    public override Point GetCenter()
    {
        return new Point((int)(Position.X), (int)(Position.Y));
    }

    public override void Draw(Graphics gr)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            throw new PlatformNotSupportedException();
        }
        PointF[] points = new PointF[10];
        // Вычисляем координаты вершин правильного десятиугольника
        double angle = 2 * Math.PI / 10;
        for (int i = 0; i < 10; i++)
        {
            points[i] = new PointF(
                Position.X + (float)(_a * Math.Cos(i * angle - Math.PI / 2)),
                Position.Y + (float)(_a * Math.Sin(i * angle - Math.PI / 2))
            );
        }

        // Отрисовываем десятиугольник
        gr.DrawPolygon(Pens.Black, points);
        gr.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
    }
}