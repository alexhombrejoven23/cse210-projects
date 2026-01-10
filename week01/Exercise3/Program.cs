using System;

class Program
{
    static void Main(string[] args)
    {
         Random rnd = new Random();          
        string playAgain;                  

        do  
        {
            int magic = rnd.Next(1, 101);   
            int guess;                      
            int tries = 0;                

            Console.WriteLine("Guess My Number!");
    
            do  
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                tries++;

                if (guess < magic)      Console.WriteLine("Higher");
                else if (guess > magic) Console.WriteLine("Lower");
                else                    Console.WriteLine("You guessed it!");
            } while (guess != magic);

            Console.WriteLine($"You made {tries} guesses.");

            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine().ToLower();
        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}