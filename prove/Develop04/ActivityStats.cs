/*
Author: Joshua Walker
Description: Base class that holds variables/methods common across all child classes, specifically with regards to beginning and ending the activities and handling duration (time) entries. 
Date: 6/12/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit04/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWActivityStats
{
    private int _jwBreathingCount;
    private int _jwReflectingCount;
    private int _jwListingCount;
    public JWActivityStats()
    {
        // constructor sets all count variables to 0
        _jwBreathingCount = 0;
        _jwReflectingCount = 0;
        _jwListingCount = 0;
    }
    public void JWAddCount(string jwUserChoice)
    {
        // the user's choice gets passed through, and depending on which choice it is the count is upped
        if (jwUserChoice == "1")
        {
            _jwBreathingCount++;
        }
        else if (jwUserChoice == "2")
        {
            _jwReflectingCount++;
        }
        else
        {
            _jwListingCount++;
        }
    }
    public string JWDisplayStats()
    {
        //returns the stats in an easy to see manner (string)
        return $"Breathing Activity: {_jwBreathingCount} time(s) completed\nReflecting Activity: {_jwReflectingCount} time(s) completed\nListing Activity: {_jwListingCount} time(s) completed\n\nLet's get you back to the program!";
    }
}