/*
Author: Joshua Walker
Description: Child class to hold variables and rewrite methods specific to a LEGO set that is complete. While the set does not need to be New Sealed in Box (NISB), it should be 100% complete including all the minifigures. The condition of the set (whether it's opened and has been played with or still in the box) should be recorded
Date: 7/15/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit06/project-plan.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;
using System.Globalization;

public class JWFullSet : JWLegoItem
{
    private string _jwCondition;
    private int _jwSetNumber;
    public JWFullSet(string jwName, float jwEstimatedValue, string jwTheme, int jwQuantity, string jwCondition, int jwSetNumber) : base(jwName, jwEstimatedValue, jwTheme, jwQuantity)
    {
        _jwCondition = jwCondition;
        _jwSetNumber = jwSetNumber;
    }
    public override string DisplayItem()
    {
        // return as a string the way the item should display on the Console
        return $"{_jwName} Set: {_jwSetNumber} Condition: {_jwCondition} Theme:{_jwTheme} (~${_jwEstimatedValue} -- Qty: {_jwQuantity})";
    }
    public override string StringForFile()
    {
        // compile the item's data into a string to be saved to a file
        return $"FullSet[]{_jwName}|{_jwEstimatedValue}|{_jwTheme}|{_jwQuantity}|{_jwCondition}|{_jwSetNumber}";
    }
}