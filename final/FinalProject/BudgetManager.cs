using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.IO;

// Holds a list of different goals and a budget.
// Responsible for running a menu loop, creating a budget, creating a
//  a goal, and saving/loading goals along side the budget to a .txt file.
public class BudgetManager
{
    // Attributes
    private List<Goal> _goals;  // List of the user's financial goals
    private Budget _budget; // The budget object

    // Constructor
    public BudgetManager()
    {
        // Instantiate List
        _goals = new List<Goal>();

        // Default Budget
        _budget = new Budget("Budget"); // Start with a budget named "Budget"
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
            Console.WriteLine(" 01. Display Budget");
            Console.WriteLine(" 02. Display Summary");
            Console.WriteLine(" 03. Change Budget Name");
            Console.WriteLine(" 04. Create New Budget");
            Console.WriteLine(" 05. Add a Transactin");
            Console.WriteLine(" 06. Edit a Transactin");
            Console.WriteLine(" 07. Delete a Transactin");
            Console.WriteLine(" 08. Create A Finance Goal");
            Console.WriteLine(" 09. Delete A Finance Goal");
            Console.WriteLine(" 10. Save Your Budget");
            Console.WriteLine(" 11. Load Your Budget");
            Console.WriteLine(" 12. Exit Program");
            Console.WriteLine();
            Console.Write("Numbered Selection Here -> ");
            // User choice
            input = int.Parse(Console.ReadLine());
            // Interpret User Choice
            switch (input)
            {
                case 1: // Display Budget
                    Console.Clear();
                    _budget.DisplayBudget();

                    // Wait for the user to continue
                    Console.WriteLine();
                    Console.WriteLine("Press <Enter> to Begin");
                    Console.ReadLine();
                    break;
                case 2: // Display Summary
                    Console.Clear();

                    // Budget Summary
                    Console.WriteLine($" ||\t{_budget.GetName()}");
                    _budget.DisplaySummary();
                    Console.WriteLine();

                    // Goal Summary
                    // Check Status of Goals
                    foreach (Goal goal in _goals)
                    {
                        if (goal is EarningGoal)
                        {
                            goal.Planned(_budget.GetPlannedIncomeTotal(),0);
                            goal.Happened(_budget.GetActualIncomeTotal(),0);
                        }
                        else if (goal is SavingGoal)
                        {
                            goal.Planned(_budget.GetPlannedNetBalance(),0);
                            goal.Happened(_budget.GetActualNetBalance(),0);
                        }
                        else if (goal is SpendingGoal)
                        {
                            goal.Planned(_budget.GetPlannedExpenseTotal(),0);
                            goal.Happened(_budget.GetActualExpenseTotal(),0);
                        }
                    }
                    ListGoalSummary();

                    // Wait for the user to continue
                    Console.WriteLine();
                    Console.WriteLine("Press <Enter> to Begin");
                    Console.ReadLine();
                    break;
                case 3: // Change Budget Name
                    Console.Clear();
                    Console.WriteLine("What would you like the budget name to be?");
                    Console.Write("New Budget Name Here -> ");
                    _budget.SetName(Console.ReadLine());
                    break;
                case 4: // Create New Budget
                    // Local Variable
                    string selection = "";

                    // Warn the user
                    Console.Clear();
                    Console.WriteLine("You have chosen to create a new budget.");
                    Console.WriteLine("Warning: This will delete the exisiting budget.");
                    Console.WriteLine(" Do you wish to continue or go back?");
                    Console.WriteLine("  1. Continue");
                    Console.WriteLine("  2. Go Back");
                    Console.Write("Numbered Selection Here -> ");
                    
                    // User choice
                    selection = Console.ReadLine();
                    
                    // Create Budget
                    if (int.Parse(selection)==1)   // Continue
                    {
                        _budget = new Budget("Budget");
                        break;
                    }
                    else    // Go Back
                    {    
                        break;
                    }
                case 5: // Add a Transaction
                    Console.Clear();
                    _budget.AddTransaction();
                    break;
                case 6: // Edit a Transaction
                    Console.Clear();
                    _budget.EditTransaction();
                    break;
                case 7: // Remove a Transaction
                    Console.Clear();
                    _budget.RemoveTransaction();
                    break;
                case 8: // Create Goal
                    Console.Clear();
                    CreateGoal();
                    break;
                case 9: // Remove Goal
                    Console.Clear();
                    // Show the user the goals
                    ListGoalSummary();
                    Console.WriteLine();
                    Console.WriteLine("Which goal do you wish to remove? Type <#0> to delete none of them.");
                    Console.WriteLine("Numbered Selection Here -> ");
                    if (Console.ReadLine()=="0")
                    {
                        break;
                    }
                    _goals.RemoveAt(int.Parse(Console.ReadLine()));
                    break;
                case 10: // Save Budget
                    Console.Clear();
                    Save();
                    break;
                case 11: // Load Budget
                    Console.Clear();
                    Load();
                    break;
                case 12: // Exit

                    break;
                default:    // Invalid input
                    Console.WriteLine("Apologies! That input is invalid.");
                    Console.WriteLine("When making a choice, choose the number associated with the action you want to take.");
                    Console.WriteLine("i.e. - Enter \"2\" to display your budget summary.");
                    break;
            }
        } while (input != 12);
    }

    private void CreateGoal()   // Prompt the user to create a new goal. Add it to the list of goals.
    {
        // Local Variables
        int input;
        string name;
        string description;
        double value;

        //Display Goal Types
        Console.Clear();
        Console.WriteLine("What type of goal do you want to set?");
        Console.WriteLine(" 1. Saving - i.e. I want to have saved $300 by the end of the month");
        Console.WriteLine(" 2. Spending - i.e. I do not want to spend more than $2000 this month");
        Console.WriteLine(" 3. Earning - i.e I want to make $3000 this month");
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
        Console.Write("What is the cash value for this goal: $");
        value = double.Parse(Console.ReadLine());

        // Create a new goal object and add it to the list of goals
        switch (input)
        {
            case 1: // Saving Goal
                _goals.Add(new SavingGoal(name, description, value));
                break;
            case 2: // Spending Goal
                _goals.Add(new SpendingGoal(name, description, value));
                break;
            case 3: // Earning Goal
                _goals.Add(new EarningGoal(name, description, value));
                break;
            default:    // Error
                Console.WriteLine("Error: There was an issue with your selection. Please try again.");
                break;
        }
    }

    private void ListGoalSummary()      // Call each goal's display method to display a list of all goal.
    {
        // Local Variable
        int index =0;

        // Desired Format:
        //  [X]     [X]     Name:   Description
        Console.WriteLine("{0,12}{1,11}{2,22}{3,-34}",
                            "|| Planned |",
                            "|  Actual |",
                            "|        Name        |",
                            "|          Description          ||");
        Console.WriteLine("===================="+
                            "===================="+
                            "===================="+
                            "===================");
        foreach (Goal goal in _goals)
        {
            goal.Display(index);
            index++;
        }
    }

    private void Save()     // Save to a file name, mirrored after the user's name
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
            // First Line will be the budget name
            outputFile.WriteLine(_budget.GetName());

            // Next, the following lines will be goals
            foreach(Goal goal in _goals)    
            {
                // Each goal gets its own line
                outputFile.WriteLine(goal.GetStringRepresentation());
            }

            // Next, the following lines will be incomes
            foreach(Income income in _budget.GetIncomes())    
            {
                // Each goal gets its own line
                outputFile.WriteLine(income.GetStringRepresentation());
            }

            //  Next, the following lines will be expenses
            foreach(Expense expense in _budget.GetExpenses())    
            {
                // Each goal gets its own line
                outputFile.WriteLine(expense.GetStringRepresentation());
            }
        }
    }

    private void Load()
    {
        // Local Variables
        List<Goal> newGoals = new List<Goal>();
        string fileName;
        string type;
        string name;
        string description;
        double value;
        string date;
        string category = "N/A";    // default
        bool status = false;    // default
        bool didHappen = false; // default
        bool isPlanned = false; // default
        
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
            return;
        }
        
        //  Read the file into seperate lines.
        string[] lines = System.IO.File.ReadAllLines(fileName);

        // The first line contains the budget name
        name = lines[0];
        _budget = new Budget(name);

        // Each line after is an instance of a goal or transaction.
        foreach (string line in lines.Skip(1))
        {
            // Begin Parsing the line
            string[] parse1 = line.Split('|');
            type = parse1[0];   // text before | is the object type
            string[] parse2 = parse1[1].Split(';');
            name = parse2[0];   // text before ; is the name of the goal or...
            date = parse2[0];   // the data of the transaction
            string[] parse3 = parse2[1].Split(':');
            description = parse3[0];    // text before : is the description
            string[] parse4 = parse3[1].Split('=');
            value = double.Parse(parse4[0]);    // text before = is the cash value
            if ((type=="SavingGoal")|(type=="SpendingGoal")|(type=="EarningGoal"))  // if the line is a goal object
            {
                // then continue parsing this way
                string[] parse5 = parse4[1].Split('?');
                didHappen = bool.Parse(parse5[0]);  //  text before ? says whether the goal has actually happened
                isPlanned = bool.Parse(parse5[1]);  //  text after ? says whether the goal has been planned
            }
            else    // else the line is a transaction object
            {
                string[] parse5 = parse4[1].Split('?');
                category = parse5[0];   // text before ? is the transaction category
                status = bool.Parse(parse5[1]); // text after ? is the transaction status
            }

            // Create a goal from the line
            if (type=="SavingGoal") // if a Saving Goal
            {
                SavingGoal goal = new SavingGoal(name, description, value);
                if (didHappen) // if the goal has actually happened
                {
                    goal.Happened(value, 1);
                }
                if (isPlanned)  // if the goal has been planned
                {
                    goal.Planned(value, 1);
                }
                newGoals.Add(goal);
            }
            else if (type=="SpendingGoal")   // if a Spending Goal
            {
                SpendingGoal goal = new SpendingGoal(name, description, value);
                if (didHappen) // if the goal has actually happened
                {
                    goal.Happened(value, 1);
                }
                if (isPlanned)  // if the goal has been planned
                {
                    goal.Planned(value, 1);
                }
                newGoals.Add(goal);
            }
            else if (type=="EarningGoal") // if an Earning Goal
            {
                EarningGoal goal = new EarningGoal(name, description, value);
                if (didHappen) // if the goal has actually happened
                {
                    goal.Happened(value, 1);
                }
                if (isPlanned)  // if the goal has been planned
                {
                    goal.Planned(value, 1);
                }
                newGoals.Add(goal);
            }

            // Create a Transaction from the line
            if (type=="Expense") // if an Expense
            {
                Expense expense = new Expense(date, value, description, category);
                if (status) // if status is true
                {
                    // then the transaction happen
                    expense.SetStatus();
                }
                _budget.AddExpense(expense);
            }
            else if (type=="Income")    // if an Income
            {
                Income income = new Income(date, value, description, category);
                if (status) // if status is true
                {
                    // then the transaction happen
                    income.SetStatus();
                }
                _budget.AddIncome(income);
            }
        }

        _goals = newGoals;
    }
}