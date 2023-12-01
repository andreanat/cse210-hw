using System;

public class Shape
{
    private string color; 

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Shape(string color)
    {
        this.color = color;
    }
    public virtual double GetArea()
    {
        Console.WriteLine("Calculating area of a generic shape.");
        return 0;
    }
}

class Program
{
    static void Main()
    {

        Shape myShape = new Shape("Red");

        Console.WriteLine($"Initial color: {myShape.Color}");
        myShape.Color = "Blue";
        Console.WriteLine($"Updated color: {myShape.Color}");

        double area = myShape.GetArea();
        Console.WriteLine($"Area: {area}");
    }
}
