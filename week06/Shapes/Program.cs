using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Rojo", 4));
        shapes.Add(new Rectangle("Azul", 3, 5));
        shapes.Add(new Circle("Verde", 2));
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"El color es {color} y el área es {area}");
        }
    }
}