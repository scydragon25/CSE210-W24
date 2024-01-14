using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt User for their name.
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display user name in James Bond fashion.
        Console.WriteLine($"Your name is {lastName}, "+
                        $"{firstName} {lastName}.");
    }
}