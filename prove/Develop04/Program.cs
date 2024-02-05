using System;

class Program
{
    static void Main(string[] args)
    {
        // local variables
        int input;

        // Welcome Message
        Console.Clear();
        Console.WriteLine("Welcome to the Most Mindfulness Module ever.");

        // Main Menu
        do
        {
            Console.WriteLine();    // New Line Space
            Console.WriteLine("Main Menu:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Exit Program");
            Console.Write("Your Choice Here -> ");
            // User choice
            input = int.Parse(Console.ReadLine());
            // Interpret User Choice
            switch (input)
            {
                case 1: // Breathing activity
                    BreathingActivity activity1 = new BreathingActivity();
                    activity1.Run();
                    break;
                case 2: // Reflecting activity
                    ReflectingActivity activity2 = new ReflectingActivity();
                    activity2.Run();
                    break;
                case 3: // Listing activity
                    ListingActivity activity3 = new ListingActivity();
                    activity3.Run();
                    break;
                case 4: // Exit
                    Console.WriteLine("Thank you! See you again soon.");
                    break;
                default:    // Invalid input
                    Console.WriteLine("Apologies! That input is invalid.");
                    Console.WriteLine("When making a choice, choose the number associated with the action you want to take.");
                    Console.WriteLine("i.e. - Enter \"2\" to write in your journal.");
                    break;
            }
            Console.Clear();
        } while (input != 4);
    }
}