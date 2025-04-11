using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set1
{
    public class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a generic shape");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }

    public static class ShapeDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Method Overriding Demonstration ---\n");

            Shape shape = new Shape();
            shape.Draw();

            Circle circle = new Circle();
            circle.Draw();

            // Polymorphism example
            Shape shapeCircle = new Circle();
            shapeCircle.Draw();

            Console.WriteLine("\n--- End of Method Overriding Demonstration ---");
        }
    }
}
