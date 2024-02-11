using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager menu = new GoalManager();

        // Welcome the user
        Console.Clear();
        Console.WriteLine("Gratitude and Welcome to the Goal Gamification App");
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