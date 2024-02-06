using System;

// Parent Class
// Holds the color of the shape.
// Responsible for getting/setting the color of the shape, and having an 
// abstract method for calculating area.
public abstract class Shape
{
    // Attribute
    private string _color;

    // Constructor
    public Shape(string color)  // Can instantiate with color
    {
        _color = color;
    }

    // Methods
    public string GetColor()   // return the color
    {
        return _color;
    }

    public void SetColor(string color)  // Set the color
    {
        _color = color;
    }

    public abstract double GetArea();   // Calculate the area of the shape
}