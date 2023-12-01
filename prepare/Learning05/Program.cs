using System;

class Program
{
    static void Main()
    {
        Square square = new Square("Red", 5.0);

        Console.WriteLine($"Color: {square.Color}");
        Console.WriteLine($"Area: {square.GetArea()}");

        Rectangle rectangle = new Rectangle("Blue", 4.0, 6.0);
        Console.WriteLine($"Rectangle - Color: {rectangle.Color}, Area: {rectangle.GetArea()}");

        Circle circle = new Circle("Green", 3.0);
        Console.WriteLine($"Circle - Color: {circle.Color}, Area: {circle.GetArea()}");


    }
}