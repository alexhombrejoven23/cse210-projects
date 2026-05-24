using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        _words = text.Split(' ')
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rnd = new Random();

        List<Word> visible = _words.Where(w => !w.IsHidden()).ToList();

        int count = Math.Min(numberToHide, visible.Count);

        for (int i = 0; i < count; i++)
        {
            int index = rnd.Next(visible.Count);
            visible[index].Hide();
            visible.RemoveAt(index); 
        }
    }

    public string GetDisplayText()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_reference.GetDisplayText());
        sb.Append(string.Join(" ", _words.Select(w => w.GetDisplayText())));
        return sb.ToString();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}