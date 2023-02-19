using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab3;

public class Circle: Figure
{
    private readonly double _d;

    public Circle(double diameter)
    {
        _d = diameter;
    }
    
    public override double GetArea()
    {
        return Math.PI * Math.Pow((_d / 2), 2);
    }

    public override Point GetCenter()
    {
        return new Point((int)(Position.X + _d / 2), (int)(Position.Y + _d / 2));
    }

    public override void Draw(Graphics gr)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            throw new PlatformNotSupportedException();
        }
        gr.DrawEllipse(new Pen(Color), Position.X, Position.Y, (int)_d, (int)_d);
        gr.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
    }
}