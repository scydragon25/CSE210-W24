using System;

// Parent Class
// Holds the name, description, and cash value of the goal. Tracks
//  whether the goal is planned on the budget or if it has happened.
// Responsible for displaying the goal; getting the name, cash value,
//  description, string representation, and whether or not it is planned 
//  or happen; and setting when it is planned for or happened.
public abstract class Goal
{
    // Attributes
    private string _name;   // Name of the goal
    private string _description;    // Goal description
    private double _value;  // Cash value of the goal
    private bool _didHappen;    // Has the goal actually been reached?
    private bool _isPlanned;    // Has the goal been planned for?

    // Constructor
    public Goal(string name, string description, double value)
    {
        // Default Attributes
        _didHappen = false;
        _isPlanned = false;

        // User fed attributes
        _name = name;
        _description = description;
        _value = value;
    }

    // Methods
    public void Display()       // Display the goal
    {
        // Desired Format:
        //  [X]     [X]     Name:   Description
    }

    public string GetName()     // Return the name of the goal
    {
        return _name;
    }

    public string GetDescription()      // Return the goal description
    {
        return _description;
    }

    public double GetValue()        // Return the cash value of the goal
    {
        return _value;
    }

    public bool DidItHappen()     // Return whether the goal has actually happened
    {
        return _didHappen;
    }

    public bool IsItPlanned()     // Return whether the goal is planned for
    {
        return _isPlanned;
    }

    public virtual void Happened(double total, int option)      // Set that the goal happened
    {
        // Child class needs to include logic for if the attribute
        //  is set to 'true'
        //  And it need as switch case for when loading in goals
        _didHappen = true;
    }

    public virtual void Planned(double total, int load)      // Set that the goal is planned
    {
        // Child class needs to include logic for if the attribute
        //  is set to 'true'
        //  And it need as switch case for when loading in goals
        _isPlanned = true;
    }

    public abstract string GetStringRepresentation();     // Return a string representation for
        // storing objects on a text file
        // String Format:
        // ClassType|Name;Descrition:Value=didHappen?isPlanned
}