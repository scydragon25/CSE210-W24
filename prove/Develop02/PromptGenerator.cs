using System;

// Responsible for hold different journal prompts.
// Will randomly select a prompt when asked.
public class PromptGenerator
{
    // Attributes
    public List<string> _prompts = new List<string>();
    
    // Constructor
    public PromptGenerator()
    {
        this._prompts.Add("Who was the most interesting person I interacted with today?");
        this._prompts.Add("What was the best part of my day?");
        this._prompts.Add("How did I see the hand of the Lord in my life today?");
        this._prompts.Add("What was the strongest emotion I felt today?");
        this._prompts.Add("If I had one thing I could do over today, what would it be?");
    }

    // Methods
    public string GetPrompt()   // Return a prompt
    {
            Random randomGenerator = new Random();
            int select = randomGenerator.Next(0, this._prompts.Count-1);

            return this._prompts[select];
    }
}