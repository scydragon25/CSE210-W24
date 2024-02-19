using System;

// Child Class : Transaction
// No additional attributes
// Responsible for giving a unique string representation.
public class Expense : Transaction
{
    // No Additional Attributes

    // Constructor
    public Expense(string date, double value, string description, string category)
        : base(date, value, description, category)
    {}

    // Methods
    public override string GetStringRepresentation()        // Return a string representation for
    {   // storing objects on a text file
        // String Format:
        // ClassType|Date;Descrition:Value=Category?didHappen
        return $"Expense|{GetDate()};{GetDescription()}:{base.GetValue()}={GetCategory()}?{GetStatus()}";
    }

    public override double GetValue()       // Return the value of the transaction
    {
        return -1*base.GetValue();
    }
}