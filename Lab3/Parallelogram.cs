using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab3;

public class Parallelogram : Figure
{
    private readonly double _a;

    private readonly double _h;

    private readonly double _angle;

    public Parallelogram(double a, double h, double angle = 30)
    {
        _a = a;
        _h = h;
        _angle = angle;
    }

    public override double GetArea()
    {
        return _a * _h;
    }

    public override Point GetCenter()
    {
        int x = (int)(Position.X + _a / 2);
        int y = (int)(Position.Y + _h / 2);
        return new Point(x, y);
    }

    public override void Draw(Graphics gr)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            throw new PlatformNotSupportedException();
        }

        // Вычисляем координаты вершин параллелограмма
        double angleRadians = _angle * Math.PI / 180; // переводим угол в радианы
        float x2 = (float)(_h / Math.Tan(angleRadians));
        PointF[] points = new PointF[]
        {
            new PointF(Position.X, Position.Y),
            new PointF(Position.X + (float)_a, Position.Y),
            new PointF(Position.X + (float)(_a + x2), Position.Y + (float)_h),
            new PointF(Position.X + x2, Position.Y + (float)_h)
        };
        // Отрисовываем параллелограмм
        gr.DrawPolygon(Pens.Black, points);
        gr.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
    }
}