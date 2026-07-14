/*
Author: Joshua Walker
Description: Parent class to hold methods and variables related to a basic, standard personal inventory. A personal inventory can be instantiated alone from this class, and a selling inventory can be derived (child class). The inventory holds a list of all the LEGO items that belong to it as well as methods to manipulate the data and display to the user specific requests
Date: 7/15/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit06/project-plan.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWInventory
{
    protected string _jwName;
    protected List<JWLegoItem> _jwInventoryList = new List<JWLegoItem>();
    public JWInventory(string jwName)
    {
        _jwName = jwName;
    }
    public void DisplayCollection()
    {
        // iterates through the items in the inventory and displays them
        int jwListNum = 1;
        foreach(JWLegoItem jwItem in _jwInventoryList)
        {
            Console.WriteLine($"{jwListNum}. {jwItem.DisplayItem()}");
            jwListNum++;
        }
    }
    public void AddItem(JWLegoItem jwLegoItem)
    {
        // simply add an instance of a LEGO to the inventory list
        _jwInventoryList.Add(jwLegoItem);
    }
    public void RemoveItem(int jwItemIndex, int jwRemoveQuantity)
    {
        // decrease an item's quantity and check to see if the result is 0. If the quantity is less than or equal to 0, the item is removed from the inventory
        _jwInventoryList[jwItemIndex].DecreaseQuantity(jwRemoveQuantity);
        if (_jwInventoryList[jwItemIndex].CheckQuantity())
        {
            _jwInventoryList.RemoveAt(jwItemIndex);
        }
    }
    public JWLegoItem ReturnItemFromInventory(int jwItemIndex)
    {
        // simply return the entire specific LEGO item at a particular index in the list
        return _jwInventoryList[jwItemIndex];
    }
    public JWLegoItem RemoveFromInventory(int jwItemIndex)
    {
        // remove the item from the list and return it to the user to be added to another inventory
        JWLegoItem jwItemToMove = _jwInventoryList[jwItemIndex];
        _jwInventoryList.RemoveAt(jwItemIndex);
        return jwItemToMove;
    }
    public float EstimateTotal()
    {
        // iterate through the inventory items adding the estimated values together. Return the value
        float jwTotal = 0;
        foreach(JWLegoItem jwItem in _jwInventoryList)
        {
            jwTotal += jwItem.DisplayEstimatedValue();
        }
        return jwTotal;
    }
    public string DisplayMostExpensive()
    {
        // iterate through the inventory items to find the item with the highest value. Return the item information
        int jwExpensiveIndex = 0;
        float jwMostExpensivePrice = 0;
        foreach(JWLegoItem jwItem in _jwInventoryList)
        {
            if (jwItem.DisplayEstimatedValue() > jwMostExpensivePrice)
            {
                jwMostExpensivePrice = jwItem.DisplayEstimatedValue();
                jwExpensiveIndex = _jwInventoryList.IndexOf(jwItem);
            }
        }
        return _jwInventoryList[jwExpensiveIndex].DisplayItem();
    }
    public void DisplayTheme(string jwTheme)
    {
        // iterate through the inventory items displaying the item to the console if the theme matches the theme specified by the user
        foreach(JWLegoItem jwItem in _jwInventoryList)
        {
            if (jwItem.DisplayTheme().ToLower() == jwTheme.ToLower())
            {
                Console.WriteLine(jwItem.DisplayItem());
            }
        }
    }
    public void DeconstructFromFile(string jwLine)
    {
        // split the data from a file into identifiable LEGO items, instantiated the associated instance, and add it to the inventory
        string[] jwItemSplit = jwLine.Split("[]");
        if (jwItemSplit[0] == "Minifigure")
        {
            string[] jwClassSplit = jwItemSplit[1].Split("|");
            JWMinifigure jwMinifigure = new JWMinifigure(jwClassSplit[0], float.Parse(jwClassSplit[1]), jwClassSplit[2], int.Parse(jwClassSplit[3]), int.Parse(jwClassSplit[4]), jwClassSplit[5]);
            _jwInventoryList.Add(jwMinifigure);
        }
        else if (jwItemSplit[0] == "FullSet")
        {
            string[] jwClassSplit = jwItemSplit[1].Split("|");
            JWFullSet jwFullSet = new JWFullSet(jwClassSplit[0], float.Parse(jwClassSplit[1]), jwClassSplit[2], int.Parse(jwClassSplit[3]), jwClassSplit[4], int.Parse(jwClassSplit[5]));
            _jwInventoryList.Add(jwFullSet);
        }
        else if (jwItemSplit[0] == "IncompleteSet")
        {
            string[] jwClassSplit = jwItemSplit[1].Split("|");
            JWIncompleteSet jwIncompleteSet = new JWIncompleteSet(jwClassSplit[0], float.Parse(jwClassSplit[1]), jwClassSplit[2], int.Parse(jwClassSplit[3]), jwClassSplit[4], int.Parse(jwClassSplit[5]), jwClassSplit[6], jwClassSplit[7]);
            _jwInventoryList.Add(jwIncompleteSet);
        }
    }
    public virtual string StringForFile()
    {
        // return one long compiled string that holds all the LEGO items in the inventory. Label it as "Personal" so that upon loading the item may be identified as part of the personal inventory
        string jwReturnLine = "";
        foreach (JWLegoItem jwItem in _jwInventoryList)
        {
            jwReturnLine += $"\nPersonal#{jwItem.StringForFile()}";
        }
        return jwReturnLine;
    }
}