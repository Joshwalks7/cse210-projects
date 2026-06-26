/*
Author: Joshua Walker
Description: Child class to hold variables and data related to Checklist Goals -- goals that need to be repeated a number of times until fully achieved, awarding points for each repition and bonus points when achieved
Date: 6/25/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit05/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWChecklistGoal : JWGoal
{
    private int _jwRepsGoal;
    private int _jwRepsCount = 0;
    private int _jwBonusPoints;
    public JWChecklistGoal(string jwName = "Unkown", string jwDescription = "Unknown", int jwPointValue = 0, int jwRepsGoal = 0, int jwBonusPoints = 0) : base(jwName, jwDescription, jwPointValue)
    {
        // passes parameters to the base class and set the Rep Goal amount and Bonus Points
        _jwRepsGoal = jwRepsGoal;
        _jwBonusPoints = jwBonusPoints;
    }
    public override int RecordEvent()
    {
        // check to see if the goal has been fully completed, and print how many points the user earns respectively. Return the number of points needing to be added to the current point total
        _jwRepsCount++;
        if (_jwRepsCount == _jwRepsGoal)
        {
            Console.WriteLine($"Congrats! You have earned {_jwPointValue + _jwBonusPoints} points!");
            return _jwPointValue + _jwBonusPoints;
        }
        else
        {
            Console.WriteLine($"Congrats! You have earned {_jwPointValue} points!");
            return _jwPointValue;
        }
    }
    public override string StringForFile()
    {
        // formats into a string data that will be stored in a file
        return $"ChecklistGoal:{_jwName}|{_jwDescription}|{_jwPointValue}|{_jwBonusPoints}|{_jwRepsGoal}|{_jwRepsCount}";
    }
    public override void DeconstructFromFile(string jwFileLine)
    {
        // splits the line data into parts that can then be assigned to the variables in both the parent and child class
        string[] jwParts = jwFileLine.Split("|");
        _jwName = jwParts[0];
        _jwDescription = jwParts[1];
        _jwPointValue = int.Parse(jwParts[2]);
        _jwBonusPoints = int.Parse(jwParts[3]);
        _jwRepsGoal = int.Parse(jwParts[4]);
        _jwRepsCount = int.Parse(jwParts[5]);
    }
    public override string DisplayGoal()
    {
        // if the goal has been complete, mark with an X so the user knows. Display the number of times the goal has been repeated
        if (_jwRepsCount == _jwRepsGoal)
        {
            return $"[X] {_jwName} ({_jwDescription}) -- Currently Completed: {_jwRepsCount}/{_jwRepsGoal}";
        }
        else
        {
            return $"[ ] {_jwName} ({_jwDescription}) -- Currently Completed: {_jwRepsCount}/{_jwRepsGoal}";
        }
    }
}