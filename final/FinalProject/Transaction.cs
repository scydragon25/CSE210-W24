using System;

// Parent Class
// Holds the date, cash amount, description, and category of a transaction.
//  Also tracks whether the transaction has occured.
// Responsible for displaying the transaction; getting the date, cash value,
//  description, category, string representation, and whether or not it has 
//  happen; and setting when it does happen.
public abstract class Transaction
{
    // Attributes
    private string _date;   // when the transaction will/did happen
    private double _value; // absolute cash value of transaction
    private string _description;    // what is the transaction
    private string _category;   // Organizing the transactions
    private bool _didHappen;    // The transaction already happened. (T/F)

    // Constructor
    public Transaction(string date, double value, string description, string category)
    {
        // Default Attribute
        _didHappen = false;

        // User Fed Attributes
        _date = date;
        _value = value;
        _description = description;
        _category = category;
    }

    // Methods
    public void Display(int index)       // Display the transaction
    {
        // Truncate Description if longer than 32
        if (_description.Length > 32)
        {
            _description = _description.Substring(0, 29)+"...";
        }
        // Truncate Category if longer than 8
        if (_category.Length > 8)
        {
            _category = _category.Substring(0, 5)+"...";
        }

        // Desired Format:
        // Date |   $Value  |   Description |   Category
        Console.Write("{0,-12}{1,10}{2,-35}{3,-12}{4,-2}",
                            $" {index}| {_date} |",
                            $"{_value:n2} ",
                            $"| {_description}",
                            $"| <{_category}>",
                            "||");
    }

    public void SetStatus()     // Set the status of the transaction that it has happened.
    {
        _didHappen = true;
    }

    public void SetDate(string date)        // Set the date of the transaction
    {
        _date = date;
    }

    public void SetValue(double value)      // Set the absolute cash value of the transaction
    {
        _value = value;
    }

    public void SetDescription(string description)      // Set the transaction description
    {
        _description = description;
    }

    public void SetCategory(string category)        // Set the transaction category
    {
        _category = category;
    }

    public bool GetStatus()     // Return the status of the transaction. Has is happened?
    {
        return _didHappen;
    }

    public virtual double GetValue()        // Return the value of the transaction
    {
        return _value;
    }

    public string GetDate()     // Return the date of the transaction
    {
        return _date;
    }

    public string GetDescription()      // Return the transaction description
    {
        return _description;
    }

    public string GetCategory()     // Return the transaction category
    {
        return _category;
    }

    public abstract string GetStringRepresentation();     // Return a string representation for
        // storing objects on a text file
        // String Format:
        // ClassType|Date;Descrition:Value=Category?didHappen
}