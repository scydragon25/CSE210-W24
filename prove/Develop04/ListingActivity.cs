using System;
using Microsoft.VisualBasic;

// Child Class
// Responsible for holding a random list of prompts and keeping track of the number of user responses.
// Responsible for guiding the user to list good things.
public class ListingActivity : Activity
{
    // Attributes
    private int _count;
    private List<string> _prompts = new List<string>();

    // Constructor
    public ListingActivity()
            : base("Listing Activity",
                "This activity will help you reflect on the good things "+
                "in your life by having you list as many things as you "+
                "can in a certain area.")
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    // Methods
    public void Run()   // Display text, helping the user list the good things
    {
        // Intro
        this.DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        this.ShowSpinner(3);
        Console.WriteLine();

        // Begin
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine(" --- "+GetRandomPrompt()+" --- ");
        Console.WriteLine("Hit <Enter> after each response.");
        this.GetCountDown();

        // User Interaction
        GetListFromUser();

        // Report
        Console.WriteLine($"You listed {_count} items!");
        Console.WriteLine();
        this.DisplayEndingMessage();
    }

    private void GetListFromUser()    // Loop through a list of entries. Return number of entries.
    {
        // Timed
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(this.GetDuration());
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _count++;
        }
    }

    private string GetRandomPrompt()    // Return a random prompt from the list of prompts
    {
        // Random number generator
        Random rnd = new Random();

        return _prompts[rnd.Next(0,_prompts.Count()-1)];
    }
}