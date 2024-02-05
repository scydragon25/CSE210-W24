using System;

// Child Class
// Responsible for guiding the user through a breathing exercise.
public class BreathingActivity : Activity
{
    // Attributes
    // No addition attributes needed

    // Constructor
    public BreathingActivity()
        : base("Breathing Acitity",
                "This activity will help you relax by walking you through "+
                "breathing in and out slowly. Clear your mind and focus on "+
                "your breathing.")
    {
    }

    // Method
    public void Run()   // Display text, guiding the user's breathing
    {
        this.DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        this.ShowSpinner(3);
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(this.GetDuration());

        while (DateTime.Now < endTime)
        {
            // Breathe in for 5 sec
            Console.Write("Breate in.");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            

            // Breathe out for 6 sec
            Console.Write("Breathe out......");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.WriteLine();
            Console.WriteLine();
        }

        this.DisplayEndingMessage();
    }
}