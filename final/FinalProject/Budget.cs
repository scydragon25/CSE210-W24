using System;
using System.ComponentModel;
using System.Xml.Schema;

// Holds a list of incomes and a second list of expenses, the
//  budget name, a list of income categories and a second list
//  of expense categories.
// Responsible for Displaying a summary or detailed version of
//  the budget; and adding, removing, or editing transactions.
public class Budget
{
    // Attributes
    private List<Income> _incomes;  // List of different incomes
    private List<Expense> _expenses;    // List of different expenses
    private string _name;   // Budget name
    private List<string> _incomeCategories; // List of income categories
    private List<string> _expenseCategories;    // List of expense categories

    // Constructor
    public Budget(string name)
    {
        // Instaniate Lists
        _incomes = new List<Income>();
        _expenses = new List<Expense>();
        _incomeCategories = new List<string>();
        _expenseCategories = new List<string>();

        // Default Income Categories
        _incomeCategories.Add("Paycheck");
        _incomeCategories.Add("Bonus");
        _incomeCategories.Add("Venmo");
        _incomeCategories.Add("Plasma");
        _incomeCategories.Add("Other");

        // Default Expense Categories
        _expenseCategories.Add("Food");
        _expenseCategories.Add("Gifts");
        _expenseCategories.Add("Medical");
        _expenseCategories.Add("Bills");
        _expenseCategories.Add("Transportation");
        _expenseCategories.Add("Entertainment");
        _expenseCategories.Add("Clothing");
        _expenseCategories.Add("School");
        _expenseCategories.Add("Restaurant");
        _expenseCategories.Add("Religion");
        _expenseCategories.Add("Other");

        // User fed attribute
        _name = name;
    }

