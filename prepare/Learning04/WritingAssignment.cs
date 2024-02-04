using System;

// Child Class for Assignment. Responsible for keeping information
// related to the student, the topic, and the assignment title
public class WritingAssignment : Assignment
{
    // Attributes
    private string _title;

    // Constructor
    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }

    // Method
    public string GetWritingInformation()
    {
        return $"{_title} by {this.GetStudentName()}";
    }
}