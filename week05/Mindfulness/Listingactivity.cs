using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void GetRandomPrompt()
    {
        Random rand = new Random();
        Console.WriteLine($"\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[rand.Next(_prompts.Count)]} ---");
        Console.WriteLine("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine() ?? "";
            if (item != "")
                items.Add(item);
        }
        return items;
    }

    public void Run()
    {
        DisplayStartingMessage();
        GetRandomPrompt();
        List<string> items = GetListFromUser();
        _count = items.Count;
        Console.WriteLine($"\nYou listed {_count} items!");
        DisplayEndingMessage();
    }
}