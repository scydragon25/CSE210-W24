using System;

// Responsible for keeping track of a single word
// and whether it is shown or hidden.
public class Word
{
    // Attributes
    private string _text;   // the word itself
    private bool _isHidden; // Is the word invisible?

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;  // By default you ought to be able to see the word
    }

    // Methods
    public void Hide()  // Make the word invisible
    {
        _isHidden = true;
    }

    public void Show()  // Make the word visible
    {
        _isHidden = false;
    }

    public bool IsHidden()  // Report on the invisibility status of the word
    {
        return _isHidden;
    }

    public string GetDisplayText()  // Return the word itself
    {
        return _text;
    }
}