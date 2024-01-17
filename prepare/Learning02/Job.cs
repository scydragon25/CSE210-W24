using System;

// Keeps track of the company, job title, start year, and end year
public class Job
{
    // Attributes
    public string _company = "";
    public string _jobTitle = "";
    public int _yrStart = 0;
    public int _yrEnd = 0;

    // Constructor
    public Job()
    {
    }

    // Methods
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) "+
                            $"{_yrStart}-{_yrEnd}");
    }
}