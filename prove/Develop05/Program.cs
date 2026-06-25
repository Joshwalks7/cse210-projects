//range operator: https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
using System;
using System.IO;
using System.IO.Enumeration;
class Program
{
    static void Main(string[] args)
    {
        List<JWGoal> jwGoalsList = new List<JWGoal>();
        int jwCurrentPoints = 0;
        string jwOptionsMessage = $"\nMenu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit\nSelect a choice from the menu: ";
        string jwUserChoice = "";
        Console.WriteLine($"You have {jwCurrentPoints} points.");
        Console.Write(jwOptionsMessage);
        jwUserChoice = Console.ReadLine();
        while(jwUserChoice != "6")
        {
            if(jwUserChoice == "1")
            {
                Console.Write("The types of Goals are:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal\nWhich type of goal would you like to create? ");
                string jwGoalChoice = "";
                jwGoalChoice = Console.ReadLine();
                if(jwGoalChoice == "1")
                {
                    Console.Write("What is the name of your goal? ");
                    string jwName = Console.ReadLine();
                    Console.Write("What is a short description of it? ");
                    string jwDescription = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    string jwPointValue = Console.ReadLine();
                    JWSimpleGoal jwSimpleGoal = new JWSimpleGoal(jwName, jwDescription, int.Parse(jwPointValue));
                    jwGoalsList.Add(jwSimpleGoal);
                }
                else if(jwGoalChoice == "2")
                {
                    Console.Write("What is the name of your goal? ");
                    string jwName = Console.ReadLine();
                    Console.Write("What is a short description of it? ");
                    string jwDescription = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    string jwPointValue = Console.ReadLine();
                    JWEternalGoal jwEternalGoal = new JWEternalGoal(jwName, jwDescription, int.Parse(jwPointValue));
                    jwGoalsList.Add(jwEternalGoal);
                }
                else if(jwGoalChoice == "3")
                {
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
                    JWChecklistGoal jwChecklistGoal = new JWChecklistGoal(jwName, jwDescription, int.Parse(jwPointValue), int.Parse(jwRepsGoal), int.Parse(jwBonus));
                    jwGoalsList.Add(jwChecklistGoal);
                }
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
                Console.WriteLine("What goal did you accomplish? ");
                int jwGoalSelection = int.Parse(Console.ReadLine()) -1;
                jwCurrentPoints += jwGoalsList[jwGoalSelection].RecordEvent();
            }
            Console.WriteLine($"You have {jwCurrentPoints} points.");
            Console.Write(jwOptionsMessage);
            jwUserChoice = Console.ReadLine();
        }
    }
    static void SaveFile(List<JWGoal> jwGoalList, int jwPoints)
        //function prompts user for the file name they wish to write their journal to and uses a method to properly write the data into the file.
        {
            Console.Write("What is the filename for the file? ");
            string jwFileName = Console.ReadLine();

            using (StreamWriter jwOutputFile = new StreamWriter(jwFileName))
                {
                    jwOutputFile.WriteLine(jwPoints);
                    foreach(JWGoal jwGoal in jwGoalList)
                    {
                        jwOutputFile.WriteLine(jwGoal.StringForFile());
                    }
                }
        }
    static void LoadFile(ref int jwCurrentPoints, List<JWGoal> jwGoalsList)
    {
        Console.WriteLine("What is the filename? ");
        string jwFilename = Console.ReadLine();

        string[] jwLines = System.IO.File.ReadAllLines(jwFilename);

        jwCurrentPoints += int.Parse(jwLines[0]);
        foreach (string jwLine in jwLines[1..])
        {
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
        int jwListCount = 1;
                Console.WriteLine("The goals are:");
                foreach(JWGoal goal in jwGoalsList)
                {
                    Console.WriteLine($"{jwListCount}. {goal.DisplayGoal()}");
                    jwListCount++;
                }
    }
    static void DisplayGoalNames(List<JWGoal> jwGoalsList)
    {
        int jwListCount = 1;
                Console.WriteLine("The goals are:");
                foreach(JWGoal goal in jwGoalsList)
                {
                    Console.WriteLine($"{jwListCount}. {goal.DisplayName()}");
                    jwListCount++;
                }
    }
}