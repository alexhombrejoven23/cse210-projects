using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        // Creating a list of shapes
        List<Shape> shapes = new List<Shape>();

        // Adding different types of shapes to the list
        shapes.Add(new Square("red", 5));
        shapes.Add(new Rectangle("blue", 4, 6));
        shapes.Add(new Circle("green", 3));

        // Calculate and display the area of each shapes
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Shape: {shape.GetType().Name}, Area: {shape.GetArea():F2}");
        }
    }
}