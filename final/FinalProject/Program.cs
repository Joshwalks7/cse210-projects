using System;

class Program
{
    static void Main(string[] args)
    {
        string jwOptionsMessage = $"\nMenu Options:\n  1. Manage Personal Inventory\n  2. Manage Selling Inventory\n  3. Save Inventories\n  4. Load Inventories\n  5. Quit\nSelect a choice from the menu: ";
        Console.Write(jwOptionsMessage);
        string jwUserChoice = Console.ReadLine();
    }
}