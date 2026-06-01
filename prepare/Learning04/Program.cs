using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment test1 = new MathAssignment("James", "History", "7.3", "8-19");
        Console.WriteLine(test1.GetSummary());
        Console.WriteLine(test1.GetHomeworkList());
        WritingAssignment test2 = new WritingAssignment("Crystal", "English", "Tale of Two Cities");
        Console.WriteLine(test2.GetSummary());
        Console.WriteLine(test2.GetWritingInformation());
    }
}