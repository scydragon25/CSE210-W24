using System;
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

        // Default Categories
        

        // User fed attribute
        _name = name;
    }

    // Methods
    public void DisplayBudget()        // Display the detailed budget
    {
        // Desired Format:
        //      Expenses            ||          Incomes
        //  ...                     ||  ...
        //  Total Expense:  $       ||  Total Income:   $
        //                          ||  Net Balance:    $
    }

    public void DisplaySummary()        // Display the budget summary
    {
        // Desired Format:
        //  Total Expense:  $       ||  Total Income:   $
        //                          ||  Net Balance:    $
    }

    public void AddTransaction(Transaction transaction)        // Put together a transaction. Add to list.
    {
        // Prompt User

        // Create Transaction

        // Add to proper List

        // Loop?
    }

    public void EditTransaction()       // Edit transaction detail(s)
    {
        // Prompt User

        // Find Transaction

        // Display Transaction

        // Prompt User

        // Make Change

        // Loop?
    }

    public void RemoveTransaction()     // Remove a particular transaction
    {
        // Prompt User

        // Find Transaction

        // Remove Transaction

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

    public double GetExpenseTotal()     // Return total value of expenses
    {
        // local variables
        double total = 0;

        // Cycle through expenses

        return total;
    }

    public double GetIncomeTotal()     // Return total value of incomes
    {
        // local variables
        double total = 0;

        // Cycle through incomes
        
        return total;
    }

    public double GetNetBalance()       // Return net balance
    {
        return GetIncomeTotal()-GetExpenseTotal();
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