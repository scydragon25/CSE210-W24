using System;

// Child Class
// Responsible for holding a list of random prompts and reflective questions.
// Responsible for guiding the user to reflect on their life.
public class ReflectingActivity : Activity
{
    // Attributes
    List<string> _prompts = new List<string>();
    List<string> _questions = new List<string>();

    // Constructor
    public ReflectingActivity()
        : base("Reflecting Activity",
                "This activity will help you reflect on times in you life "+
                "when you have shown strength and resilience. This will "+
                "help you recognize the power you have and how you can use "+
                "it in other aspects of you life.")
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did somthing truly selfless.");
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    // Methods
    public void Run()   // // Display text, helping the user reflect on their life
    {
        // Intro
        this.DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        this.ShowSpinner(3);
        Console.WriteLine();

        // Begin
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press <Enter> to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        this.GetCountDown();
        Console.Clear();
        DisplayQuestions();
    }

    private void DisplayPrompt()    // Display prompt
    {
        Console.WriteLine(" --- "+GetRandomPrompt()+" --- ");
    }

    private void DisplayQuestions() // Display questions, one at a time. Timed.
    {
        // Timed
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(this.GetDuration());
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> "+GetRandomQuestion());
            this.ShowSpinner(10);
            Console.WriteLine();
        }
    }

    private string GetRandomPrompt()    // Return a random prompt from the list of prompts
    {
        // Random number generator
        Random rnd = new Random();

        return _prompts[rnd.Next(0,_prompts.Count()-1)];
    }

    private string GetRandomQuestion()    // Return a random question from the list of questions
    {
        // Local Variables
        Random rnd = new Random();
        string question;
        int index;

        index = rnd.Next(0,_prompts.Count()-1);
        question = _questions[index];
        _questions.RemoveAt(index);

        return question;
    }
}