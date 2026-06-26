/*
Author: Joshua Walker
Description: Child class to hold variables and data related to Eternal Goals -- goals that can infinitely be repeated, always adding more points for the user
Date: 6/25/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit05/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWEternalGoal : JWGoal
{
    public JWEternalGoal(string jwName = "Unknown", string jwDescription = "Unknown", int jwPointValue = 0) : base(jwName, jwDescription, jwPointValue)
    {
        // passes parameters to the base class
    }
    public override int RecordEvent()
    {
        // Print the points awarded, and return the number of points needing to be added to the current point total
        Console.WriteLine($"Congrats! You have earned {_jwPointValue} points!");
        return _jwPointValue;
    }
    public override string StringForFile()
    {
        // formats into a string data that will be stored in a file
        return $"EternalGoal:{_jwName}|{_jwDescription}|{_jwPointValue}";
    }
    public override void DeconstructFromFile(string jwFileLine)
    {
        // splits the line data into parts that can then be assigned to the variables in the parent class
        string[] jwParts = jwFileLine.Split("|");
        _jwName = jwParts[0];
        _jwDescription = jwParts[1];
        _jwPointValue = int.Parse(jwParts[2]);
    }
    public override string DisplayGoal()
    {
        // since the goal can never be fully completed, always return the brackets with no X
        return $"[ ] {_jwName} ({_jwDescription})";
    }
}