using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an instances of Job
        Resume resume = new Resume();
        Job job1 = new Job(); 
        Job job2 = new Job();
        // Set the member variables
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._yrStart = 2019;
        job1._yrEnd = 2022;
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._yrStart = 2022;
        job2._yrEnd = 2023;
        // Add job histroy to resume
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume._name = "Allison Rose";
        // Display
        resume.Display();
    }
}