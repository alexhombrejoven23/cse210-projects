// =============================================================
// Eternal Quest Program
// Author: Alex
// Course: CSE 210 - Programming with Classes
// =============================================================
//
// EXCEEDING REQUIREMENTS — What was added beyond the core spec:
//
// 1. LEVEL SYSTEM
//    The player earns a title based on their total score:
//      - Level 1: Apprentice   (0+ points)
//      - Level 2: Seeker       (500+ points)
//      - Level 3: Warrior      (1,000+ points)
//      - Level 4: Champion     (2,000+ points)
//      - Level 5: Hero         (4,000+ points)
//      - Level 6: Legend       (7,000+ points)
//      - Level 7: Eternal Master (10,000+ points)
//    The current level is shown at the top of every menu screen.
//    When the player crosses a threshold, a level-up message appears.
//
// 2. NEGATIVE GOALS
//    A new goal type called NegativeGoal was added.
//    It represents a bad habit the player is trying to break.
//    Every time the event is recorded, the player LOSES points.
//    Example: "Ate junk food" costs 50 points each time.
//    This makes the game more honest and motivating — bad habits
//    have real consequences.
//
// Both features are fully functional, saved/loaded from files,
// and follow the same OOP design as the rest of the program.
// =============================================================

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}