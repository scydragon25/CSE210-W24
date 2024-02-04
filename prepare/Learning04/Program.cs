using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment test1 = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(test1.GetHomeworkList());

        WritingAssignment test2 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine();
        Console.WriteLine(test2.GetSummary());
        Console.WriteLine(test2.GetWritingInformation());
    }
}