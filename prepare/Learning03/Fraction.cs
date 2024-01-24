using System;

public class Fraction
{
    // Attributes
    private int _top;
    private int _bottom;

    // Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNum)
    {
        _top = wholeNum;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Methods
    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return _top+"/"+_bottom;
    }

    public double GetDecimalValue()
    {
        // Cast the int numbers to get a double
        return (double)_top/(double)_bottom;
    }
}