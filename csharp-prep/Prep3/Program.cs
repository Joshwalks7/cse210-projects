using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int RandomNumber = randomGenerator.Next(1,101);
        int guess = 0;
        do
        {
            Console.WriteLine("Guess a number");
            guess = int.Parse(Console.ReadLine());
            if (guess > RandomNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < RandomNumber)
            {
                Console.WriteLine("Higher");
            }    
            else
            {
                Console.WriteLine($"That's it! The number was {RandomNumber}!");
            }
        } while (guess != RandomNumber);
        
    }
}