namespace Lab3;

using System.Drawing;

public abstract class Figure
{
    public string? Name { get; init; }
    
    public Color Color { get; set; }
    
    public Point Position { get; set; }
    
    public abstract double GetArea();
    
    public abstract Point GetCenter();

    public abstract void Draw(Graphics gr);
}