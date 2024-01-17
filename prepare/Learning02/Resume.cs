using System;

// Keeps track of the parson's name and a list of their jobs
public class Resume
{
    // Attributes
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    // Constructor
    public Resume()
    {
    }

    // Methods
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs: ");
        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}