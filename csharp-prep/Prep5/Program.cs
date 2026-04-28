using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = GetUserName();
        int userNum = GetFavNum();

        int birthYear;
        GetUserBirthYear(out birthYear);

        int squareNum = SquareNum(userNum);

        DisplayResult(name, squareNum, birthYear);

    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string GetUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int GetFavNum()
    {
        Console.Write("Please enter your favorite number: ");
        int favNum = int.Parse(Console.ReadLine());
        return favNum;
    }
    static void GetUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }
    static int SquareNum(int num)
    {
        int square = num * num;
        return square;
    }
    static void DisplayResult(string name, int squareNum, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your favorite number is {squareNum}");
        Console.WriteLine($"{name}, you will be {2026 - birthYear} years old this year!");
    }
}