/*
Author: Joshua Walker
Description: Child class to hold variables and rewrite methods specific to a LEGO minifigure. Details like the year it was released (since the same minifigure can be reused across multiple years in sets) and the included accessories make it stand out.
Date: 7/15/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit06/project-plan.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWMinifigure : JWLegoItem
{
    private int _jwYear;
    private string _jwAccessory;
    public JWMinifigure(string jwName, float jwEstimatedValue, string jwTheme, int jwQuantity, int jwYear, string jwAccessory = "None") : base(jwName, jwEstimatedValue, jwTheme, jwQuantity)
    {
        _jwYear = jwYear;
        _jwAccessory = jwAccessory;
    }
    public override string DisplayItem()
    {
        // return as a string the way the item should display on the Console
        return $"{_jwName} Accessory: {_jwAccessory} Theme:{_jwTheme} {_jwYear} (~${_jwEstimatedValue} -- Qty: {_jwQuantity})";
    }
    public override string StringForFile()
    {
        // compile the item's data into a string to be saved to a file
        return $"Minifigure[]{_jwName}|{_jwEstimatedValue}|{_jwTheme}|{_jwQuantity}|{_jwYear}|{_jwAccessory}";
    }
}