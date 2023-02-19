using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
    internal abstract class Program
    {
        private static readonly Figure[] Figures =
        {
            new Rectangle(50, 50)
            {
                Name = "Квадрат",
                Color = Color.DarkRed,
                Position = new Point(30, 30),
            },
            new Circle(100)
            {
                Name = "Круг",
                Color = Color.Aquamarine,
                Position = new Point(300, 300),
            },
            new Parallelogram(100, 50, 60)
            {
                Name = "Паралеллограм",
                Position = new Point(125, 125),
                Color = Color.Brown
            },
            new Square(50)
            {
                Name = "Квадрат",
                Position = new Point(255, 255),
                Color = Color.Crimson
            },
            new Triangle(50,50,Math.Sqrt(2))
            {
                Name = "Треугольник",
                Position = new Point(455, 255),
                Color = Color.Crimson
            },
            new Trapezoid(60, 20, 40)
            {
                Name = "Трапеция",
                Position = new Point(555, 355),
                Color = Color.Crimson
            },
            new Rhombus(60, 30)
            {
                Name = "Ромб",
                Position = new Point(455, 155),
                Color = Color.Aquamarine
            },
            new RegularPentagon(50)
            {
                Name = "Пятиугольник",
                Position = new Point(155, 355),
                Color = Color.Aquamarine
            },
            new RegularDecagon(30)
            {
                Name = "Десятиугольник",
                Position = new Point(155, 255),
                Color = Color.Aquamarine
            },
        };

        private static void Main()
        {
            // ShowLab2();
            Console.WriteLine("Лаборатнорная работа №3 - Полиморфизм");
            Console.WriteLine("Выпонил - Даниил Боровой");
            
            Figure f = new Rectangle(50, 50)
            {
                Name = "Квадрат",
                Color = Color.DarkRed,
                Position = new Point(30, 30),
            };
            Console.WriteLine("Фигура: " + f.Name);
            Console.WriteLine("Площадь: " + f.GetArea());
            Console.WriteLine("Цвет: " + f.Color);
            Console.WriteLine("Положение фигуры: " + f.Position);
            Console.WriteLine("Координаты центра: " + f.GetCenter());

            Form form = new Form()
            {
                Text = "Лабораторная №3 - Полиморфизм",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen
            };

            form.Paint += FrmPaint;

            Application.Run(form);
        }

        private static void FrmPaint(object sender, PaintEventArgs e)
        {
            foreach (var figure in Figures)
            {
                figure.Draw(e.Graphics);
            }
        }

        private static void ShowLab2()
        {
            Console.WriteLine("Лабораторная работа №2 - Наследование");

            var a = new Rectangle(15.2, 13.7)
            {
                Name = "Прямоугольник A"
            };

            var b = new Rectangle(5.1, 2.8)
            {
                Name = "Прямоугольник Б"
            };

            Console.WriteLine();
            Console.WriteLine("Название фигуры: {0}", a.Name);
            Console.WriteLine("Площадь фигуры: {0}", a.GetArea());
            Console.WriteLine();
            Console.WriteLine("Название фигуры: {0}", b.Name);
            Console.WriteLine("Площадь фигуры: {0}", b.GetArea());

            var list = new List<Figure>()
            {
                new Circle(5) { Name = "Круг" },
                new Square(10) { Name = "Квадрат" },
                new Triangle(1, 1, Math.Sqrt(2)) { Name = "Треугольник" },
                new Trapezoid(3, 4, 5) { Name = "Трапеция" },
                new Rhombus(2, 4) { Name = "Ромб" },
                new Parallelogram(4, 2) { Name = "Параллелограмм" },
                new RegularPentagon(4) { Name = "Правильный пятиугольник" },
                new RegularDecagon(3) { Name = "Правильный десятиугольник" }
            };

            foreach (var figure in list)
            {
                Console.WriteLine("\nНазвание фигуры: {0}", figure.Name);
                Console.WriteLine("Площадь фигуры: {0} \n", figure.GetArea());
            }
        }
    }
}