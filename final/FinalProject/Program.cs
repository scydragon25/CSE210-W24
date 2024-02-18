using System;

class Program
{
    static void Main(string[] args)
    {
        BudgetManager menu = new BudgetManager();

        // Welcome the user
        Console.Clear();
        Console.WriteLine("Welcome to the #1 competitor of Ramsey Solution!");
        // Wait for the user to continue
        Console.WriteLine();
        Console.WriteLine("Press <Enter> to Begin");
        Console.ReadLine();
        
        // Run
        menu.Start();

        // Goodbye;
        Console.Clear();
        Console.WriteLine("Gratitude and Goodbye!");
    }
}