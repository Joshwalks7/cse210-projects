/*
Author: Joshua Walker
Description: Write a program that allows a user to create simple, eternal, and checklist goals as well as provide a way to record progress on said goals in a gamified manner. Program ends when the user chooses 7 (quit).
Date: 6/25/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit05/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
    3. Range Operator -- https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes

Creativity: While testing the program, I continued to get frustrated because I would make a mistake while creating a goal (wrong name, incorrect point value, etc), and finally I decided to add a "Delete Goal" feature. This will not only delete a specified goal, but it does so in a fun manner that uses Thread.sleep() to display a waiting message as the program removes the goal from the master list. It's pretty fun.
*/

using System;
using System.IO;
using System.IO.Enumeration;
class Program
{
    static void Main(string[] args)
    {
        // create initial empty goal list
        List<JWGoal> jwGoalsList = new List<JWGoal>();
        int jwCurrentPoints = 0;
        string jwOptionsMessage = $"\nMenu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Delete a goal\n  7. Quit\nSelect a choice from the menu: ";
        Console.WriteLine($"You have {jwCurrentPoints} points.");
        Console.Write(jwOptionsMessage);
        string jwUserChoice = Console.ReadLine();
        while(jwUserChoice != "7")
        {
            // run until the user types "7"
            if (jwUserChoice == "1")
            {
                CreateGoal(jwGoalsList);
            }
            else if (jwUserChoice == "2")
            {
                DisplayGoals(jwGoalsList);
            }
            else if (jwUserChoice == "3")
            {
                SaveFile(jwGoalsList, jwCurrentPoints);
            }
            else if (jwUserChoice == "4")
            {
                LoadFile(ref jwCurrentPoints, jwGoalsList);
            }
            else if (jwUserChoice == "5")
            {
                DisplayGoalNames(jwGoalsList);
                Console.Write("What goal did you accomplish? ");
                // indentify the index of the goal the user is recording, then call the respective method
                int jwGoalSelection = int.Parse(Console.ReadLine()) -1;
                jwCurrentPoints += jwGoalsList[jwGoalSelection].RecordEvent();
            }
            else if (jwUserChoice == "6")
            {
                DeleteGoal(jwGoalsList);
            }
            Console.WriteLine($"\nYou have {jwCurrentPoints} points.");
            Console.Write(jwOptionsMessage);
            jwUserChoice = Console.ReadLine();
        }
    }
    static void CreateGoal(List<JWGoal> jwGoalsList)
    {
        // function to instantiate different goals (simple, eternal, or checklist) based on user input
        Console.Write("The types of Goals are:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal\nWhich type of goal would you like to create? ");
        string jwGoalChoice = Console.ReadLine();
        if (jwGoalChoice == "1")
        {
            // simple goal
            Console.Write("What is the name of your goal? ");
            string jwName = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string jwDescription = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string jwPointValue = Console.ReadLine();
            // create new instance with parameters
            JWSimpleGoal jwSimpleGoal = new JWSimpleGoal(jwName, jwDescription, int.Parse(jwPointValue));
            jwGoalsList.Add(jwSimpleGoal);
        }
        else if (jwGoalChoice == "2")
        {
            // eternal goal
            Console.Write("What is the name of your goal? ");
            string jwName = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string jwDescription = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string jwPointValue = Console.ReadLine();
            // create new instance with parameters
            JWEternalGoal jwEternalGoal = new JWEternalGoal(jwName, jwDescription, int.Parse(jwPointValue));
            jwGoalsList.Add(jwEternalGoal);
        }
        else if (jwGoalChoice == "3")
        {
            // checklist goal
            Console.Write("What is the name of your goal? ");
            string jwName = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string jwDescription = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string jwPointValue = Console.ReadLine();
            Console.Write("How many times does this goal need to be repeated to award bonus points? ");
            string jwRepsGoal = Console.ReadLine();
            Console.Write("What is the amount of bonus points for completion? ");
            string jwBonus = Console.ReadLine();
            // create new instance with parameters
            JWChecklistGoal jwChecklistGoal = new JWChecklistGoal(jwName, jwDescription, int.Parse(jwPointValue), int.Parse(jwRepsGoal), int.Parse(jwBonus));
            jwGoalsList.Add(jwChecklistGoal);
        }
    }
    static void SaveFile(List<JWGoal> jwGoalList, int jwPoints)
        //function prompts user for the file name they wish to write their goals to and uses the corresponding class methods to properly write the data into the file.
        {
            Console.Write("What is the filename for the file? ");
            string jwFileName = Console.ReadLine();

            using (StreamWriter jwOutputFile = new StreamWriter(jwFileName))
                {
                    jwOutputFile.WriteLine(jwPoints);
                    foreach (JWGoal jwGoal in jwGoalList)
                    {
                        jwOutputFile.WriteLine(jwGoal.StringForFile());
                    }
                }
        }
    static void LoadFile(ref int jwCurrentPoints, List<JWGoal> jwGoalsList)
    {
        // function prompts user for the filename they wish to pull their goals from and uses the respective goal names to create instances of the classes and add them to the master list
        Console.Write("What is the filename? ");
        string jwFilename = Console.ReadLine();

        string[] jwLines = System.IO.File.ReadAllLines(jwFilename);
        // grab the first line and add it to the current points
        jwCurrentPoints += int.Parse(jwLines[0]);
        foreach (string jwLine in jwLines[1..])
        {
            // all remaining lines are iterated through and split to identify the goal type. Remaining split section is passed through to the instance to set all the necessary variables
            string[] jwClassSplit = jwLine.Split(":");
            if (jwClassSplit[0] == "SimpleGoal")
            {
                JWSimpleGoal jwSimpleGoal = new JWSimpleGoal();
                jwGoalsList.Add(jwSimpleGoal);
                jwSimpleGoal.DeconstructFromFile(jwClassSplit[1]);
            }
            else if (jwClassSplit[0] == "EternalGoal")
            {
                JWEternalGoal jwEternalGoal = new JWEternalGoal();
                jwGoalsList.Add(jwEternalGoal);
                jwEternalGoal.DeconstructFromFile(jwClassSplit[1]);
            }
            else if (jwClassSplit[0] == "ChecklistGoal")
            {
                JWChecklistGoal jwChecklistGoal = new JWChecklistGoal();
                jwGoalsList.Add(jwChecklistGoal);
                jwChecklistGoal.DeconstructFromFile(jwClassSplit[1]);
            }
        }
    }
    static void DisplayGoals(List<JWGoal> jwGoalsList)
    {
        // simply display each goal, its description, and completion status
        int jwListCount = 1;
                Console.WriteLine("The goals are:");
                foreach (JWGoal goal in jwGoalsList)
                {
                    Console.WriteLine($"{jwListCount}. {goal.DisplayGoal()}");
                    jwListCount++;
                }
    }
    static void DisplayGoalNames(List<JWGoal> jwGoalsList)
    {
        // display only the names of each goal
        int jwListCount = 1;
                Console.WriteLine("The goals are:");
                foreach (JWGoal goal in jwGoalsList)
                {
                    Console.WriteLine($"{jwListCount}. {goal.DisplayName()}");
                    jwListCount++;
                }
    }
    static void DeleteGoal(List<JWGoal> jwGoalsList)
    {
        // delete a specified goal by targeting its index
        DisplayGoalNames(jwGoalsList);
        Console.Write("Which goal would you like to remove? ");
        int jwDeleteGoalIndex = int.Parse(Console.ReadLine()) -1;
        Console.Write($"Removing \"{jwGoalsList[jwDeleteGoalIndex].DisplayName()}\" from list...");
        for (int i = 4; i > 0; i--)
        {
            // fun animation to display to the user before the program deletes the goal
            Thread.Sleep(500);
            Console.Write("\b \b");
            Thread.Sleep(500);
            Console.Write(".");
        }
        jwGoalsList.RemoveAt(jwDeleteGoalIndex);
        Console.WriteLine("\rDeletion Successful!                           ");
    }
}