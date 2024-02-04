using System;

// Parent Class, responsible for holding information on a student's
// name and assignment topic.
public class Assignment
{
    // Attributes
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    // Methods
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    public string GetStudentName()
    {
        return _studentName;
    }
}