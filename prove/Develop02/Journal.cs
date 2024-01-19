using System;
using System.ComponentModel;

// Keep track of prompts and their associated journal entries.
// Be able to see a menu of options:
// 1. Display   2. Save Journal     3. Load Journal     4. Add an Entry
public class Journal
{
    // Attributes
    public PromptGenerator _prompt = new PromptGenerator();
    public List<Entry> _entries = new List<Entry>();

    // Constructor
    public Journal()
    {
    }

    // Methods
    public void Write() // Prompt the user to write in their journal.
    {
        // Create a new entry
        Entry entry = new Entry();
        string query = this._prompt.GetPrompt();

        // Collect user respones
        entry.GetDate();
        entry.GetSignature();
        Console.WriteLine(query);
        entry.GetResponse();

        // Store the prompt
        entry.HoldPrompt(query);

        // Add the entry to the list
        this._entries.Add(entry);
    }

    public void Display()
    {
        foreach (Entry entry in this._entries)
        {
            Console.WriteLine();    // new line space
            entry.Display();
        }
    }
}