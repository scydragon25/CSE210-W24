using System;

class Program
{
    static void Main(string[] args)
    {
        int guess = 0;
        int attempts = 0;   // Track # of guesses.
        string keepPlaying = "Yes";
        
        // 1. Ask for the magic number.
        //Console.Write("What is the magic number? ");
        //ans = int.Parse(Console.ReadLine());

        while (keepPlaying == "Yes")
        {
            // 3. Random Magic Number
            Random randomGenerator = new Random();
            int ans = randomGenerator.Next(1, 100);

            // Play
            do
            {
                // Ask the user for a guess.
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                // Higher or Lower?
                if (guess == ans)
                {
                    Console.WriteLine("You guessed it!");
                }
                else if (guess < ans)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }

                // Increment attempts
                attempts++;
            } while (guess != ans);

            // Report on the number of attempts taken
            Console.WriteLine($"You took {attempts} guess(es).");
            attempts = 0;   // Reset

            // Continue?
            Console.Write("Do you wish to play again? (Yes/No) ");
            keepPlaying = Console.ReadLine();
        }

    }
}