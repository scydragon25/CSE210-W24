using System;

// Responsible for keeping track of the book, chapter, and verse information
public class Reference
{
    // Attributes
    private string _book;
    private string _ch;
    private string _startVerse;
    private string _endVerse;

    // Constructors
    public Reference(string book, string ch, string v0, string v1)  // Book ch:v0-v1
    {
        _book = book;
        _ch = ch;
        _startVerse = v0;
        _endVerse = v1;
    }

    public Reference(string book, string ch, string verse)  // Book ch:verse
    {
        _book = book;
        _ch = ch;
        _startVerse = verse;
    }

    public Reference(string book, string ch)    // Book ch (like D&C 4)
    {
        _book = book;
        _ch = ch;
    }

    // Methods
    public string GetDisplayText()  // Return the reference
    {
        // If no starting verse exists...
        if (string.IsNullOrEmpty(_startVerse))
        {
            // Then this is a book/ch reference
            return $"{_book} {_ch}";
        }
        // Else If no ending verse exists...
        else if (string.IsNullOrEmpty(_endVerse))
        {
            // Then this is a book/ch/single verse reference
            return $"{_book} {_ch}:{_startVerse}";
        }
        // Else this is a book/ch/multi verse reference
        else
        {
            return $"{_book} {_ch}:{_startVerse}-{_endVerse}";
        }
        // Certainly no one is crazy enought to memorize an entire book
        // of scripture
    }
}