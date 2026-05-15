/*
Author: Joshua Walker
Description: Program to create a journal, add entries to it based on randomized prompts, save the journal as a file, and load a journal from a file
Date: 5/15/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit02/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
    3. Site about how to count items in a list -- https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.count?view=netframework-4.8.1
    4. Site about IndexOutOfRange exception -- https://www.tutorialsteacher.com/articles/indexoutofrange-exception-in-csharp

*/
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Jolly Ole Journal!");

        string userChoiceJW = "-1";
        Journal journal = new Journal();
        while (userChoiceJW != "6")
        {
            Console.WriteLine("Please select one of the following choices:\n1. Write Entry\n2. Display Journal\n3. Load Journal\n4. Save Journal\n5. See Journal Stats\n6. Quit");
            Console.Write("What would you like to do? ");
            userChoiceJW = Console.ReadLine();
            if (userChoiceJW == "1")
            {
                journal.CreateEntry(journal);
            }
            else if (userChoiceJW == "2")
            {
                journal.Display();
            }
            else if (userChoiceJW == "3")
            {
                LoadFile(journal);
            }
            else if (userChoiceJW == "4")
            {
                SaveFile(journal);
            }
            else if (userChoiceJW == "5")
            {
                journal.DisplayNumEntries(journal);
            }
            else if (userChoiceJW == "6")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid selection");
            }
        }

        static void LoadFile(Journal journal)
        {
            journal._journalEntriesJW = [];
            Console.Write("What is the file name? ");
            string fileName = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(fileName);
            journal.FromString(lines, journal);
            Console.WriteLine($"{fileName} correctly loaded!");
        }

        static void SaveFile(Journal journal)
        {
            Console.Write("What file would you like to save this journal in? ");
            string fileName = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(fileName))
                {
                    string fileStringJW = journal.StringJournal(journal);
                    outputFile.Write(fileStringJW);
                    Console.WriteLine($"Journal correctly saved in {fileName}");
                }
        }
    }
}