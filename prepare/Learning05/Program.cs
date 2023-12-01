using System;

class Program
{
    static void Main()
    {
        Square square = new Square("Red", 5.0);

        Console.WriteLine($"Color: {square.Color}");
        Console.WriteLine($"Area: {square.GetArea()}");


    }
}