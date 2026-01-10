using System;
using System.Collections.Generic;
using System.Linq;  

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());
            if (n == 0) break;  
            numbers.Add(n);
        }
        int sum   = numbers.Sum();
        double avg = numbers.Average();
        int max   = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {max}");

        List<int> positives = numbers.Where(x => x > 0).ToList();
        if (positives.Count > 0)
        {
            int smallestPositive = positives.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        numbers.Sort();       
        Console.WriteLine("The sorted list is:");
        foreach (int v in numbers)
            Console.WriteLine(v);
    }
}