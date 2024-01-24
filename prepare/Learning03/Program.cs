using System;

class Program
{
    static void Main(string[] args)
    {
        // Create tests
        Fraction test1 = new Fraction();
        Fraction test2 = new Fraction(5);
        Fraction test3 = new Fraction(6,7);

        // Manually Print the fractions
        Console.WriteLine(test1.GetTop()+"/"+test1.GetBottom());
        Console.WriteLine(test2.GetTop()+"/"+test2.GetBottom());
        Console.WriteLine(test3.GetTop()+"/"+test3.GetBottom());

        // Set new value for test1
        test1.SetTop(3);
        test1.SetBottom(7);

        // Check if Set worked
        Console.WriteLine(test1.GetTop()+"/"+test1.GetBottom());


        // Check if the other methods work for displaying the value
        Console.WriteLine(test3.GetFractionString());
        double testD = test3.GetDecimalValue();
        Console.WriteLine(testD);
    }
}