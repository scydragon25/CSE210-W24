using System;

// Responsible for keeping track of the date, user response, user signature,
// and being able to display that information.
public class Entry
{
    // Attributes
    public string _date = "";
    public string _response = "";
    public string _signature = "";
    public string _prompt = "";

    // Constructor
    public Entry()
    {
    }

    // Methods
    public void Display()   // Display contents
    {
        Console.WriteLine(this._date);
        Console.WriteLine(this._prompt);
        Console.WriteLine(this._response);
        Console.WriteLine($" - {this._signature} - ");
    }

    public void GetResponse()   // Answer to a prompt
    {
        Console.Write("Your response here -> ");
        this._response = Console.ReadLine();
    }

    public void GetDate()
    {
        Console.Write("What is today's date? ");
        this._date = Console.ReadLine();
    }

    public void GetSignature()
    {
        Console.Write("Who is writing? ");
        this._signature = Console.ReadLine();
    }

    public void HoldPrompt(string query)
    {
        this._prompt = query;
    }
}