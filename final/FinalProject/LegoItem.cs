/*
Author: Joshua Walker
Description: Parent class to hold methods and variables shared amongst child LEGO items. Some methods are abstract and meant to be overridden. Shared variables include the name of the item, its estimated value, its theme (Star Wars, City, Friends, etc), and the quantity of the item.
Date: 7/15/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit06/project-plan.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public abstract class JWLegoItem
{
    protected string _jwName;
    protected float _jwEstimatedValue;
    protected string _jwTheme;
    protected int _jwQuantity;
    public JWLegoItem(string jwName, float jwEstimatedValue, string jwTheme, int jwQuantity)
    {
        _jwName = jwName;
        _jwEstimatedValue = jwEstimatedValue;
        _jwTheme = jwTheme;
        _jwQuantity = jwQuantity;
    }
    public abstract string DisplayItem(); // each item will display uniquely as it has different data
    public abstract string StringForFile(); // each item will be compiled uniquely for a file
    public float DisplayEstimatedValue()
    {
        // simply return the estimated value
        return _jwEstimatedValue;
    }
    public string DisplayTheme()
    {
        // return the theme of the LEGO item
        return _jwTheme;
    }
    public void DecreaseQuantity(int jwDeceaseBy)
    {
        // descrease the item's quantity based on the user's desired amount passed in as a parameter
        _jwQuantity = _jwQuantity - jwDeceaseBy;
    }
    public bool CheckQuantity()
    {
        // if the quantity is less than or equal to 0, return true that way the function that called this knows to remove it from the inventory
        if (_jwQuantity <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}