using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> activityLog = new Dictionary<string, int>
        {
            { "Breathing Activity", 0 },
            { "Reflecting Activity", 0 },
            { "Listing Activity", 0 }
        };

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    BreathingActivity b = new BreathingActivity();
                    b.Run();
                    activityLog["Breathing Activity"]++;
                    break;
                case "2":
                    ReflectingActivity r = new ReflectingActivity();
                    r.Run();
                    activityLog["Reflecting Activity"]++;
                    break;
                case "3":
                    ListingActivity l = new ListingActivity();
                    l.Run();
                    activityLog["Listing Activity"]++;
                    break;
                case "4":
                    running = false;
                    Console.Clear();
                    Console.WriteLine("Session summary:");
                    foreach (var entry in activityLog)
                    {
                        if (entry.Value > 0)
                            Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");
                    }
                    Console.WriteLine("\nThanks for using the Mindfulness Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}