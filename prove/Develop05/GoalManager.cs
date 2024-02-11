using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.IO;

// Holds a list of different goals and tracks the user score
// Responsible for running a menu loop, displaying the user's score,
//  listing goal names or an entire summary, creating new goals, recording
//  goal related events, and saving/loading goals to a .txt file.
public class GoalManager
{
    // Attributes
    private List<Goal> _goals;
    private int _score;
    private int _lvl;

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0; // Start out with zero points
        _lvl = 1;   // Start out at level one
    }

    // Methods
    public void Start()     // Display and run a menu loop
    {
        // Local Variables
        int input; 

        // Main Menu
        do
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine(" 1. Create a New Goal");
            Console.WriteLine(" 2. Report a Goal Event");
            Console.WriteLine(" 3. List Your Goals");
            Console.WriteLine(" 4. Display Score Board");
            Console.WriteLine(" 5. Save Your Profile");
            Console.WriteLine(" 6. Load Your Profile");
            Console.WriteLine(" 7. Exit Program");
            Console.WriteLine();
            Console.Write("Action Number Here -> ");
            // User choice
            input = int.Parse(Console.ReadLine());
            // Interpret User Choice
            switch (input)
            {
                case 1: // Create Goal
                    CreateGoal();
                    break;
                case 2: // Record Event
                    RecordEvent();
                    break;
                case 3: // List Goal Summary
                    ListGoalSummary();
                    break;
                case 4: // Display Player Info
                    DisplayPlayerInfo();
                    break;
                case 5: // Save Goals/Score
                    SaveGoals();
                    break;
                case 6: // Load Goals/Score
                    _goals = LoadGoals(_goals);
                    break;
                case 7: // Exit
                    break;
                default:    // Invalid input
                    Console.WriteLine("Apologies! That input is invalid.");
                    Console.WriteLine("When making a choice, choose the number associated with the action you want to take.");
                    Console.WriteLine("i.e. - Enter \"2\" to record a new goal related event.");
                    break;
            }
        } while (input != 7);
    }

    private void CreateGoal()   // Prompt the user to create a new goal. Add it to the list of goals.
    {
        // Local Variables
        int input;
        string name;
        string description;

        //Display Goal Types
        Console.Clear();
        Console.WriteLine("What type of goal do you want to set?");
        Console.WriteLine(" 1. Simple - i.e. Visit Rome");
        Console.WriteLine(" 2. Eternal - i.e. Write in My Journal Every Day");
        Console.WriteLine(" 3. Numbered - i.e Call 10 People this Month");
        Console.WriteLine();
        Console.Write("Type the number next to the goal type -> ");
        // User choice
        input = int.Parse(Console.ReadLine());

        // Get goal name and description
        Console.Clear();
        Console.Write("Give your goal a name: ");
        name = Console.ReadLine();
        Console.Write("Describe this goal: ");
        description = Console.ReadLine();

        // Create a new goal object and add it to the list of goals
        switch (input)
        {
            case 1: // Simple Goal
                _goals.Add(new SimpleGoal(name, description));
                break;
            case 2: // Eternal Goal
                _goals.Add(new EternalGoal(name, description));
                break;
            case 3: // Numbered Goal
                // Get the target number
                Console.Write("What is the target number for this goal? ");
                int target = int.Parse(Console.ReadLine());
                _goals.Add(new NumberedGoal(name, description, target));
                break;
            default:    // Error
                Console.WriteLine("Error: There was an issue with your selection. Please try again.");
                break;
        }
    }

    private void RecordEvent()       // Prompt the user to report on progress for their goals. Reward Points.
    {                               //  Update Completion Status.
        // Local Variables
        string input;
        int option = 1;
        List<Goal> activeGoals = new List<Goal>();
        
        // Did the user make progress toward a goal?
        Console.Clear();
        Console.WriteLine("Did you make progress toward one of your goals today?");
        Console.Write("(y/n) ");
        input = Console.ReadLine();

        // If No, then do not continue on
        if (input=="n")
        {
            return;
        }
        // Else continue

        // Which Goal did the user make progress on?
        activeGoals = ListActiveGoals();
        Console.Clear();
        Console.WriteLine("Below are a list of your active goals:"); 
        foreach(Goal goal in activeGoals)
        {
            Console.WriteLine($" {option}. {goal.GetName()}");
            option++;
        }
        Console.Write("Type the number of the goal you made progress on -> ");
        option = int.Parse(Console.ReadLine());

        // Make sure the user selected a valid option
        if ((option <= activeGoals.Count) & option > 0)
        {
            // Award Points
            _score += activeGoals[option-1].GetPoints();

            // Evaluate Gamification Lvl
            EvaluateLvl();

            // Update the Completion Status
            activeGoals[option-1].CompleteGoal();
        }
    }

    private void EvaluateLvl()      // Update Gamification Lvl based on the current score.
    {                               // Give out prizes
        if (_score>10000)   // If the user has exceeded 10k points
        {
            // then advance a lvl
            _lvl++;

            // Dispense the prize
            Console.Clear();
            Console.WriteLine($"Congrats User! You have reached Lvl: {_lvl}!");
            Console.WriteLine("Have a slice of cake tonight to celebrate.");
        }
    }

    private List<Goal> ListActiveGoals()        // Parse out the active goals from the list of _goals.
    {
        // Local Variables
        List<Goal> activeGoals = new List<Goal>();

        foreach (Goal goal in _goals)
        {
            // Sort out non-eternal goals that have been completed
            if ((goal is EternalGoal) | (goal.GetCompletionStatus()==false))
            {
                activeGoals.Add(goal);
            }
        }

        return activeGoals;
    }

    private void ListGoalSummary()      // Call each goal's display method to display a list of all goal.
    {
        Console.Clear();
        foreach (Goal goal in _goals)
        {
            goal.DisplayGoal();
        }

        // Wait for the user to continue
        Console.WriteLine();
        Console.WriteLine("Press <Enter> to return");
        Console.ReadLine();
    }

    private void DisplayPlayerInfo()        // Display the user's score
    {
        Console.Clear();
        Console.WriteLine($"    Player Lvl: {_lvl}");
        Console.WriteLine($"        Points: {_score}");
        
        // Wait for the user to continue
        Console.WriteLine();
        Console.WriteLine("Press <Enter> to return");
        Console.ReadLine();
    }

    private void SaveGoals()     // Save to a file name, mirrored after the user's name
    {
        // Local Variables
        string fileName;

        Console.Clear();
        // Get a filename from the user.
        Console.Write("Enter file name. Please include \".txt\" at the end. ");
        fileName = Console.ReadLine();

        // Check if the file already exists
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        // Create a new file
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"{_lvl}|{_score}");   // First Line will contain the lvl and score of the player
            foreach(Goal goal in _goals)    // Each following lines will be goals.
            {
                // Each goal gets its own line
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    private List<Goal> LoadGoals(List<Goal> prevList)
    {
        // Local Variables
        List<Goal> newGoals = new List<Goal>();
        string fileName;
        string type;
        string name;
        string description;
        int numDone = 0;    // 0 by default
        int target = 1; // 1 by default
        DateTime date = DateTime.Today; // today by default
        bool isComplete = false;    // false by default
        
        Console.Clear();
        // Get a filename from the user.
        Console.Write("Enter file name. Please include \".txt\" at the end. ");
        fileName = Console.ReadLine();

        // Check if the file exists. If it doesn't, return the already existing journal object.
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Error: Could not find the file you provided.");
            // Wait for the user to continue
            Console.WriteLine();
            Console.WriteLine("Press <Enter> to return");
            Console.ReadLine();
            return prevList;
        }
        
        //  Read the file into seperate lines.
        string[] lines = System.IO.File.ReadAllLines(fileName);

        // The first line contains the player's lvl and score
        string[] parse0 = lines[0].Split('|');
        _lvl = int.Parse(parse0[0]);    // text before | is the player lvl
        _score = int.Parse(parse0[1]);  // text after | is the player score

        // Each line after is an instance of a goal.
        foreach (string line in lines.Skip(1))
        {
            // Begin Parsing the line
            string[] parse1 = line.Split('|');
            type = parse1[0];   // text before | is the object type
            string[] parse2 = parse1[1].Split(';');
            name = parse2[0];   // text before ; is the goal name
            string[] parse3 = parse2[1].Split(',');
            description = parse3[0];    // text before , is the goal description
            if (type=="NumberedGoal")   // if the goal is a numbered goal
            {
                // then the txt after , is the number done over the target number
                string[] parse4 = parse3[1].Split('/');
                numDone = int.Parse(parse4[0]);
                target = int.Parse(parse4[1]);
            }
            else if (type=="EternalGoal")   // if the goal is an eternal goal
            {
                // then the txt after , is the prev date the task was done
                date = DateTime.Parse(parse3[1]);
            }
            else    // else the txt after , is the completion status
            {
                isComplete = bool.Parse(parse3[1]);
            }

            // Create a goal from the line
            if (type=="SimpleGoal") // if the goal is a single goal
            {
                SimpleGoal goal = new SimpleGoal(name, description);
                if (isComplete) // if the goal is complete
                {
                    goal.CompleteGoal();
                }
                newGoals.Add(goal);
            }
            else if (type=="EternalGoal")   // if the goal is an eternal goal
            {
                EternalGoal goal = new EternalGoal(name, description);
                DateTime today = DateTime.Today;
                if (date==today)    // if the date in the file line is today
                {
                    // then the task was already completed for today
                    goal.CompleteGoal();
                }
                newGoals.Add(goal);
            }
            else // the goal is a numbered goal
            {
                NumberedGoal goal = new NumberedGoal(name, description, target);
                // Increment the object attribute for number of time done
                for (int i=0; i<numDone; i++)
                {
                    goal.GetPoints();   // Don't regain points, just increment _numDone
                }
                newGoals.Add(goal);
            }
        }

        return newGoals;
    }
}