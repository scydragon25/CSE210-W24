using System;

// Child Class of Shape
// Holds the value of a single side.
// Responsible for calculating the area of a square.
public class Square : Shape
{
    // Attributes
    private double _side;

    // Constructor
    public Square(string color, double side)
        : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side*_side;
    }
}