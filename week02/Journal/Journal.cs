using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries { get; set; }

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
            return;
        }

        Console.WriteLine("\n=== Journal Entries ===\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
                }
            }
            Console.WriteLine($"Journal saved successfully to {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string file)
    {
        try
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(file);
            _entries.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                
                if (parts.Length >= 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"Journal loaded successfully from {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    public void DisplayStats()
    {
        Console.WriteLine("\n=== Journal Statistics ===");
        Console.WriteLine($"Total entries: {_entries.Count}");
        
        if (_entries.Count > 0)
        {
            DateTime earliestDate = DateTime.MaxValue;
            DateTime latestDate = DateTime.MinValue;
            
            foreach (Entry entry in _entries)
            {
                if (DateTime.TryParse(entry._date, out DateTime entryDate))
                {
                    if (entryDate < earliestDate) earliestDate = entryDate;
                    if (entryDate > latestDate) latestDate = entryDate;
                }
            }
            
            if (earliestDate != DateTime.MaxValue)
            {
                Console.WriteLine($"Date range: {earliestDate.ToShortDateString()} to {latestDate.ToShortDateString()}");
                Console.WriteLine($"Journaling span: {(latestDate - earliestDate).Days + 1} days");
            }
        }
    }
}