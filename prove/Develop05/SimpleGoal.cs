/*
Author: Joshua Walker
Description: Child class to hold variables and data related to Simple Goals -- goals that can be completed once to award a user points
Date: 6/25/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit05/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWSimpleGoal : JWGoal
{
    private bool _jwIsComplete = false;

    public JWSimpleGoal(string jwName = "Unknown", string jwDescription = "Unknown", int jwPointValue = 0) : base(jwName, jwDescription, jwPointValue)
    {
        // passes parameters to the base class
    }
    public override int RecordEvent()
    {
        // mark the goal as being completed, print the points awarded, and return the number of points needing to be added to the current point total
        _jwIsComplete = true;
        Console.WriteLine($"Congrats! You have earned {_jwPointValue} points!");
        return _jwPointValue;
    }
    public override string StringForFile()
    {
        // formats into a string data that will be stored in a file
        return $"SimpleGoal:{_jwName}|{_jwDescription}|{_jwPointValue}|{_jwIsComplete}";
    }
    public override void DeconstructFromFile(string jwFileLine)
    {
        // splits the line data into parts that can then be assigned to the variables in both the parent and child class
        string[] jwParts = jwFileLine.Split("|");
        _jwName = jwParts[0];
        _jwDescription = jwParts[1];
        _jwPointValue = int.Parse(jwParts[2]);
        _jwIsComplete = bool.Parse(jwParts[3]);
    }
    public override string DisplayGoal()
    {
        // if the goal has been complete, mark with an X so the user knows
        if (_jwIsComplete)
        {
            return $"[X] {_jwName} ({_jwDescription})";
        }
        else
        {
            return $"[ ] {_jwName} ({_jwDescription})";
        }
    }
}