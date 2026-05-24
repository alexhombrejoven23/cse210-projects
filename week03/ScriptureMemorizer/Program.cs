using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"),

            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"),

            new Scripture(new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me"),

            new Scripture(new Reference("Joshua", 1, 9),
                "Be strong and of a good courage be not afraid neither be thou dismayed for the Lord thy God is with thee whithersoever thou goest")
        };

        Random rnd = new Random();
        Scripture scripture = library[rnd.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            ShowHeader();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Well done! All words are hidden. Keep practicing!");
                Console.ResetColor();
                break;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Press [Enter] to hide more words or type 'quit' to exit: ");
            Console.ResetColor();

            string input = Console.ReadLine();

            if (input?.Trim().ToLower() == "quit")
            {
                Console.WriteLine("\nGoodbye! Keep memorizing.");
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

    static void ShowHeader()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║       SCRIPTURE MEMORIZER            ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
    }
}