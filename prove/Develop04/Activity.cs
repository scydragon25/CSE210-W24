using System;

// Parent Class
// Responsible for holding the name, description, and duration of an activity.
// Responsible for initializing attributes, displaying starting and 
// ending messages, animating a spinner and a countdown.
public class Activity
{
    // Attributes
    private string _name;
    private string _description;
    private int _duration = 0;

    // Constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Methods
    public int GetDuration()    // Return the duration in seconds
    {
        return _duration;
    }

    public void DisplayStartingMessage()    // Write to screen the starting message
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void DisplayEndingMessage()  // Write to screen the ending message
    {
        Console.WriteLine("Well Done!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        this.ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)    // Animate a spinner for x number of seconds
    {
        // A string is a list of chars
        // Each char is a phase of spinner annimation
        string spinner = "|/~\\";

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;  // indexing the animation

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);

            Thread.Sleep(200);

            Console.Write("\b \b"); // Erase the previous characters
            i++;    // increment through the spinner
            i = i%4;    // re-cycle through the string
        }
    }

    public void GetCountDown()  // Display a 5 second countdown
    {
        Console.Write("You may begin in: 5");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("4");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("3");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("2");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("1");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.WriteLine();
    }
}