using System;

public class Shape
{
    private string color; // member variable

    // Getter and Setter for the color
    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    // Constructor that accepts color and sets it
    public Shape(string color)
    {
        this.color = color;
    }

    // Virtual method for calculating the area
    public virtual double GetArea()
    {
        Console.WriteLine("Calculating area of a generic shape.");
        return 0;
    }
}

// Example usage:
class Program
{
    static void Main()
    {
        // Create an instance of Shape
        Shape myShape = new Shape("Red");

        // Access and modify color using the getter and setter
        Console.WriteLine($"Initial color: {myShape.Color}");
        myShape.Color = "Blue";
        Console.WriteLine($"Updated color: {myShape.Color}");

        // Call the virtual method GetArea
        double area = myShape.GetArea();
        Console.WriteLine($"Area: {area}");
    }
}
