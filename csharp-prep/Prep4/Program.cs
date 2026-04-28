using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<int> NumList = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int UserInput = -1;
        int Sum = 0;
        while (UserInput != 0)
        {
            Console.Write("Enter Number: ");
            UserInput = int.Parse(Console.ReadLine());
            NumList.Add(UserInput);
        }
        foreach (int num in NumList)
        {
            Sum += num;
        }
        Console.WriteLine($"The sum is {Sum}");
        float average = ((float)Sum) / NumList.Count;
        Console.WriteLine($"The average is: {average}");
        int MaxNum = 0;
        foreach (int num in NumList)
        {
            if (num > MaxNum)
            {
                MaxNum = num;
            }
        }
        Console.WriteLine($"The biggest number is {MaxNum}");
    }
}