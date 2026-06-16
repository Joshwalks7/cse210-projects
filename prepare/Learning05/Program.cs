using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> list = new List<Shape>();
        Square square = new Square("black", 4);
        list.Add(square);
        Rectangle rectangle = new Rectangle("black", 4, 5);
        list.Add(rectangle);
        Circle circle = new Circle("black", 4);
        list.Add(circle);
        foreach (Shape s in list)
        {
            Console.WriteLine(s.GetColor());
            Console.WriteLine(s.GetArea());
        }
        
    }
}