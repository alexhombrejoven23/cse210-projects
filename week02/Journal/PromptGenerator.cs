using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts { get; set; }

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was the most challenging part of my day?",
            "What made me smile today?",
            "What am I grateful for today?",
            "What did I learn today?",
            "What would make tomorrow even better?"
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
    
    public void AddPrompt(string prompt)
    {
        _prompts.Add(prompt);
    }
}