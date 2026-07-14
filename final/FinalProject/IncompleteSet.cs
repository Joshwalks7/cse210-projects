/*
Author: Joshua Walker
Description: Child class to hold variables and rewrite methods specific to a LEGO set that is incomplete. Incomplete sets could be parts of builds or ships that are not fully finished. Some sets may have only a few of the minifigures or none at all. This must be recorded for inventory purposes since often collectors acquire sets missing data.
Date: 7/15/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit06/project-plan.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWIncompleteSet : JWLegoItem
{
    private string _jwPercentComplete;
    private int _jwSetNumber;
    private string _jwMinifigures;
    private string _jwDescription;
    public JWIncompleteSet(string jwName, float jwEstimatedValue, string jwTheme, int jwQuantity, string jwPercentComplete, int jwSetNumber, string jwMinifigures, string jwDescription) : base(jwName, jwEstimatedValue, jwTheme, jwQuantity)
    {
        _jwPercentComplete = jwPercentComplete;
        _jwSetNumber = jwSetNumber;
        _jwMinifigures = jwMinifigures;
        _jwDescription = jwDescription;
    }
    public override string DisplayItem()
    {
        // return as a string the way the item should display on the Console
        return $"{_jwName} Set: {_jwSetNumber} ~ {_jwPercentComplete}% Complete Theme:{_jwTheme} (~${_jwEstimatedValue} -- Qty: {_jwQuantity}) Minifigures: {_jwMinifigures} Description: {_jwDescription}";
    }
    public override string StringForFile()
    {
        // compile the item's data into a string to be saved to a file
        return $"IncompleteSet[]{_jwName}|{_jwEstimatedValue}|{_jwTheme}|{_jwQuantity}|{_jwPercentComplete}|{_jwSetNumber}|{_jwMinifigures}|{_jwDescription}";
    }
}