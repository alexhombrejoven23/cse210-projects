using System;
// Creativity / Exceeding requirements:
// I added a level system. The player's level is calculated from the score
// (a new level every 500 points). The level is shown next to the score,
// and a "LEVEL UP!" message appears when the player reaches a new level.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}