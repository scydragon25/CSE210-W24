using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Random Number
        Random rnd = new Random();  // random number generator

        // User Variables
        string text;
        
        string input;

        // Declare Objects
        Reference reference;
        Scripture scripture;

        // Welcome the user
        Console.Clear();
        Console.WriteLine("Welcome to The Supreme Scripture Memorization Module");
        
        // Get Scripture and Reference
        Console.WriteLine("Will you be entering the scripture manually or from a file?");
        do
        {
            Console.WriteLine("If you plan to enter your scripture manually just leave the space empty and press <Enter>.");
            Console.Write("Type the filename (don't forget to include the .txt at the end): ");
            input = Console.ReadLine();
            // If input is empty or null...
            if (string.IsNullOrEmpty(input))
            {
                // then get the user to fill out the text manually
                text = GetTextFromUser();
                Console.WriteLine();
                // and get the user to fill out the reference manually
                reference = GetReferenceFromUser();
            }
            // Else...
            else
            {
                // Parse out the text from a file
                text = GetTextFromFile(input);
                //Parse out the reference from a file
                reference = GetReferenceFromFile(input);
            }
        } while (string.IsNullOrEmpty(text));

        // Store scripture and ref
        scripture = new Scripture(reference, text);

        // Path toward memorization
        do
        {
            // Display
            Console.Clear();
            scripture.DisplayText();
            Console.WriteLine();

            // Hide 3 to 5 words
            scripture.HideRandomWords(rnd.Next(3,5));

            // Prompt to Continue
            Console.WriteLine("Press <Enter> to continue.");
            Console.WriteLine("Type \"quit\" followed by <Enter> to exit the program");
            input = Console.ReadLine();

            // If all words are hidden...
            if (scripture.IsCompletelyHidden())
            {
                // Then exit the loop, and display one last time
                // with all words hidden, before ending program.
                input ="quit";
            }
        } while (string.IsNullOrEmpty(input));

        // Final Display
        Console.Clear();
        scripture.DisplayText();
        Console.WriteLine();
        Console.WriteLine("I believe you can recite the entire scripture from memory now.");
        Console.WriteLine("Goodbye!");
    }

    // Prommpt the User for the text of the scripture
    static string GetTextFromUser()
    {   
        // local variables
        string text ="";

        // Promput User
        Console.WriteLine("To Start, please type up the scripture you want to memorize below, then press <Enter>:");
        text = Console.ReadLine();

        return text;
    }

    // Prompt the User for the reference of the scriputre
    static Reference GetReferenceFromUser()
    {
        // local variables
        string book;
        string chapter;
        string verse1;
        string verse2;
        string input;
        Reference reference;

        // Prompt User
        Console.Write("What book of scripture did this come from? ");
        book = Console.ReadLine();
        Console.Write("What chapter or section did this come from? ");
        chapter = Console.ReadLine();
        do
        {
            Console.WriteLine("Make a selection:");
            Console.WriteLine("This scripute was...");
            Console.WriteLine(" 1. one verse.");
            Console.WriteLine(" 2. mutiple verses.");
            Console.WriteLine(" 3. the whole chapter/section.");
            Console.Write("Your Selection: ");
            input = Console.ReadLine();
            switch (int.Parse(input))
            {
                case 1: // Ex. 1:2
                    Console.Write("What is the verse number? ");
                    verse1 = Console.ReadLine();
                    reference = new Reference(book, chapter, verse1);
                    break;
                case 2: // Ex. 1:2-3
                    Console.Write("What is the starting verse number? ");
                    verse1 = Console.ReadLine();
                    Console.Write("What is the ending verse number? ");
                    verse2 = Console.ReadLine();
                    reference = new Reference(book, chapter, verse1, verse2);
                    break;
                case 3: // Ex. 1
                    reference = new Reference(book, chapter);
                    break;
                default: // Error
                    Console.Clear();
                    Console.WriteLine("Apologies! Your input was invalid.");
                    Console.WriteLine("Please enter <1>, <2>, or <3>.");
                    reference = new Reference("ERROR", "??");
                    input = "0";
                    break;
            }
        } while (int.Parse(input) == 0);

        return reference;
    }

    // Take in a file name and return the text of the scripture
    static string GetTextFromFile(string fileName)
    {   
        // local variables
        string text = "";

        // Check if the file exists. If it doesn't, return the already existing journal object.
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Error: Could not find the file you provided.");
            return text;
        }
        
        //  Read the file into seperate lines.
        string[] lines = System.IO.File.ReadAllLines(fileName);

        // File should be ordered:
        //  Book
        //  Chapter
        //  Starting Verse
        //  Ending Verse
        //  Text
        text = lines[4];

        return text;
    }

    // Take in a file name and return the reference of the scripture
    static Reference GetReferenceFromFile(string fileName)
    {
        // local variables
        string book;
        string chapter;
        string verse1;
        string verse2;
        string[] parts;
        Reference reference;

        // Check if the file exists. If it doesn't, return the already existing journal object.
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Error: Could not find the file you provided.");
            return new Reference("ERROR", "??");
        }

        //  Read the file into seperate lines.
        string[] lines = System.IO.File.ReadAllLines(fileName);

        // File should be ordered:
        //  Book
        //  Chapter
        //  Starting Verse
        //  Ending Verse
        //  Text
        book = lines[0];
        parts = lines[1].Split(" ");
        chapter = parts[1];
        parts = lines[2].Split(" ");
        verse1 = parts[3];
        parts = lines[3].Split(" ");
        verse2 = parts[3];

        // Creat reference
        // If verse1 and verse2 are the same, then there is only one verse
        if (int.Parse(verse2)-int.Parse(verse1)==0)
        {
            reference = new Reference(book, chapter, verse1);
        }
        // Else there are multiple verses
        else
        {
            reference = new Reference(book, chapter, verse1, verse2);
        }
        // The .txt file won't include conditions to indicate if it is a whole chapter or section

        return reference;
    }
}