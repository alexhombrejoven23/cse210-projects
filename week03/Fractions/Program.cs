using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();       
        Fraction f2 = new Fraction(6);      
        Fraction f3 = new Fraction(6, 7);   
        Fraction f4 = new Fraction(1, 3);   

        DisplayFraction(f1);
        DisplayFraction(f2);
        DisplayFraction(f3);
        DisplayFraction(f4);

        f1.SetTop(3);
        f1.SetBottom(4);
        Console.WriteLine("\nDespués de cambiar valores:");
        DisplayFraction(f1);
    }

    static void DisplayFraction(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}