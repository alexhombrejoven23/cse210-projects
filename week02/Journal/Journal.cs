using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");
            return;
        }

        Console.WriteLine("\n========== Journal Entries ==========");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.GetDisplayText());
            Console.WriteLine("-------------------------------------");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetSaveText());
            }
        }
        Console.WriteLine($"Journal saved to '{filename}'.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                Entry entry = Entry.FromSaveText(line);
                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Journal loaded from '{filename}'. {_entries.Count} entries found.");
    }
    public void DisplayRandom()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet to reflect on.");
            return;
        }

        Random random = new Random();
        int index = random.Next(_entries.Count);
        Entry entry = _entries[index];

        Console.WriteLine("\n===== Random Entry for Reflection =====");
        Console.WriteLine(entry.GetDisplayText());
    }
}