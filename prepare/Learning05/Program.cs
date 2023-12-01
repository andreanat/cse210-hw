using System;

class Program
{
    static void Main(string[] args)
    {
        Square mySquare = new Square("Blue", 8.0);

        string squareColor = mySquare.Color;
        Console.WriteLine($"Square color: {squareColor}");

        double squareArea = mySquare.GetArea();
        Console.WriteLine($"Square area: {squareArea}");


    }
}