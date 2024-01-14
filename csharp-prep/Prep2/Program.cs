using System;

class Program
{
    static void Main(string[] args)
    {
        // Declare variables
        int numGrade;
        string letterGrade;

        // What is the user's grade percentage?
        Console.Write("What is your grade percentage? ");
        numGrade = int.Parse(Console.ReadLine());

        // Determine the user's letter grade
        if (numGrade>=90)
        {
            if ((numGrade%10)>2)
            {
                letterGrade = "A";
            }
            else
            {
                letterGrade = "A-";
            }
        }
        else if (numGrade>=80)
        {
            if ((numGrade%10)>6)
            {
                letterGrade = "B+";
            }
            else if ((numGrade%10)>2)
            {
                letterGrade = "B";
            }
            else
            {
                letterGrade = "B-";
            }
        }
        else if (numGrade>=70)
        {
            if ((numGrade%10)>6)
            {
                letterGrade = "C+";
            }
            else if ((numGrade%10)>2)
            {
                letterGrade = "C";
            }
            else
            {
                letterGrade = "C-";
            }
        }
        else if (numGrade>=60)
        {
            if ((numGrade%10)>6)
            {
                letterGrade = "D+";
            }
            else if ((numGrade%10)>2)
            {
                letterGrade = "D";
            }
            else
            {
                letterGrade = "D-";
            }
        }
        else
        {
            letterGrade = "F";
        }

        // Display the user's letter grade
        Console.WriteLine($"Your letter grade is {letterGrade}.");

        // Is the user passing the class?
        // They need at least a 70
        if (numGrade>=70)
        {
            Console.WriteLine("Keep it up! You're on track to pass");
        }
        else
        {
            Console.WriteLine("Bummer! Currently, you are not passing, "+
                            "but it's never to \nlate to course correct.");
        }
    }
}