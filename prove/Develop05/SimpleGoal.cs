using System;

// Child Class : Goal
// No additional attributes to track.
// Responsible for displaying a goal summary and generating a string representation of a goal object.
public class SimpleGoal : Goal
{
    // No additional attributes needed

    // Constructor
    public SimpleGoal(string name, string description)
        : base(name, description, 1000) // Default Simple Goals to give 1000 points
    {}

    // Methods
    public override void DisplayGoal()      // Display the goal summary for a simple goal
    {
        // Check if Complete
        char x = ' ';   // Default that the goal is not completed
        if (GetCompletionStatus())
        {
            x = 'X';
        }

        // Display
        Console.WriteLine($" [{x}]  {GetName()}: {GetDescription()}");
    }

    public override string GetStringRepresentation()        // Convert the object attributes into a string
    {
        return $"SimpleGoal|{GetName()};{GetDescription()},{GetCompletionStatus()}";
    }

    
}