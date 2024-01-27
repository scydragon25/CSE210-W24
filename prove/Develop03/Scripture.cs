using System;

// Responsible for keeping track of both the reference and text of the
// scripture. Can hide words and get the rendered display of the text.
public class Scripture
{
    // Attributes
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }

    }

    // Methods
    public void HideRandomWords(int numToHide)  // Hide the indexed word
    {
        Random rnd = new Random();  // random number generator
        int index;  // which word

        // Collection of words not hidden
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            // If the is not hidden...
            if (!word.IsHidden())
            {
                // Then add it to the list of visible words
                visibleWords.Add(word);
            }
        }

        // If there are 3 or fewer visible lines
        if (visibleWords.Count<5)
        {
            // Then simply make the rest of the words invisble
            foreach(Word word in visibleWords)
            {
                word.Hide();
            }

            // Exit the method
            return;
        }

        // Hide a given number of words
        for (int i=0; i<=numToHide; i++)
        {   
            // Choose a random index
            index = rnd.Next(0,visibleWords.Count());
            // Hide a random word
            visibleWords[index].Hide();
            // Remove the hidden word from the list of visible words
            visibleWords.RemoveAt(index);
        }

        return;
    }

    public void DisplayText()  // Display reference and visible words of scripture
    {
        // Compile visible text for user
        string text ="";
        foreach (Word word in _words)
        {
            // If the word is not invisible...
            if (!word.IsHidden())
            {
                // Then add the word to the text
                text = text+word.GetDisplayText()+" ";
            }
            // Else, add an underscrore for each hidden letter
            else
            {
                string hidWord =""; // hidden word placeholder
                foreach (char letter in word.GetDisplayText())
                {
                    hidWord = hidWord+"_";
                }
                text = text+hidWord+" ";
            }
        }

        // Display
        Console.WriteLine(_reference.GetDisplayText());
        Console.WriteLine(text);

        return;
    }

    public bool IsCompletelyHidden()    // Return if all words of the scripture are hidden
    {
        // Iterate through the list of words
        foreach (Word word in _words)
        {
            // If there is a word that is not hidden
            if (!word.IsHidden())
            {
                // Then return false
                return false;
            }
        }

        return true;
    }
}