    // Methods
    public void DisplayBudget()        // Display the detailed budget
    {
        // Local Variables
        int index = 0;

        // Desired Format:
        //      Expenses            ||          Incomes
        //  ...                     ||  ...
        //  Total Expense:  $       ||  Total Income:   $
        //                          ||  Net Balance:    $
        Console.WriteLine($" ||\t{_name}");
        Console.Write("===================="+
                            "===================="+
                            "===================="+
                            "============= ");
        Console.WriteLine("===================="+
                            "===================="+
                            "===================="+
                            "=============");
        Console.WriteLine("{0,-32}{1,8}{2,33}{3,1}{4,-33}{5,8}{6,32}","|||","Expenses","||"," ","||","Incomes","|||");
        Console.Write("===================="+
                            "===================="+
                            "===================="+
                            "============= ");
        Console.WriteLine("===================="+
                            "===================="+
                            "===================="+
                            "=============");
        Console.Write("{0,-14}{1,10}{2,-35}{3,-12}{4,-3}",
                            "|||   Date   |",
                            "    $$$   ",
                            "|           Description            ",
                            "| <Category>",
                            "||");
        Console.WriteLine("{0,-13}{1,10}{2,-35}{3,-12}{4,-3}",
                            "||   Date   |",
                            "    $$$   ",
                            "|           Description            ",
                            "| <Category>",
                            "|||");
        Console.Write("===================="+
                            "===================="+
                            "===================="+
                            "============= ");
        Console.WriteLine("===================="+
                            "===================="+
                            "===================="+
                            "=============");
        // Display Expenses and Incomes
        foreach (Expense expense in _expenses)  // Assuming there are more expenses than incomes
        {
            // Display Expense
            // Has the expense happened?
            if (expense.GetStatus())
            {
                Console.ForegroundColor = ConsoleColor.Cyan;    // Distinguish
            }
            expense.Display(index+1);   // number the transactions, starting at 1
            Console.ForegroundColor = ConsoleColor.Gray;    // Reset Color

            // Display Income
            if (index <= _incomes.Count-1)  // If the index hasn't reached the end of the income list
            {
                // then display the next income
                // Has the income happened?
                if (_incomes[index].GetStatus())
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;    // Distinguish
                }
                _incomes[index].Display(index+1);
                Console.ForegroundColor = ConsoleColor.Gray;   // Reset Color
            }
            Console.WriteLine();

            index++;
        }
        if (_expenses.Count<_incomes.Count)
        {
            foreach (Income income in _incomes.Skip(index))
            {
                Console.Write("{0,73}","");
                income.Display(index+1);
                Console.WriteLine();
                index++;
            }
        }
        DisplaySummary();
    }

    public void DisplaySummary()        // Display the budget summary
    {
        // Local Variables
        double cost = GetPlannedExpenseTotal();
        double pay = GetPlannedIncomeTotal();
        double net = GetPlannedNetBalance();

        cost *=-1;  // positive number

        // Desired Format:
        //  Total Expense:  $       ||  Total Income:   $
        //                          ||  Net Balance:    $
        Console.Write("===================="+
                            "===================="+
                            "===================="+
                            "============= ");
        Console.WriteLine("===================="+
                            "===================="+
                            "===================="+
                            "=============");
        Console.WriteLine("{0,-24}{1,-26}{2,23}{3,1}{4,-25}{5,-26}{6,22}",
                            "|||",$"Total Expenses: ${cost:n2}","||",
                            " ","||",$"Total Incomes: ${pay:n2}","|||");
        Console.Write("===================="+
                            "===================="+
                            "===================="+
                            "============= ");
        Console.WriteLine("===================="+
                            "===================="+
                            "===================="+
                            "=============");
        Console.WriteLine("{0,74}{1,-25}{2,14}{3,-12}{4,21}"," ","||","Net Balance:",$" ${net:n2}","||");
    }

    public void AddTransaction()        // Put together a transaction. Add to list.
    {
        // Local Variables
        string type = "Transaction";    // Default
        string date;
        string value;
        string description;
        string input;

        // Prompt User
        Console.WriteLine("What type of transaction");  // Transaction Type
        Console.WriteLine(" 1. Expense");
        Console.WriteLine(" 2. Income");
        Console.Write("Numbered Selection Here -> ");
        input = Console.ReadLine();
        if (int.Parse(input)==1)
        {
            type = "Expense";
        }
        else if (int.Parse(input)==2)
        {
            type = "Income";
        }

        Console.WriteLine();
        Console.WriteLine("What is the date of the transaction?");  // Transaction Date
        Console.WriteLine("Format Reminder: Month/Day/Year ie - 12/23/34");
        Console.Write("Enter Date Here -> ");
        date = Console.ReadLine();
        
        Console.WriteLine();
        Console.WriteLine("What is the cash value of the transaction?");    // $$$
        Console.Write("Cash Value Here -> $");
        value = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("What is the new transaction description?");  // Transaction Description
        Console.Write("New Description Here -> ");
        description = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Choose the transaction category?");  // Transaction Category
        if (type=="Expense")
        {
            int i = 1;
            foreach (string category in _expenseCategories)
            {
                Console.WriteLine($" {i}. {category}");
                i++;
            }
            Console.Write("Category Number Here -> ");
            input = Console.ReadLine();
            _expenses.Add(new Expense(date, double.Parse(value), description,   // Create Expense Transaction
                                        _expenseCategories[int.Parse(input)-1]));  

            // Did the transaction happen?
            Console.WriteLine();
            Console.Write("Are you wanting to mark that this transaction as already happened? (Y/N) ");
            input = Console.ReadLine();
            if (input=="Y")
            {
                _incomes[_incomes.Count-1].SetStatus(); // Set the status of the most recent income
                return;
            }
        }
        else if (type=="Income")
        {
            int i = 1;
            foreach (string category in _incomeCategories)
            {
                Console.WriteLine($" {i}. {category}");
                i++;
            }
            Console.Write("Category Number Here -> ");
            input = Console.ReadLine();
            _incomes.Add(new Income(date, double.Parse(value), description,   // Create Income Transaction
                                        _incomeCategories[int.Parse(input)-1]));

            // Did the transaction happen?
            Console.WriteLine();
            Console.Write("Are you wanting to mark that this transaction as already happened? (Y/N) ");
            input = Console.ReadLine();
            if (input=="Y")
            {
                _incomes[_incomes.Count-1].SetStatus(); // Set the status of the most recent income
                return;
            }
        }
        
    }

    public void AddExpense(Expense transaction)
    {
        _expenses.Add(transaction);
    }

    public void AddIncome(Income transaction)
    {
        _incomes.Add(transaction);
    }

    public void EditTransaction()       // Edit transaction detail(s)
    {
        // Local Variable
        string input;
        Income income;
        Expense expense;
        Transaction transaction;

        // Prompt User
        Console.WriteLine("The budget will be displayed. Please select the index number"+
                            " associated with the transaction you wish to edit.");
        
        // Wait for the user to continue
        Console.WriteLine();
        Console.WriteLine("Press <Enter> to Begin");
        Console.ReadLine();

        DisplayBudget();
        Console.Write("Numbered Selection Here -> ");
        input = Console.ReadLine();

        // Find Transaction
        income = _incomes[int.Parse(input)-1];
        expense = _expenses[int.Parse(input)-1];

        // Display Transaction
        expense.Display(1);
        income.Display(1);
        Console.WriteLine();

        // Prompt User
        Console.Write("Are you wanting to edit the expense <E> or income <I>? ");
        input = Console.ReadLine();
        Console.Clear();
        switch (input)
        {
            case "E":   // if user chose expense
                transaction = expense;
                break;
            case "I":   // if user chose income
                transaction = income;
                break;
            default:    // Error
                Console.WriteLine("Error: There was an issue with your selection. Please try again.");
                // Wait for the user to continue
                Console.WriteLine();
                Console.WriteLine("Press <Enter> to return");
                Console.ReadLine();
                return;
        }
        transaction.Display(1);

        // Did the transaction happen?
        Console.WriteLine();
        Console.Write("Are you wanting to mark that this transaction happened? (Y/N) ");
        input = Console.ReadLine();
        if (input=="Y")
        {
            transaction.SetStatus();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("What do you wish to change?");
        Console.WriteLine(" 1. Date");
        Console.WriteLine(" 2. Cash Value");
        Console.WriteLine(" 3. Description");
        Console.WriteLine(" 4. Category");
        Console.Write("Numbered Selection Here -> ");
        input = Console.ReadLine();
   
        // Make Change
        switch (int.Parse(input))
        {
            case 1: // New Date
                Console.WriteLine("What is the new date for the above transaction?");
                Console.WriteLine("Format Reminder: Month/Day/Year ie - 12/23/34");
                Console.Write("New Date Here -> ");
                input = Console.ReadLine();
                transaction.SetDate(input);
                break;
            case 2: // New Cash Value
                Console.WriteLine("What is the new value of the transaction?");
                Console.Write("New Cash Value Here -> $");
                input = Console.ReadLine();
                transaction.SetValue(double.Parse(input));
                break;
            case 3: // New Description
                Console.WriteLine("What is the new transaction description?");
                Console.Write("New Description Here -> ");
                input = Console.ReadLine();
                transaction.SetDescription(input);
                break;
            case 4: // New Category
                Console.WriteLine("Choose the new transaction category?");
                if (transaction is Expense)
                {
                    int i = 1;
                    foreach (string category in _expenseCategories)
                    {
                        Console.WriteLine($" {i}. {category}");
                        i++;
                    }
                    Console.Write("Category Number Here -> ");
                    input = Console.ReadLine();
                    transaction.SetCategory(_expenseCategories[int.Parse(input)-1]);
                }
                else if (transaction is Income)
                {
                    int i = 1;
                    foreach (string category in _incomeCategories)
                    {
                        Console.WriteLine($" {i}. {category}");
                        i++;
                    }
                    Console.Write("Category Number Here -> ");
                    input = Console.ReadLine();
                    transaction.SetCategory(_incomeCategories[int.Parse(input)-1]);
                }
                break;
        }

        // Loop?
    }

    public void RemoveTransaction()     // Remove a particular transaction
    {
        // Local Variable
        string input;
        int index;
        Income income;
        Expense expense;

        // Prompt User
        Console.WriteLine("The budget will be displayed. Please select the index number"+
                            " associated with the transaction you wish to delete.");
        
        // Wait for the user to continue
        Console.WriteLine();
        Console.WriteLine("Press <Enter> to Begin");
        Console.ReadLine();

        DisplayBudget();
        Console.Write("Numbered Selection Here -> ");
        input = Console.ReadLine();
        index = int.Parse(input)-1;

        // Find Transaction
        income = _incomes[int.Parse(input)-1];
        expense = _expenses[int.Parse(input)-1];

        // Display Transaction
        expense.Display(1);
        income.Display(1);
        Console.WriteLine();

        // Remove the transaction
        Console.Write("Are you wanting to remove the expense <E> or income <I>? ");
        input = Console.ReadLine();
        Console.Clear();
        switch (input)
        {
            case "E":   // if user chose expense
                _expenses.RemoveAt(index);
                break;
            case "I":   // if user chose income
                _incomes.RemoveAt(index);
                break;
            default:    // Error
                Console.WriteLine("Error: There was an issue with your selection. Please try again.");
                // Wait for the user to continue
                Console.WriteLine();
                Console.WriteLine("Press <Enter> to return");
                Console.ReadLine();
                return;
        }
        
        // Loop?
    }

    public List<Income> GetIncomes()        // Return the list of incomes
    {
        return _incomes;
    }

    public List<Expense> GetExpenses()      // Return the list of expenses
    {
        return _expenses;
    }

    public double GetPlannedExpenseTotal()     // Return total value of expenses
    {
        // local variables
        double total = 0;

        // Cycle through expenses
        foreach (Expense expense in _expenses)
        {
            total += expense.GetValue();
        }

        return total;
    }

    public double GetActualExpenseTotal()     // Return total value of expenses
    {
        // local variables
        double total = 0;

        // Cycle through expenses
        foreach (Expense expense in _expenses)
        {
            if (expense.GetStatus())
            {
                total += expense.GetValue();
            }
        }

        return total;
    }

    public double GetPlannedIncomeTotal()     // Return total value of incomes
    {
        // local variables
        double total = 0;

        // Cycle through incomes
        foreach (Income income in _incomes)
        {
            total += income.GetValue();
        }

        return total;
    }

    public double GetActualIncomeTotal()     // Return total value of incomes
    {
        // local variables
        double total = 0;

        // Cycle through incomes
        foreach (Income income in _incomes)
        {
            if (income.GetStatus())
            {
                total += income.GetValue();
            }
        }

        return total;
    }

    public double GetPlannedNetBalance()       // Return net balance
    {
        return GetPlannedIncomeTotal()+GetPlannedExpenseTotal();
    }

    public double GetActualNetBalance()       // Return net balance
    {
        return GetPlannedIncomeTotal()+GetPlannedExpenseTotal();
    }

    public string GetName()     // Return the budget name
    {
        return _name;
    }

    public void SetName(string name)       // Set a new budget name
    {
        _name = name;
    }
}