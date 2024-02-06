using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Square square1 = new Square("blue", 5.5);
        Rectangle rectangle1 = new Rectangle("green", 5.5, 3.5);
        Circle circle1 = new Circle("red", 5.5);

        /*
        // Test the Square class
        Console.WriteLine("Color: "+square1.GetColor());
        Console.WriteLine("Area: "+square1.GetArea());
        Console.WriteLine();

        // Test Rectangle
        Console.WriteLine("Color: "+rectangle1.GetColor());
        Console.WriteLine("Area: "+rectangle1.GetArea());
        Console.WriteLine();

        // Test Circle
        Console.WriteLine("Color: "+circle1.GetColor());
        Console.WriteLine("Area: "+circle1.GetArea());
        Console.WriteLine();
        */

        // Build a List
        List<Shape> shapes = new List<Shape>();
        shapes.Add(circle1);
        shapes.Add(square1);
        shapes.Add(rectangle1);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine("Color: "+shape.GetColor());
            Console.WriteLine("Area: "+shape.GetArea());
            Console.WriteLine();
        }
    }
}