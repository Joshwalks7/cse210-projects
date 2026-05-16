/*
Author: Joshua Walker
Description: Program to create a journal, add entries to it based on randomized prompts, save the journal as a file, and load a journal from a file
Date: 5/15/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit02/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
    3. Site about how to count items in a list -- https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.count?view=netframework-4.8.1
    4. Site about IndexOutOfRange exception -- https://www.tutorialsteacher.com/articles/indexoutofrange-exception-in-csharp
Creativity: I added an extra option (5) that will count and display the total number of entries in the journal. Also, I added a prompt to each entry: What is your mood right now? Following this question is the randomized prompt.
*/
using System;
/// <summary>
/// Program presents user with 6 options regarding their journal and calls from the Journal and Entry classes
/// </summary>
class JWProgram
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Jolly Ole Journal!");

        string jwUserChoice = "-1";
        // create a new journal that can be used immediately to start writing entries to at any stage of the program
        JWJournal jwJournal = new JWJournal();
        while (jwUserChoice != "6")
        {
            Console.WriteLine("\nPlease select one of the following choices:\n1. Write Entry\n2. Display Journal\n3. Load Journal\n4. Save Journal\n5. See Journal Stats\n6. Quit");

            Console.Write("What would you like to do? ");
            jwUserChoice = Console.ReadLine();

            if (jwUserChoice == "1")
            {
                // create an entry in the journal
                jwJournal.CreateEntry(jwJournal);
            }
            else if (jwUserChoice == "2")
            {
                // display the journal entries
                jwJournal.DisplayJournal();
            }
            else if (jwUserChoice == "3")
            {
                // take data from a file and load it into a journal
                LoadFile(jwJournal);
            }
            else if (jwUserChoice == "4")
            {
                // save data from the journal by writting it into a file
                SaveFile(jwJournal);
            }
            else if (jwUserChoice == "5")
            {
                // Creativity -- displays the number of entries within a journal
                jwJournal.DisplayNumEntries(jwJournal);
            }
            else if (jwUserChoice == "6")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid selection");
            }
        }

        static void LoadFile(JWJournal jwJournal)
        // function prompts a user for a file name to load journal entries from and passes it through to other methods that properly load the data into a journal
        {
            // clear the current journal class
            jwJournal._jwJournalEntries = [];

            //prompt file name
            Console.Write("What is the file name? ");
            string fileName = Console.ReadLine();

            string[] lines = System.IO.File.ReadAllLines(fileName);
            jwJournal.LoadFileString(lines, jwJournal);

            Console.WriteLine($"{fileName} correctly loaded!");
        }

        static void SaveFile(JWJournal jwJournal)
        //function prompts user for the file name they wish to write their journal to and uses a method to properly write the data into the file.
        {
            Console.Write("What file would you like to save this journal in? ");
            string jwFileName = Console.ReadLine();

            using (StreamWriter jwOutputFile = new StreamWriter(jwFileName))
                {
                    string jwFileString = jwJournal.GatherAllJournalEntries(jwJournal);
                    jwOutputFile.Write(jwFileString);
                    Console.WriteLine($"Journal correctly saved in {jwFileName}");
                }
        }
    }
}