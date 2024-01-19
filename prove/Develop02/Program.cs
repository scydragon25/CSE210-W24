using System;
using System.Collections;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Variables
        Journal journal = new Journal();
        int input = 0;

        // Welcome Message
        Console.WriteLine("Welcome to the Best Journal Program that will solve many of your journal keeping needs!");

        // Main Menu
        do
        {
            Console.WriteLine();    // New Line Space
            Console.WriteLine("Main Menu:");
            Console.WriteLine(" 1. Display your Journal");
            Console.WriteLine(" 2. Write in your Journal");
            Console.WriteLine(" 3. Save your Journal to a .txt file");
            Console.WriteLine(" 4. Load a Journal from a .txt file");
            Console.WriteLine(" 5. Exit Program");
            Console.Write("Your Choice Here -> ");
            // User choice
            input = int.Parse(Console.ReadLine());
            // Interpret User Choice
            switch (input)
            {
                case 1: // Display
                    journal.Display();
                    break;
                case 2: // Write
                    journal.Write();
                    break;
                case 3: // Save
                    Save(journal);
                    break;
                case 4: // Load
                    journal = Load(journal);
                    break;
                case 5: // Exit
                    Console.WriteLine("Thank you! See you again soon.");
                    break;
                default:    // Invalid input
                    Console.WriteLine("Apologies! That input is invalid.");
                    Console.WriteLine("When making a choice, choose the number associated with the action you want to take.");
                    Console.WriteLine("i.e. - Enter \"2\" to write in your journal.");
                    break;
            }
        } while (input != 5);

    }

    static void Save(Journal journal)
    {
        // Get a filename from the user.
        Console.Write("Enter file name. Please include \".txt\" at the end. ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in journal._entries)
            {
                // Each string gets its own line
                outputFile.WriteLine(entry._date);
                outputFile.WriteLine(entry._prompt);
                outputFile.WriteLine(entry._response);
                outputFile.WriteLine(entry._signature);
            }
        }
    }

    static Journal Load(Journal prevJournal)
    {
        Journal newJournal = new Journal();
        Entry entry;

        // Get a filename from the user.
        Console.Write("Enter file name. Please include \".txt\" at the end. ");
        string fileName = Console.ReadLine();

        // Check if the file exists. If it doesn't, return the already existing journal object.
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Error: Could not find the file you provided.");
            return prevJournal;
        }
        
        //  Read the file into seperate lines.
        string[] lines = System.IO.File.ReadAllLines(fileName);

        // File should be ordered:
        //  Date
        //  Prompt
        //  Response
        //  Signature
        //  repeat
        for(int i=0; i<lines.Count(); i+=4)
        {
            // Create a new entry
            entry = new Entry();
            // Copy from the text file to the journal
            entry._date = lines[i];
            entry._prompt = lines[i+1];
            entry._response = lines[i+2];
            entry._signature = lines[i+3];
            // Add entry to journal
            newJournal._entries.Add(entry);
        }

        return newJournal;
    }
}