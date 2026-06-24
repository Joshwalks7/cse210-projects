using System;
using System.IO; 
class Program
{
    static void Main(string[] args)
    {
        List<JWGoal> jwGoalsList = new List<JWGoal>();
        int jwCurrentPoints = 0;
        string jwOptionsMessage = $"You have {jwCurrentPoints} points.\n\nMenu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit\nSelect a choice from the menu: ";
        string jwUserChoice = "";
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
                int jwListCount = 1;
                Console.WriteLine("The goals are:");
                foreach(JWGoal goal in jwGoalsList)
                {
                    Console.WriteLine($"{jwListCount}. {goal.DisplayGoal()}");
                    jwListCount++;
                }
            }
            else if (jwUserChoice == "3")
            {
                SaveFile(jwGoalsList, jwCurrentPoints);
            }
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
}