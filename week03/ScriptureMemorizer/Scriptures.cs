using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();
        
        // Dividir el texto en palabras y crear objetos Word
        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Contar cuántas palabras no están ocultas
        int wordsNotHidden = 0;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                wordsNotHidden++;
            }
        }
        
        // Si hay menos palabras por ocultar que las solicitadas, ajustar
        int wordsToHide = Math.Min(numberToHide, wordsNotHidden);
        
        // Ocultar las palabras aleatoriamente
        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = _random.Next(_words.Count);
            } while (_words[randomIndex].IsHidden());
            
            _words[randomIndex].Hide();
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n\n";
        
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        
        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}