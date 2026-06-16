// =============================================================
// Eternal Quest — CSE 210
//
// EXCEEDING REQUIREMENTS:
//
// 1. Level System
//    Players earn titles as their score grows:
//    Apprentice → Seeker → Warrior → Champion → Hero → Legend → Eternal Master
//    The current level is displayed on every screen, and a message
//    appears when the player levels up.
//
// 2. Negative Goals
//    A new NegativeGoal class represents bad habits.
//    Recording one costs the player points instead of awarding them.
//    The score never drops below zero.
// =============================================================

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}