using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string percentageString = Console.ReadLine();
        int percentageInt = int.Parse(percentageString);
        string letter = "";

        if (percentageInt >= 90)
        {
            letter = "A";
        }
        else if (percentageInt >= 80)
        {
            letter = "B";
        }
        else if (percentageInt >= 70)
        {
            letter = "C";
        }
        else if (percentageInt >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"You have a {letter} in the course.");

        if (percentageInt >= 70)
        {
            Console.Write("You passed! Great work!");
        }
        else
        {
            Console.Write("You failed, better luck next time!");
        }
    }
}