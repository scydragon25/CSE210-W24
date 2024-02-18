using System;

// Child Class : Goal
// No addition attributes
// Responsible for uniquely setting the status of whether the goal is
//  planned for or happened, as well as the unique string representation
public class SpendingGoal : Goal
{
    // No Additional Attributes

    // Constructor
    public SpendingGoal(string name, string description, double value)
        : base(name, description, value)
    {}

    // Methods
    public override void Planned(double total, int load)      // set that the goal is planned for
    {
        // Load Case
        // Logic
        base.Planned(total, 0);
    }

    public override void Happened(double total, int load)      // set that the goal has happened
    {
        // Load Case
        // Logic
        base.Happened(total, 0);
    }

    public override string GetStringRepresentation()        // Return a string representation for
    {   // storing objects on a text file
        // String Format:
        // ClassType|Name;Descrition:Value=didHappen?isPlanned
    
        return $"SpendingGoal|{GetName()};{GetDescription()}:{GetValue()}={DidItHappen()}?{IsItPlanned()}";
    }
}