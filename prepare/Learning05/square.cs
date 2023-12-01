using System;

public class Square : Shape
{
    private double _side; 

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        double area = _side * _side;
        Console.WriteLine($"Calculating area of a square with side {_side}.");
        return area;
    }
}

class Program
{
    static void Main()
    {
        Square mySquare = new Square("Green", 5.0);

        Console.WriteLine($"Square color: {mySquare.Color}");
        mySquare.Color = "Yellow";
        Console.WriteLine($"Updated square color: {mySquare.Color}");

        double area = mySquare.GetArea();
        Console.WriteLine($"Square area: {area}");
    }
}
