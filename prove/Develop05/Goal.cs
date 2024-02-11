using System;

// Parent Class
// Keeps track of the name, description, points, and completion status of a goal.
// Responsible for displaying the goal, giving points, changing the status of the goal,
//  declaring needed getters/setters, and getting a string representation of the object.
public abstract class Goal
{
    // Attributes
    private string _name;   // Name of the goal
    private string _description;    // A short description of the goal
    private int _points;    // How many point is the goal worth when you do it
    private bool _isComplete;   // Has the goal been completed?

    // Constructor
    public Goal(string name, string description, int points)
    {
        // User fed variables
        _name = name;
        _description = description;

        // By default the goal is uncompleted
        _isComplete = false;

        // points will be defaulted by each child class
        _points = points;
    }

    // Methods
    public abstract void DisplayGoal();     // Will display the goal summary

    public abstract string GetStringRepresentation();       // Will convert the attributes into a single string

    public virtual void CompleteGoal()      // Set the status of the goal to be complete
    {
        _isComplete = true;
    }

    public virtual int GetPoints()         // Returns the number of points for doing the goal
    {
        return _points;
    }

    public string GetName()        // Return the name of the goal
    {
        return _name;
    }   

    public string GetDescription()      // Return the description of the goal
    {
        return _description;
    }

    public bool GetCompletionStatus()       // Return the completion status of the goal
    {
        return _isComplete;
    }

    public void ResetCompletionStatus()     // Set the completion status of the goal to false
    {
        _isComplete = false;
    }
}