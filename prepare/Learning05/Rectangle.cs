using System;

// Child class of shape
// Holds the length and width of a rectangle.
// Responsible for calculating the area of a rectangle.
public class Rectangle : Shape
{
    // Attributes
    private double _length;
    private double _width;

    // Constructor
    public Rectangle(string color, double length, double width)
        : base(color)
    {
        _length = length;
        _width = width;
    }

    // Methods
    public override double GetArea()    // Calculate the area of the rectangle
    {
        return _length*_width;
    }
}