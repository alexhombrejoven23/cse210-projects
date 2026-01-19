using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        Console.WriteLine("Welcome to the Journal Program!");
        
        bool running = true;
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    // Exceeding requirement: Add custom prompt
                    AddCustomPrompt(promptGenerator);
                    break;
                case "6":
                    // Exceeding requirement: Show statistics
                    journal.DisplayStats();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nPlease select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Add a custom prompt (Exceeding requirement)");
        Console.WriteLine("6. Show journal statistics (Exceeding requirement)");
        Console.WriteLine("7. Quit");
        Console.Write("What would you like to do? ");
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        string currentDate = DateTime.Now.ToShortDateString();
        
        Entry newEntry = new Entry(currentDate, prompt, response);
        journal.AddEntry(newEntry);
        
        Console.WriteLine("Entry added successfully!");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        
        // Add .txt extension if not present
        if (!filename.EndsWith(".txt"))
            filename += ".txt";
            
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        // Add .txt extension if not present
        if (!filename.EndsWith(".txt"))
            filename += ".txt";
            
        journal.LoadFromFile(filename);
    }

    static void AddCustomPrompt(PromptGenerator promptGenerator)
    {
        Console.Write("Enter your custom prompt: ");
        string customPrompt = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(customPrompt))
        {
            promptGenerator.AddPrompt(customPrompt);
            Console.WriteLine("Custom prompt added successfully!");
        }
        else
        {
            Console.WriteLine("Prompt cannot be empty.");
        }
    }
}

