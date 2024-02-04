using System;
using System.Reflection.PortableExecutable;

// Child Class for Assignment. Responsible for keeping information
// related to the student, the topic, the textbook section, and the
// problems from that section.
public class MathAssignment : Assignment
{
    // Attributes
    private string _textbookSection;
    private string _problems;

    // Constructor
    public MathAssignment(string name, string topic, string section, string problems) : base (name, topic)
    {
        _textbookSection = section;
        _problems = problems;
    }

    // Method
    public string GetHomeworkList()
    {
        string summary = this.GetSummary();
        string homework = $"{_textbookSection} {_problems}";

        return $"{summary}\n{homework}";
    }
}