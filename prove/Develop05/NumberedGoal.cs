using System;
using System.Drawing;

// Child Class : Goal
// Additionally hold the target number of events and track the number of events done.
// Responsible for displaying the goal summary, awarding points, updating the
//  completion status of the goal, and generating a string representation of a goal object.
public class NumberedGoal : Goal
{
    // Addition Attributes
    private int _target;    // How many events need to be complete
    private int _numDone;   // Number of events done so far

    // Constructor
    public NumberedGoal(string name, string description, int target)
        : base(name, description, 100) 
      // Default Numbered Goals to give 100 points for each time done
    {
        // User fed variable
        _target = target;

        // By default there have been zero events done toward the goal
        _numDone = 0;
    }

    // Methods
    public override void CompleteGoal()     // If the conditions are right, set the completion status to true
    {
        if (_numDone>=_target)
        {
            base.CompleteGoal();
        }
    }

    public override void DisplayGoal()      // Display the goal summary for a numbered goal
    {
        Console.WriteLine($" [{_numDone}/{_target}]  {GetName()}: {GetDescription()}");
    }

    public override int GetPoints()     // Award the base points. If the goal is reach, give bonus points
    {                                   // Warning: Always call CompleteGoal() after GetPoints()
        // Increment number done
        _numDone++;
        
        // Check if the goal was already reach
        if (GetCompletionStatus())  // If completed already
        {
            return 0;  // then the points were previously given
        }
        else if (_numDone==_target) // If the target was just hit
        {
            return base.GetPoints()*_numDone;    // give bonus points
        }
        else    // else award the base number of points
        {
            return base.GetPoints();
        }
    }

    public override string GetStringRepresentation()        // Convert the object attributes into a string
    {   
        return $"NumberedGoal|{GetName()};{GetDescription()},{_numDone}/{_target}";
    }
}