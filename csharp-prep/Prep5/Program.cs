using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        number = SquareNumber(number);
        DisplayResult(name, number);
    }


    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }


    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }


    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }


    static int SquareNumber(int x)
    {
        return x*x;
    }


    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}