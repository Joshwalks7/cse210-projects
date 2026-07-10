using System;
using System.Diagnostics.Tracing;

class Program
{
    static void Main(string[] args)
    {
        JWInventory jwPersonalInventory = new JWInventory("Personal Inventory");
        JWSellingInventory jwSellingInventory = new JWSellingInventory("Selling Inventory");
        string jwOptionsMessage = $"\nMenu Options:\n  1. Manage Personal Inventory\n  2. Manage Selling Inventory\n  3. Save Inventories\n  4. Load Inventories\n  5. Quit\nSelect a choice from the menu: ";
        Console.Write(jwOptionsMessage);
        string jwUserChoice = Console.ReadLine();
        while(jwUserChoice != "5")
            if (jwUserChoice == "1")
            {
                Console.Write("Personal Inventory Options:\n  1. Display Sets in Collection\n  2. Add LEGO item to Inventory\n 3. Remove Item\n  4. Move Item to Selling Inventory\n  5. View Most Valuable Set\n  6. Search Sets by Theme\n  7. Estimate Collection Value\n  8. Return to Home\nWhat would you like to do? ");
                string jwPersonalChoice = Console.ReadLine();
                if (jwPersonalChoice == "1")
                {
                jwPersonalInventory.DisplayCollection();
                }
                else if (jwPersonalChoice == "2")
                {
                    Console.Write("Which type of LEGO Item would you like to add?\n  1. Minifigure\n  2. Complete Set\n  3. Incomplete Set\n>>");
                    string jwItemChoice = Console.ReadLine();
                    if (jwItemChoice == "1")
                    {
                        string jwName = GetUserInput("What is the name of the item? ");
                        float jwEstimatedValue = float.Parse(GetUserInput("What is the estimated value of the "));
                        string jwTheme = GetUserInput("What is the theme of the minifigure? ");
                        int jwQuantity = int.Parse(GetUserInput("How many of this minifigure are you recording? "));
                        int jwYear = int.Parse(GetUserInput("What year was the minifigure first introduced/sold? "));
                        string jwAccessory = GetUserInput("Which of the minifigure's accessories do you have? (\"none\" if nothing) ");
                        JWMinifigure jwMinifigure = new JWMinifigure(jwName, jwEstimatedValue, jwTheme, jwQuantity, jwYear, jwAccessory);
                        jwPersonalInventory.AddItem(jwMinifigure);
                    }
                    else if (jwItemChoice == "2")
                    {
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
                    jwPersonalInventory.RemoveItem(jwRemoveIndex, jwQuantity);
                }
                else if (jwPersonalChoice == "4")
                {
                    jwPersonalInventory.DisplayCollection();
                    int jwRemoveIndex = int.Parse(GetUserInput("Which item would you like to move to the selling collection? ")) -1;
                    JWLegoItem jwItemtoMove = jwPersonalInventory.RemoveFromInventory(jwRemoveIndex);
                    jwSellingInventory.AddItem(jwItemtoMove);
                }
                else if (jwPersonalChoice == "5")
                {
                    Console.WriteLine(jwPersonalInventory.DisplayMostExpensive());
                }
                else if (jwPersonalChoice == "6")
                {
                    string jwTheme = GetUserInput("What theme are you searching for? ");
                    jwPersonalInventory.DisplayTheme(jwTheme);
                }
                else if (jwPersonalChoice == "7")
                {
                    Console.WriteLine($"Your collection is worth about ${jwPersonalInventory.EstimateTotal}!");
                }
            }
    }
    static string GetUserInput(string jwDisplay)
    {
        Console.Write(jwDisplay);
        return Console.ReadLine();
    }
}