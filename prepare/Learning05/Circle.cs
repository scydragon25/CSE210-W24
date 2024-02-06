using System;
using System.Net.NetworkInformation;

// Child class of shape
// Holds the radius of a circle.
// Responsible for calculate the area of a circle.
public class Circle : Shape
{
    // Attributes
    private double _radius;

    // Constructor
    public Circle(string color, double radius)
        : base(color)
    {
        _radius = radius;
    }

    // Methods
    public override double GetArea()    // Calculate the area of the circle
    {
        return Math.PI*_radius*_radius;
    }
}