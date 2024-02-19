using System;

// Child Class : Goal
// No addition attributes
// Responsible for uniquely setting the status of whether the goal is
//  planned for or happened, as well as the unique string representation
public class EarningGoal : Goal
{
    // No Additional Attributes

    // Constructor
    public EarningGoal(string name, string description, double value)
        : base(name, description, value)
    {}

    // Methods
    public override void Planned(double total, int load)      // set that the goal is planned for
    {
        // Load Case
        if (load==1)
        {
            base.Planned(total, 1);
        }

        // Logic
        if (total >= GetValue())
        {
            base.Planned(total, 0);
        }
    }

    public override void Happened(double total, int load)      // set that the goal has happened
    {
        // Load Case
        if (load==1)
        {
            base.Happened(total, 1);
        }

        // Logic
        if (total >= GetValue())
        {
            base.Happened(total, 0);
        }
    }

    public override string GetStringRepresentation()        // Return a string representation for
    {   // storing objects on a text file
        // String Format:
        // ClassType|Name;Descrition:Value=didHappen?isPlanned
    
        return $"EarningGoal|{GetName()};{GetDescription()}:{GetValue()}={DidItHappen()}?{IsItPlanned()}";
    }
}