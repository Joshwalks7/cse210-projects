using System;

class Program
{
    static void Main(string[] args)
    {
        // Fraction fraction = new Fraction(2, 5);
        // fraction.SetTop(2);
        // fraction.SetBottom(3);
        // Console.WriteLine(fraction.GetFractionString());
        // Console.WriteLine(fraction.GetDecimalValue());
        Fraction fraction = new Fraction();
        Random generateRandom = new Random();
        for (int i = 1; i < 21; i++)
        {
            int topInt = generateRandom.Next(100);
            int bottomInt = generateRandom.Next(100);
            fraction.SetTop(topInt);
            fraction.SetBottom(bottomInt);
            Console.WriteLine($"Fraction {i}: string: {fraction.GetTop()}/{fraction.GetBottom()} Number: {fraction.GetDecimalValue()}");
        }
    }
}