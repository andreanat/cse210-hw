using System;

class Fraction{
    private int _top;
    private int _bottom;

    //constructor1
    public Fraction(){
        _top = 1;
        _bottom = 1;
    }

        //constructor2
    public Fraction(int _top1){
        _top = _top1;
        _bottom = 1;
    }

    //constructor3
       public Fraction(int _top1, int _bottom1){
        _top = _top1;
        _bottom = _bottom1;
    }
    public string GetFractionString(){
        string text = $"{_top}/{_bottom}";
        return text;
    }
    public Double GetDecimalValue(){
        return (double)_top / (double)_bottom;

    }
    
    public static void Main(string[] args)
    {
        // Your program's entry point
        // Create instances of Fraction and perform any desired operations here
    }
}