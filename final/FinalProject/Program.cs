/*
Author: Joshua Walker
Description: Write a program that allows a user to create LEGO items (minifigures, full sets, and incomplete sets) that can be added to either a personal or selling inventory. These items can be viewed, removed, transfered to other inventories, etc. Additionally, transactions can be recorded with the sets that were sold.
Date: 7/15/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit06/project-plan.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;
using System.Diagnostics.Tracing;

class Program
{
    static void Main(string[] args)
    {
        // instantiate new instances of the inventories
        JWInventory jwPersonalInventory = new JWInventory("Personal Inventory");
        JWSellingInventory jwSellingInventory = new JWSellingInventory("Selling Inventory");
        string jwOptionsMessage = $"\nMenu Options:\n  1. Manage Personal Inventory\n  2. Manage Selling Inventory\n  3. Save Inventories\n  4. Load Inventories\n  5. Quit\nSelect a choice from the menu: ";
        Console.Write(jwOptionsMessage);
        string jwUserChoice = Console.ReadLine();
        while(jwUserChoice != "5")
        {
            // continue presenting the user with options on the program until they enter "5"
            if (jwUserChoice == "1")
            {
                // personal inventory options
                string jwPersonalOptionsMessage = "\nPersonal Inventory Options:\n  1. Display Sets in Collection\n  2. Add LEGO item to Inventory\n  3. Remove Item\n  4. Move Item to Selling Inventory\n  5. View Most Valuable Set\n  6. Search Sets by Theme\n  7. Estimate Collection Value\n  8. Return to Home\nWhat would you like to do? ";
                Console.Write(jwPersonalOptionsMessage);
                string jwPersonalChoice = Console.ReadLine();
                while (jwPersonalChoice != "8")
                {
                    Console.WriteLine();
                    if (jwPersonalChoice == "1")
                    {
                        jwPersonalInventory.DisplayCollection();
                    }
                    else if (jwPersonalChoice == "2")
                    {
                        Console.Write("Which type of LEGO Item would you like to add?\n  1. Minifigure\n  2. Complete Set\n  3. Incomplete Set\n>> ");
                        string jwItemChoice = Console.ReadLine();
                        if (jwItemChoice == "1")
                        {
                            // create new minifigure instance and add it to inventory
                            string jwName = GetUserInput("What is the name of the item? ");
                            float jwEstimatedValue = float.Parse(GetUserInput("What is the estimated value of the minifigure? "));
                            string jwTheme = GetUserInput("What is the theme of the minifigure? ");
                            int jwQuantity = int.Parse(GetUserInput("How many of this minifigure are you recording? "));
                            int jwYear = int.Parse(GetUserInput("What year was the minifigure first introduced/sold? "));
                            string jwAccessory = GetUserInput("Which of the minifigure's accessories do you have? (\"none\" if nothing) ");
                            JWMinifigure jwMinifigure = new JWMinifigure(jwName, jwEstimatedValue, jwTheme, jwQuantity, jwYear, jwAccessory);
                            jwPersonalInventory.AddItem(jwMinifigure);
                        }
                        else if (jwItemChoice == "2")
                        {
                            // create new full set instance and add it to inventory
                            string jwName = GetUserInput("What is the name of the set? ");
                            float jwEstimatedValue = float.Parse(GetUserInput("What is the estimated value of the set? "));
                            string jwTheme = GetUserInput("What is the theme of the set? ");
                            int jwQuantity = int.Parse(GetUserInput("How many of this set are you recording? "));
                            string jwCondition = GetUserInput("What is the set's condition? (sealed, used-good, used-worn, etc) ");
                            int jwSetNumber = int.Parse(GetUserInput("What is the set's number? "));
                            JWFullSet jwFullSet = new JWFullSet(jwName, jwEstimatedValue, jwTheme, jwQuantity, jwCondition, jwSetNumber);
                            jwPersonalInventory.AddItem(jwFullSet);
                        }
                        else if (jwItemChoice == "3")
                        {
                            // create new incomplete set instance and add it to personal inventory
                            string jwName = GetUserInput("What is the name of the set? ");
                            float jwEstimatedValue = float.Parse(GetUserInput("What is the estimated value of what you have? "));
                            string jwTheme = GetUserInput("What is the theme of the set? ");
                            int jwQuantity = int.Parse(GetUserInput("How many of this exact item are you recording? "));
                            string jwPercentComplete = GetUserInput("What percent is the set complete? ");
                            int jwSetNumber = int.Parse(GetUserInput("What is the set's number? "));
                            string jwMinifigures = GetUserInput("List the figures you have in combination with the set (or \"none\"): ");
                            string jwDescription = GetUserInput("What is your general description of this item? ");
                            JWIncompleteSet jwIncompleteSet = new JWIncompleteSet(jwName, jwEstimatedValue, jwTheme, jwQuantity, jwPercentComplete, jwSetNumber, jwMinifigures, jwDescription);
                            jwPersonalInventory.AddItem(jwIncompleteSet);
                        }
                    }
                    else if (jwPersonalChoice == "3")
                    {
                        jwPersonalInventory.DisplayCollection();
                        int jwRemoveIndex = int.Parse(GetUserInput("What item would you like to remove? ")) -1;
                        int jwQuantity = int.Parse(GetUserInput("How many would you like to remove? "));
                        // check to see if the quantity is 0, if so, remove from inventory
                        jwPersonalInventory.RemoveItem(jwRemoveIndex, jwQuantity);
                    }
                    else if (jwPersonalChoice == "4")
                    {
                        // remove item from personal inventory and add it to selling inventory
                        jwPersonalInventory.DisplayCollection();
                        int jwRemoveIndex = int.Parse(GetUserInput("Which item would you like to move to the selling collection? ")) -1;
                        JWLegoItem jwItemtoMove = jwPersonalInventory.RemoveFromInventory(jwRemoveIndex);
                        jwSellingInventory.AddItem(jwItemtoMove);
                    }
                    else if (jwPersonalChoice == "5")
                    {
                        Console.WriteLine($"Most Expensive Set: {jwPersonalInventory.DisplayMostExpensive()}");
                    }
                    else if (jwPersonalChoice == "6")
                    {
                        string jwTheme = GetUserInput("What theme are you searching for? ");
                        jwPersonalInventory.DisplayTheme(jwTheme);
                    }
                    else if (jwPersonalChoice == "7")
                    {
                        Console.WriteLine($"Your collection is worth about ${jwPersonalInventory.EstimateTotal()}!");
                    }
                    Console.Write(jwPersonalOptionsMessage);
                    jwPersonalChoice = Console.ReadLine();
                }
            }
            else if (jwUserChoice == "2")
            {
                // selling inventory options
                string jwSellingOptionsMessage = "\nSelling Inventory Options:\n  1. Display Sets in Collection\n  2. Add LEGO item to Inventory\n  3. Remove Item\n  4. Move Item to Personal Inventory\n  5. View Most Valuable Set\n  6. Search Sets by Theme\n  7. Estimate Collection Value\n  8. Record Transaction\n  9. View Transactions\n  10. Return to Home\nWhat would you like to do? ";
                Console.Write(jwSellingOptionsMessage);
                string jwSellingChoice = Console.ReadLine();
                while (jwSellingChoice != "10")
                {
                    Console.WriteLine();
                    if (jwSellingChoice == "1")
                    {
                        jwSellingInventory.DisplayCollection();
                    }
                    else if (jwSellingChoice == "2")
                    {
                       Console.Write("Which type of LEGO Item would you like to add?\n  1. Minifigure\n  2. Complete Set\n  3. Incomplete Set\n>> ");
                        string jwItemChoice = Console.ReadLine();
                        if (jwItemChoice == "1")
                        {
                            // create new minifigure instance and add it to selling inventory
                            string jwName = GetUserInput("What is the name of the item? ");
                            float jwEstimatedValue = float.Parse(GetUserInput("What is the estimated value of the minifigure? "));
                            string jwTheme = GetUserInput("What is the theme of the minifigure? ");
                            int jwQuantity = int.Parse(GetUserInput("How many of this minifigure are you recording? "));
                            int jwYear = int.Parse(GetUserInput("What year was the minifigure first introduced/sold? "));
                            string jwAccessory = GetUserInput("Which of the minifigure's accessories do you have? (\"none\" if nothing) ");
                            JWMinifigure jwMinifigure = new JWMinifigure(jwName, jwEstimatedValue, jwTheme, jwQuantity, jwYear, jwAccessory);
                            jwSellingInventory.AddItem(jwMinifigure);
                        }
                        else if (jwItemChoice == "2")
                        {
                            // create new full set instance and add it to selling inventory
                            string jwName = GetUserInput("What is the name of the set? ");
                            float jwEstimatedValue = float.Parse(GetUserInput("What is the estimated value of the set? "));
                            string jwTheme = GetUserInput("What is the theme of the set? ");
                            int jwQuantity = int.Parse(GetUserInput("How many of this set are you recording? "));
                            string jwCondition = GetUserInput("What is the set's condition? (sealed, used-good, used-worn, etc) ");
                            int jwSetNumber = int.Parse(GetUserInput("What is the set's number? "));
                            JWFullSet jwFullSet = new JWFullSet(jwName, jwEstimatedValue, jwTheme, jwQuantity, jwCondition, jwSetNumber);
                            jwSellingInventory.AddItem(jwFullSet);
                        }
                        else if (jwItemChoice == "3")
                        {
                            // create new incomplete set instance and add it to selling inventory
                            string jwName = GetUserInput("What is the name of the set? ");
                            float jwEstimatedValue = float.Parse(GetUserInput("What is the estimated value of what you have? "));
                            string jwTheme = GetUserInput("What is the theme of the set? ");
                            int jwQuantity = int.Parse(GetUserInput("How many of this exact item are you recording? "));
                            string jwPercentComplete = GetUserInput("What percent is the set complete? ");
                            int jwSetNumber = int.Parse(GetUserInput("What is the set's number? "));
                            string jwMinifigures = GetUserInput("List the figures you have in combination with the set (or \"none\"): ");
                            string jwDescription = GetUserInput("What is your general description of this item? ");
                            JWIncompleteSet jwIncompleteSet = new JWIncompleteSet(jwName, jwEstimatedValue, jwTheme, jwQuantity, jwPercentComplete, jwSetNumber, jwMinifigures, jwDescription);
                            jwSellingInventory.AddItem(jwIncompleteSet);
                        }
                    }
                    else if (jwSellingChoice == "3")
                    {
                        jwSellingInventory.DisplayCollection();
                        int jwRemoveIndex = int.Parse(GetUserInput("What item would you like to remove? ")) -1;
                        int jwQuantity = int.Parse(GetUserInput("How many would you like to remove? "));
                        jwSellingInventory.RemoveItem(jwRemoveIndex, jwQuantity);
                    }
                    else if (jwSellingChoice == "4")
                    {
                        // remove item from selling inventory and add it to personal inventory
                        jwSellingInventory.DisplayCollection();
                        int jwRemoveIndex = int.Parse(GetUserInput("Which item would you like to move to the selling collection? ")) -1;
                        JWLegoItem jwItemtoMove = jwSellingInventory.RemoveFromInventory(jwRemoveIndex);
                        jwPersonalInventory.AddItem(jwItemtoMove);
                    }
                    else if (jwSellingChoice == "5")
                    {
                        Console.WriteLine($"Most Expensive Set: {jwSellingInventory.DisplayMostExpensive()}");
                    }
                    else if (jwSellingChoice == "6")
                    {
                        string jwTheme = GetUserInput("What theme are you searching for? ");
                        jwSellingInventory.DisplayTheme(jwTheme);
                    }
                    else if (jwSellingChoice == "7")
                    {
                        Console.WriteLine($"Your collection is worth about ${jwSellingInventory.EstimateTotal()}!");
                    }
                    else if (jwSellingChoice == "8")
                    {
                        // create a new instance of a transaction and add it to the transactions list
                        string jwBuyerName = GetUserInput("What is the buyer's name? ");
                        float jwSellingPrice = float.Parse(GetUserInput("What was the selling price? "));
                        string jwAddress = GetUserInput("What is the address? ");
                        string jwEmail = GetUserInput("What is the email of contact? ");
                        List<JWLegoItem> jwSetsSold = [];
                        jwSellingInventory.DisplayCollection();
                        int jwItemChoice = int.Parse(GetUserInput("Which item would you like to add? ")) -1;
                        jwSetsSold.Add(jwSellingInventory.ReturnItemFromInventory(jwItemChoice));
                        jwSellingInventory.RemoveItem(jwItemChoice, 1);
                        string jwAddMoreItems = GetUserInput("Would you like to add more items? ");
                        while (jwAddMoreItems.ToLower() != "no")
                        {
                            // logic to continue adding as many sets as the user describes as part of the transaction
                            jwSellingInventory.DisplayCollection();
                            jwItemChoice = int.Parse(GetUserInput("Which item would you like to add? ")) -1;
                            jwSetsSold.Add(jwSellingInventory.ReturnItemFromInventory(jwItemChoice));
                            jwSellingInventory.RemoveItem(jwItemChoice, 1);
                            jwAddMoreItems = GetUserInput("Would you like to add more items? ");
                        }
                        string jwTransactionDate = GetUserInput("Date of transaction: ");
                        JWTransaction jwTransaction = new JWTransaction(jwBuyerName, jwSellingPrice, jwAddress, jwEmail, jwSetsSold, jwTransactionDate);
                        jwSellingInventory.RecordTransaction(jwTransaction);
                        Console.WriteLine("Transaction recorded!");
                    }
                    else if (jwSellingChoice == "9")
                    {
                        Console.WriteLine($"Your current revenue from sales is: ${jwSellingInventory.DisplayRevenue()}");
                        jwSellingInventory.ListTransactionSummaries();
                        int jwTransactionChoice = int.Parse(GetUserInput("What transaction would you like to view? ")) -1;
                        jwSellingInventory.ViewTransactionDetails(jwTransactionChoice);
                    }
                    Console.Write(jwSellingOptionsMessage);
                    jwSellingChoice = Console.ReadLine();
                }
            }
            else if (jwUserChoice == "3")
            {
                SaveFile(jwPersonalInventory, jwSellingInventory);
            }
            else if (jwUserChoice == "4")
            {
                LoadFile(jwPersonalInventory, jwSellingInventory);
            }
            Console.Write(jwOptionsMessage);
            jwUserChoice = Console.ReadLine();
        }    
    }
    static string GetUserInput(string jwDisplay)
    {
        // write the message the user wants to display and then return the captured data
        Console.Write(jwDisplay);
        return Console.ReadLine();
    }
    static void SaveFile(JWInventory jwPersonalInventory, JWSellingInventory jwSellingInventory)
    {
        // save the inventories to a file, beginning with the revenue, then the personal inventory data, the selling inventory data, and finally the transactions
        string jwFilename = GetUserInput("What is the filename? ");
        using (StreamWriter jwOutputFile = new StreamWriter(jwFilename))
            {
                jwOutputFile.Write(jwSellingInventory.DisplayRevenue());
                jwOutputFile.Write(jwPersonalInventory.StringForFile());
                jwOutputFile.Write(jwSellingInventory.StringForFile());
                jwOutputFile.Write(jwSellingInventory.StringTransaction());
            }
    }
    static void LoadFile(JWInventory jwPersonalInventory, JWSellingInventory jwSellingInventory)
    {
        // load the inventories from a file splitting the lines and calling methods from the inventory classes based on the split data key words
        Console.Write("What is the filename? ");
        string jwFilename = Console.ReadLine();

        string[] jwLines = System.IO.File.ReadAllLines(jwFilename);
        // grab the first line and add it to the current points
        jwSellingInventory.SetRevenue(float.Parse(jwLines[0]));
        foreach (string jwLine in jwLines[1..])
        {
            string[] jwClassSplit = jwLine.Split("#");
            if (jwClassSplit[0] == "Personal")
            {
                jwPersonalInventory.DeconstructFromFile(jwClassSplit[1]);
            }
            else if (jwClassSplit[0] == "Selling")
            {
                jwSellingInventory.DeconstructFromFile(jwClassSplit[1]);
            }
            else if (jwClassSplit[0] == "Transaction")
            {
                jwSellingInventory.DeconstructTransaction(jwClassSplit[1]);
            }
        }
    }
}