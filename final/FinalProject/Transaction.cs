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
    public void Display()       // Display the transaction
    {
        // Desired Format:
        // Date |   $Value  |   Description |   Category
    }

    public void SetStatus()     // Set the status of the transaction that it has happened.
    {
        _didHappen = true;
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
        // ClassType|Date;Descrition:Value=Category
    
}