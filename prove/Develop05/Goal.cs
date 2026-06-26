/*
Author: Joshua Walker
Description: Parent class to hold variables and data related to goals -- name, description, and points awarded for logging a goal. Establish the common methods each child class needs that will be overriden
Date: 6/25/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit05/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
    3. Optional Parameters -- https://gemini.google.com/share/620d364b4dcd
*/
using System;

public abstract class JWGoal
{
    protected string _jwName;
    protected string _jwDescription;
    protected int _jwPointValue;

    public JWGoal(string jwName, string jwDescription, int jwPointValue)
    {
        // assigns common variables for all child classes
        _jwName = jwName;
        _jwDescription = jwDescription;
        _jwPointValue = jwPointValue;
    }

    public abstract int RecordEvent();
    // decide unique outcome of a user recording a goal completion
    public abstract string StringForFile();
    // prepare data to be stored in a file
    public abstract void DeconstructFromFile(string jwFileLine);
    // split code from a file and assign it to variables
    public abstract string DisplayGoal();
    // display the goal status to the user
    public string DisplayName()
    {
        // simply return the name of the goal the user chose
        return _jwName;
    }
}