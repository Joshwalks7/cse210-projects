/*
Author: Joshua Walker
Description: Base class that holds variables/methods common across all child classes, specifically with regards to beginning and ending the activities and handling duration (time) entries. 
Date: 6/12/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit04/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
    3. //https://www.w3schools.com/cs/cs_strings_chars.php
*/
using System;

public class JWActivity
{
    private string _jwName;
    private string _jwDescription;
    protected int _jwDuration;

    public JWActivity(string jwName, string jwDescription)
    {
        // sets the name and description of the activity
       _jwName = jwName;
       _jwDescription = jwDescription;
    }
    public string JWBegin()
    {
        // string value is returned dispalying the activity description and name, prompts user for duration
        string rvalue = $"Welcome to the {_jwName} Activity.\n\nThis activity will help you {_jwDescription}.\n\nHow long, in seconds, would you like for your session? ";
        return rvalue;
    }
    public void JWSetDuration(string jwDurationString)
    {
        // sets the duration of the activity
        int jwDurationTime = int.Parse(jwDurationString);
        _jwDuration = jwDurationTime;
    }
    public void JWGetReady()
    {
        // clears the console and displays an animation waiting for activity to start.
        Console.Clear();
        Console.WriteLine("Get ready...");
        JWDisplayAnimation();
    }
    public void JWFinishProgram()
    {
        // ends the activity displaying the number of seconds the activity lasted for
        Console.WriteLine("\nWell done!!");
        JWDisplayAnimation();
        Console.WriteLine($"\nYou have completed another {_jwDuration} seconds of the {_jwName} Activity.");
        JWDisplayAnimation();
        Console.Clear();
    }
    public void JWDisplayAnimation(int rotations = 4)
    {
        // displays spinny animation and accepts the number of rotations needed. The default is 4 (1 second)
        for (int i = 0; i < rotations; i++)
        {
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
    public void JWCountDown(int seconds)
    {
        // for the number of specified seconds, the console will display a count down
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine("");
    }
}