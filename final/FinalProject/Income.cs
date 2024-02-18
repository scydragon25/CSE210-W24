using System;

// Child Class : Transaction
// No additional attributes
// Responsible for giving a unique string representation.
public class Income : Transaction
{
    // No Additional Attributes

    // Constructor
    public Income(string date, double value, string description, string category)
        : base(date, value, description, category)
    {}

    // Methods
    public override string GetStringRepresentation()        // Return a string representation for
    {   // storing objects on a text file
        // String Format:
        // ClassType|Date:Value;Descrition@Category
        return $"Income|{GetDate()};{GetDescription()}:{base.GetValue()}={GetCategory()}";
    }
}