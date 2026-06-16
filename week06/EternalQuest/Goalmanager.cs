public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    private static readonly (int minScore, string title)[] _levels = new[]
    {
        (0,     "Level 1 - Apprentice"),
        (500,   "Level 2 - Seeker"),
        (1000,  "Level 3 - Warrior"),
        (2000,  "Level 4 - Champion"),
        (4000,  "Level 5 - Hero"),
        (7000,  "Level 6 - Legend"),
        (10000, "Level 7 - Eternal Master")
    };

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    private string GetLevelTitle(int score)
    {
        string title = _levels[0].title;
        foreach (var level in _levels)
        {
            if (score >= level.minScore)
                title = level.title;
        }
        return title;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": CreateGoal();     break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals();      break;
                case "4": LoadGoals();      break;
                case "5": RecordEvent();    break;
                case "6": running = false;  break;
                default:
                    Console.WriteLine("That's not a valid option. Try again.");
                    break;
            }
        }

        Console.WriteLine("\nThanks for playing Eternal Quest. Keep working on those goals!");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("=========================================");
        Console.WriteLine($"  {GetLevelTitle(_score)}");
        Console.WriteLine($"  Score: {_score} points");
        Console.WriteLine("=========================================\n");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"  {i + 1}. {_goals[i].ShortName}");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.\n");
            return;
        }

        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");

        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("What kind of goal would you like to create?");
        Console.WriteLine("  1. Simple Goal      (completed once)");
        Console.WriteLine("  2. Eternal Goal     (never ends, always gives points)");
        Console.WriteLine("  3. Checklist Goal   (done multiple times, bonus at the end)");
        Console.WriteLine("  4. Negative Goal    (bad habit — you LOSE points for this one)");
        Console.Write("Select a choice: ");
        string type = Console.ReadLine();

        Console.Write("\nWhat is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("That's not a valid goal type.\n");
                return;
        }

        Console.WriteLine("\nGoal created successfully!\n");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals to record yet!\n");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames();
        Console.Write("Select a choice: ");

        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("That's not a valid goal number.\n");
            return;
        }

        string levelBefore = GetLevelTitle(_score);
        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;

        // Score floor — never drop below zero
        if (_score < 0)
            _score = 0;

        if (pointsEarned < 0)
            Console.WriteLine($"\nYou lost {Math.Abs(pointsEarned)} points. Try to do better next time!");
        else
            Console.WriteLine($"\nCongratulations! You earned {pointsEarned} points!");

        if (levelBefore != GetLevelTitle(_score))
            Console.WriteLine($"🎉 YOU LEVELED UP! You are now {GetLevelTitle(_score)}!");

        Console.WriteLine($"You now have {_score} points.\n");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
                writer.WriteLine(goal.GetStringRepresentation());
        }

        Console.WriteLine("Goals saved successfully!\n");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Double-check the name and try again.\n");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string goalType = parts[0];
            string[] data   = parts[1].Split(",");

            switch (goalType)
            {
                case "SimpleGoal":
                    SimpleGoal simple = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                    if (data[3] == "True") simple.RecordEvent();
                    _goals.Add(simple);
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;

                case "ChecklistGoal":
                    ChecklistGoal checklist = new ChecklistGoal(
                        data[0], data[1], int.Parse(data[2]),
                        int.Parse(data[4]), int.Parse(data[5])
                    );
                    int completions = int.Parse(data[3]);
                    for (int j = 0; j < completions; j++)
                        checklist.RecordEvent();
                    _goals.Add(checklist);
                    break;

                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
                    break;
            }
        }

        Console.WriteLine($"Goals loaded! You have {_goals.Count} goals and {_score} points.\n");
    }
}