using System;

// Child Class
// Additionally tracks the last day the event was done.
// Responsible for displaying a goal summary, reseting the goal status, updating
//  the completion status, and generating a string representation of a goal object.
public class EternalGoal : Goal
{
    // Additional Attributes
    private DateTime _date; 

    // Constructor
    public EternalGoal(string name, string description)
        : base(name, description, 50) 
    {}  // Default Eteranal Goals to give 100 points for each time done

    // Methods
    public override void CompleteGoal()     // Set the completion status to true, and mark the date
    {
        _date = DateTime.Today; // Get todays date
        base.CompleteGoal();
    }

    public override void DisplayGoal()      // Display the goal summary for an eternal goal
    {
        // Check if Complete
        char x = ' ';   // Default that the goal is not completed
        if (GetCompletionStatus())
        {
            // Check if the goal event happened today
            if (CheckSameDate())
            {
                // Since Eternal Goals never truly end,
                // a slash simply indicates that it has been done for the current time interval
                x = '/';
            }
            else // The goal event did not happen today
            {
                ResetCompletionStatus();
            }
        }

        // Display
        Console.WriteLine($" [{x}]  {GetName()}: {GetDescription()}");   
    }

    public override int GetPoints()         // Returns the number of points for doing the goal
    {
        if (GetCompletionStatus())
        {
            return 0;
        }
        else
        {
            return base.GetPoints();
        }
    }

    public override string GetStringRepresentation()        // Convert the object attributes into a string
    {   
        // Check if the goal event happened before today
        if (!CheckSameDate())
        {
            ResetCompletionStatus();    
        }
        return $"EternalGoal|{GetName()};{GetDescription()},{_date}";
    }

    private bool CheckSameDate()        // Check if today is the same date that the goal event occured
    {
        DateTime todaysDate = DateTime.Today;
        if (todaysDate > _date)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}