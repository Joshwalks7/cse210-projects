using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        JWListingActivity JWListingActivity = new JWListingActivity("Listing", "reflect on the good things in your life by having you list as any things as you can in a certain area");
        Console.Write("Menu Options:\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. Quit\nSelect a choice from the menu: ");
        string jwUserChoice = Console.ReadLine();

        if (jwUserChoice == "3")
        {
            Console.Write(JWListingActivity.JWBegin());
            JWListingActivity.JWSetDuration(Console.ReadLine());
        }

    }
}